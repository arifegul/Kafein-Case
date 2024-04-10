using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Infrastructure.Dtos.Requests
{
	public record UpdateProductRequest
		(
			int ProductId,
			int OrderQuantity,
			int OrderId
		);
}
