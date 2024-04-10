using Kafein.ECommerce.Application.Responses;
using Kafein.ECommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Queries.UserQueries
{
	public record GetUserByIdQuery
		(
			int Id
		)
		: IRequest<Response<UserResponse>>;
}
