using Diten.Daywork.Infrastructure.RabbitMQ.Core;
using Diten.Daywork.Infrastructure.RabbitMQ.Dtos;
using Diten.Daywork.Infrastructure.RabbitMQ.Services.Interface;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diten.Daywork.Infrastructure.RabbitMQ.Consumers
{
    public class EventBusSendEmailConsumer(IRabbitMQPersistentConnection persistentConnection, IMailService mailService)
	{
        private readonly IRabbitMQPersistentConnection _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
        private readonly IMailService _mailService = mailService;

		public void Consume()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.SendEmailQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: EventBusConstants.SendEmailQueue, autoAck: true, consumer: consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.Span);
            var @event = JsonConvert.DeserializeObject<MailRequest>(message);

            if (e.RoutingKey == EventBusConstants.SendEmailQueue)
            {
                await _mailService.SendEmailAsync(@event);
            }
        }

        public void Disconnect()
        {
            _persistentConnection.Dispose();
        }
    }
}
