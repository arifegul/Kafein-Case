using Kafein.ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Domain.Entities
{
	public class User : BaseEntity
	{
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
