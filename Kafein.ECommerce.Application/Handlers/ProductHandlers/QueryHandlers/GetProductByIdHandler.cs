using AutoMapper;
using Kafein.ECommerce.Application.Queries.ProductQueries;
using Kafein.ECommerce.Application.Repositories.ProductRepositories;
using Kafein.ECommerce.Application.Responses;
using Kafein.ECommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Handlers.ProductHandlers.QueryHandlers
{
	public class GetProductByIdHandler(IProductReadRepository repository, IMapper mapper) : IRequestHandler<GetProductByIdQuery, Response<ProductResponse>>
	{
		private readonly IProductReadRepository _repository = repository;
		private readonly IMapper _mapper = mapper;

		public async Task<Response<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var getProduct = await _repository.Find(x => x.Status && x.Id == request.Id);

			var response = _mapper.Map<ProductResponse>(getProduct);

			return Response<ProductResponse>.Success(response, 200);
		}
	}
}
