using Diten.Daywork.Infrastructure.RabbitMQ.Core;
using Diten.Daywork.Infrastructure.RabbitMQ.Order;
using Diten.Daywork.Infrastructure.RabbitMQ.Producer;
using Kafein.ECommerce.Application.Commands.OrderCommands;
using Kafein.ECommerce.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Kafein.ECommerce.Application.Handlers.OrderHandlers.CommandHandlers
{
	public class SendOrderEmailHandler(EventBusRabbitMQProducer eventBus, ILogger<SendOrderEmailHandler> logger) : IRequestHandler<SendOrderEmailCommand, Response<bool>>
	{
		private readonly EventBusRabbitMQProducer _eventBus = eventBus;
		private readonly ILogger<SendOrderEmailHandler> _logger = logger;

		public async Task<Response<bool>> Handle(SendOrderEmailCommand request, CancellationToken cancellationToken)
		{
			SendEmailOrder orderMessage = new SendEmailOrder
			{
				ToEmail = request.Email,
				Subject = "Kafein.ECommerce / Siparişiniz oluşturuldu",
				Body = HtmlHelper.GetOrderConfirmationHtml(request.ProductName, request.ProductQuantity, request.UnitPrice)
			};

			try
			{
				_eventBus.Publish(EventBusConstants.SendEmailQueue, orderMessage);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "ERROR Publishing integration order: {Email} from {AppName}", orderMessage.ToEmail, "Order");
				throw;
			}


			return Response<bool>.Success(true, 201);
		}
	}
}
