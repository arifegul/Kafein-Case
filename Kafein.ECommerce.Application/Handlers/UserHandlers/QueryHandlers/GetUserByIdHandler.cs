using AutoMapper;
using Kafein.ECommerce.Application.Queries.UserQueries;
using Kafein.ECommerce.Application.Repositories.UserRepositories;
using Kafein.ECommerce.Application.Responses;
using Kafein.ECommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Handlers.UserHandlers.QueryHandlers
{
	public class GetUserByIdHandler(IUserReadRepository repository, IMapper mapper) : IRequestHandler<GetUserByIdQuery, Response<UserResponse>>
	{
		private readonly IUserReadRepository _repository = repository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var getUser = await _repository.Find(x => x.Status && x.Id == request.Id);

			var response = _mapper.Map<UserResponse>(getUser);

			return Response<UserResponse>.Success(response, 200);
		}
	}
}
