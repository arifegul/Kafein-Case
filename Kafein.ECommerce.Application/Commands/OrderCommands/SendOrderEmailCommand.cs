using Kafein.ECommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Commands.OrderCommands
{
	public record SendOrderEmailCommand
		(
			string Email,
			string ProductName,
			int ProductQuantity,
			long UnitPrice
		)
		: IRequest<Response<bool>>;
}
