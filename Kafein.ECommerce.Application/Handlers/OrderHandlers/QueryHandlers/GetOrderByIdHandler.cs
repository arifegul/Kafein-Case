using AutoMapper;
using Kafein.ECommerce.Application.Queries.OrderQueries;
using Kafein.ECommerce.Application.Repositories.OrderRepositories;
using Kafein.ECommerce.Application.Responses;
using Kafein.ECommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Handlers.OrderHandlers.QueryHandlers
{
	public class GetOrderByIdHandler(IOrderReadRepository repository, IMapper mapper) : IRequestHandler<GetOrderByIdQuery, Response<OrderResponse>>
	{
		private IOrderReadRepository _repository = repository;
		private IMapper _mapper = mapper;
		public async Task<Response<OrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
		{
			var getOrder = await _repository.Find(x => x.Status && x.Id == request.Id);

			var response = _mapper.Map<OrderResponse>(getOrder);

			return Response<OrderResponse>.Success(response, 200);
		}
	}
}
