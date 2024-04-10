using Kafein.ECommerce.Application.Commands.OrderCommands;
using Kafein.ECommerce.Application.Commands.ProductCommands;
using Kafein.ECommerce.Application.Queries.OrderQueries;
using Kafein.ECommerce.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kafein.ECommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController(IMediator mediator) : CustomBaseController
	{
		private readonly IMediator _mediator = mediator;

		/// <summary>
		/// Order oluşturulacak 
		/// </summary>
		[HttpPost("CreateOrder")]
		public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
		{
			var response = await _mediator.Send(command);

			return CreateActionResultInstance(response);
		}

		/// <summary>
		/// Order oluşturulmuşsa Email gönderilecek 
		/// </summary>
		[HttpPost("SendOrderEmail")]
		public async Task<IActionResult> SendOrderEmail(SendOrderEmailCommand command)
		{
			var response = await _mediator.Send(command);

			return CreateActionResultInstance(response);
		}

		/// <summary>
		/// Order ı id ye göre getirme
		/// </summary>
		[HttpGet("GetOrderById")]
		public async Task<IActionResult> GetOrderById(int id)
		{
			var response = await _mediator.Send(new GetOrderByIdQuery(id));

			return CreateActionResultInstance(response);
		}
	}
}
