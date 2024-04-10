using AutoMapper;
using Kafein.ECommerce.Application.Commands.ProductCommands;
using Kafein.ECommerce.Application.Repositories.ProductRepositories;
using Kafein.ECommerce.Application.Responses;
using Kafein.ECommerce.Application.Shared;
using Kafein.ECommerce.Domain.Entities;
using Kafein.ECommerce.Infrastructure.APIs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Handlers.ProductHandlers.CommandHandlers
{
	public class UpdateProductHandler(IProductWriteRepository repository, IMapper mapper) : IRequestHandler<UpdateProductCommand, Response<bool>>
	{
		private readonly IProductWriteRepository _repository = repository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var getProduct = await KafeinECommerceAPIs.GetProductById<ProductResponse>(request.ProductId);

			if (getProduct == null)
				return Response<bool>.Fail("Product cannot found!", 409);

			var getOrder = await KafeinECommerceAPIs.GetOrderById<OrderResponse>(request.OrderId);

			if (getOrder == null)
				return Response<bool>.Fail("Order cannot found!", 409);

			var product = _mapper.Map<Product>(getProduct);
			var order = _mapper.Map<Order>(getOrder);

			product.Stock -= request.OrderQuantity;
			product.ModifiedDate = DateTime.Now;

			product.Orders ??= new List<Order>();
			product.Orders.Add(order);

			var isUpdated = await _repository.Update(product) >= 1;
			if (!isUpdated)
				return Response<bool>.Fail("Product could not updated", 409);

			return Response<bool>.Success(isUpdated, 201);		
		}
	}
}
