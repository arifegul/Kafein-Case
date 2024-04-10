using Kafein.ECommerce.Application.Commands.ProductCommands;
using Kafein.ECommerce.Application.Queries.ProductQueries;
using Kafein.ECommerce.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kafein.ECommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController(IMediator mediator) : CustomBaseController
	{
		private readonly IMediator _mediator = mediator;

		/// <summary>
		/// Mock data dışında eğer yeni ürün kaydedilmek istenirse
		/// </summary>
		[HttpPost("CreateProduct")]
		public async Task<IActionResult> CreateProduct(CreateProductCommand command)
		{
			var response = await _mediator.Send(command);

			return CreateActionResultInstance(response);
		}

		/// <summary>
		/// Tüm productları görüp order yapmak için kullanılması için
		/// </summary>
		[HttpGet("GetAllProduct")]
		public async Task<IActionResult> GetAllProduct()
		{
			var response = await _mediator.Send(new GetAllProductQuery());

			return CreateActionResultInstance(response);
		}

		/// <summary>
		/// Product ı kontrol etmek amaçlı yazılmıştır
		/// </summary>
		[HttpGet("GetProductById")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var response = await _mediator.Send(new GetProductByIdQuery(id));

			return CreateActionResultInstance(response);
		}

		/// <summary>
		/// Order yapıldıkca product güncelleme
		/// </summary>
		[HttpPatch("UpdateProduct")]
		public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
		{
			var response = await _mediator.Send(command);

			return CreateActionResultInstance(response);
		}
	}
}
