using Kafein.ECommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Commands.ProductCommands
{
	public record UpdateProductCommand
		(
			int ProductId,
			int OrderQuantity,
			int OrderId
		)
		: IRequest<Response<bool>>;
}
