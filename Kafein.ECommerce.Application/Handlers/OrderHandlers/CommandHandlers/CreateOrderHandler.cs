using Kafein.ECommerce.Application.Commands.OrderCommands;
using Kafein.ECommerce.Application.Repositories.OrderRepositories;
using Kafein.ECommerce.Application.Responses;
using Kafein.ECommerce.Application.Shared;
using Kafein.ECommerce.Domain.Entities;
using Kafein.ECommerce.Infrastructure.APIs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Handlers.OrderHandlers.CommandHandlers
{
	public class CreateOrderHandler(IOrderWriteRepository repository) : IRequestHandler<CreateOrderCommand, Response<bool>>
	{
		private readonly IOrderWriteRepository _repository = repository;
		public async Task<Response<bool>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var getUser = await KafeinECommerceAPIs.GetUserById<UserResponse>(request.UserId);

			if (getUser == null)
				return Response<bool>.Fail("User cannot found!", 409);

			var getProduct = await KafeinECommerceAPIs.GetProductById<ProductResponse>(request.ProductId);

			if (getProduct == null)
				return Response<bool>.Fail("Product cannot found!", 409);

			if (request.ProductQuantity == 0)
				return Response<bool>.Fail("Please enter a valid quantity!", 409);

			if (request.ProductQuantity > getProduct.Stock)
				return Response<bool>.Fail($"There is not enough stock left for the product {getProduct.Name}", 409);

			Order order = new()
			{
				UserId = request.UserId,
				ProductId = request.ProductId,
				Address = request.Address,
				Description = request.Description,	
				ProductQuantity = request.ProductQuantity,
				CreatedBy = request.CreatedBy
			};

			var isCreated = await _repository.Create(order) >= 1;
			if (!isCreated)
				return Response<bool>.Fail("Order could not be created!", 409);

			var sendEmail = await KafeinECommerceAPIs.SendOrderEmail<bool>(getUser.Email, getProduct.Name, request.ProductQuantity, getProduct.UnitPrice);

			if (!sendEmail)
				return Response<bool>.Fail("A problem was encountered while sending the e-mail", 409);

			var updateProduct = await KafeinECommerceAPIs.UpdateProduct<bool>(request.ProductId, request.ProductQuantity, order.Id);

			if (!updateProduct)
				return Response<bool>.Fail("Product could not updated", 409);

			return Response<bool>.Success(true, 201);
		}
	}
}
