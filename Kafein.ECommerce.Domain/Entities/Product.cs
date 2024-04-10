using Kafein.ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Domain.Entities
{
	public class Product : BaseEntity
	{
        public required string Name { get; set; } 
        public int Stock { get; set; }
        public long UnitPrice { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
