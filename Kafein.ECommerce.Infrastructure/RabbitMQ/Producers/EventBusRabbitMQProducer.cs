using Diten.Daywork.Infrastructure.RabbitMQ.Order.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Diten.Daywork.Infrastructure.RabbitMQ.Producer
{
    public class EventBusRabbitMQProducer(IRabbitMQPersistentConnection persistentConnection, ILogger<EventBusRabbitMQProducer> logger, int retryCount = 5)
	{
        private readonly IRabbitMQPersistentConnection _persistentConnection = persistentConnection;
        private readonly ILogger<EventBusRabbitMQProducer> _logger = logger;
        private readonly int _retryCount = retryCount;

		public void Publish(string queueName, IOrder order)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var policy = RetryPolicy.Handle<BrokerUnreachableException>()
            .Or<SocketException>()
            .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
            {
                _logger.LogWarning(ex, "Could not publish: after {Timeout}s ({ExceptionMessage})", order.RequestId, $"{time.TotalSeconds:n1}", ex.Message);
            });
            //publish işlemleri için
            using (var channel = _persistentConnection.CreateModel())
            {
                //durable => durable false ise inmemory olarak tutuyor ve restrat ettiğimizde de verileri tutuyor, eğer true ise rabbitmq da tutuyor ve restrat ettiğimizde verilerin silinmemesini sağlıyor
                //exclusive tek bir connection olmasını sağlıyor tek bir consumer olabilir
                //autoDelete : queue eğer bir consumera sahipse son subsrcibe ortadan kalktığında queuenın silineceği işe yarıyor.
                channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var message = JsonConvert.SerializeObject(order);
                var body = Encoding.UTF8.GetBytes(message);
                //policy kullanılmadığında connection sıkıntısı olabildiğinden projenin sağlıklığı açısından
                policy.Execute(() =>
                {
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    properties.DeliveryMode = 2;

                    channel.ConfirmSelect();
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queueName,
                        mandatory: true,
                        basicProperties: properties,
                        body: body);
                    channel.WaitForConfirmsOrDie();

                    channel.BasicAcks += (sender, eventArgs) =>
                    {
                        Console.WriteLine("Sent RabbitMQ");
                        //implement ack handle
                    };
                });
            }
        }
    }
}
