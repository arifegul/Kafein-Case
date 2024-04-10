using Kafein.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Responses
{
	public class ProductResponse
	{
        public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int Stock { get; set; }
		public long UnitPrice { get; set; }
		public string CreatedBy { get; set; }
        public ICollection<OrderResponse> Orders { get; set; }
    }
}
