using Kafein.ECommerce.Application.Commands.ProductCommands;
using Kafein.ECommerce.Application.Repositories;
using Kafein.ECommerce.Application.Repositories.ProductRepositories;
using Kafein.ECommerce.Application.Shared;
using Kafein.ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Handlers.ProductHandlers.CommandHandlers
{
	public class CreateProductHandler(IProductWriteRepository repository) : IRequestHandler<CreateProductCommand, Response<bool>>
	{
		private readonly IProductWriteRepository _repository = repository;

		public async Task<Response<bool>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			Product product = new()
			{
				Name = request.Name,
				Stock = request.Stock,
				CreatedBy = request.CreatedBy,
				UnitPrice = request.UnitPrice
			};

			var isCreated = await _repository.Create(product) >= 1;

			if (!isCreated)
				return Response<bool>.Fail("Cannot created!", 409);

			return Response<bool>.Success(isCreated, 201);
		}
	}
}
