using AutoMapper;
using Kafein.ECommerce.Application.Queries.ProductQueries;
using Kafein.ECommerce.Application.Repositories;
using Kafein.ECommerce.Application.Repositories.ProductRepositories;
using Kafein.ECommerce.Application.Responses;
using Kafein.ECommerce.Application.Shared;
using Kafein.ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kafein.ECommerce.Application.Handlers.ProductHandlers.QueryHandlers
{
	public class GetAllProductHandler(IProductReadRepository repository, IMapper mapper) : IRequestHandler<GetAllProductQuery, Response<List<ProductResponse>>>
	{
		private readonly IProductReadRepository _repository = repository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<List<ProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
		{
			var getProducts = await _repository.GetAllIncluding(x => x.Orders);

			var response = _mapper.Map<List<ProductResponse>>(getProducts);

			return Response<List<ProductResponse>>.Success(response, 200);
		}
	}
}
