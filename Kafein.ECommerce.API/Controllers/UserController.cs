using Kafein.ECommerce.Application.Commands.ProductCommands;
using Kafein.ECommerce.Application.Commands.UserCommands;
using Kafein.ECommerce.Application.Queries.UserQueries;
using Kafein.ECommerce.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kafein.ECommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(IMediator mediator) : CustomBaseController
	{
		private readonly IMediator _mediator = mediator;

		/// <summary>
		/// Mock data dışında eğer yeni kullanıcı kaydedilmek istenirse
		/// </summary>
		[HttpPost("CreateUser")]
		public async Task<IActionResult> CreateUser(CreateUserCommand command)
		{
			var response = await _mediator.Send(command);

			return CreateActionResultInstance(response);
		}

		/// <summary>
		/// Sistem de hangi kullanıcının login olduğu bilgisi proje kapsamında olmadığından, userları çekerek orderları bu id lerle yapacağız.
		/// </summary>
		[HttpGet("GetAllUser")]
		public async Task<IActionResult> GetAllUser()
		{
			var response = await _mediator.Send(new GetAllUserQuery());

			return CreateActionResultInstance(response);
		}

		/// <summary>
		/// User ı kontrol etmek amaçlı yazılmıştır
		/// </summary>
		[HttpGet("GetUserById")]
		public async Task<IActionResult> GetUserById(int id)
		{
			var response = await _mediator.Send(new GetUserByIdQuery(id));

			return CreateActionResultInstance(response);
		}

	}
}
