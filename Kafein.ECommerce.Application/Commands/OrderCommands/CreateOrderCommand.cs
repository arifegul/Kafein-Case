using Kafein.ECommerce.Application.Shared;
using Kafein.ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Commands.OrderCommands
{
	public record CreateOrderCommand
		(
			int UserId,
			int ProductId,
			string Description,
			string Address,
			int ProductQuantity,
			string CreatedBy
		)
		: IRequest<Response<bool>>;
}
