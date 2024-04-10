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
	public class GetAllUserHandler(IUserReadRepository repository, IMapper mapper) : IRequestHandler<GetAllUserQuery, Response<List<UserResponse>>>
	{
		private readonly IUserReadRepository _repository = repository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<List<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
		{
			var getUsers = await _repository.GetAllIncluding(x => x.Orders);

			var response = _mapper.Map<List<UserResponse>>(getUsers);

			return Response<List<UserResponse>>.Success(response, 200);
		}
	}
}
