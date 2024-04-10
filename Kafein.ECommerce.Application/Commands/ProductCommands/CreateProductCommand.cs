using Kafein.ECommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Commands.ProductCommands
{
	public record CreateProductCommand
		(
			string Name,
			int Stock,
			long UnitPrice,
			string CreatedBy
		)
		: IRequest<Response<bool>>;
}
