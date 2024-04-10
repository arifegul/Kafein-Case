using Kafein.ECommerce.Application.Commands.UserCommands;
using Kafein.ECommerce.Application.Repositories.UserRepositories;
using Kafein.ECommerce.Application.Shared;
using Kafein.ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Handlers.UserHandlers.CommandHandlers
{
	public class CreateUserHandler(IUserWriteRepository repository) : IRequestHandler<CreateUserCommand, Response<bool>>
	{
		private readonly IUserWriteRepository _repository = repository;
		public async Task<Response<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			User user = new()
			{
				CreatedBy = request.CreatedBy,
				Email = request.Email,
				Name = request.Name,
				Surname = request.Surname
			};

			var isCreated = await _repository.Create(user) >= 1;

			if (!isCreated)
				return Response<bool>.Fail("User cannot created!", 409);

			return Response<bool>.Success(isCreated, 201);
		}
	}
}
