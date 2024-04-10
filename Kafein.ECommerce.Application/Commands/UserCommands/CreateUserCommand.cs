using Kafein.ECommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Commands.UserCommands
{
	public record CreateUserCommand
		(
		string Name,
		string Surname,
		string Email,
		string CreatedBy
		)
		: IRequest<Response<bool>>;
}
