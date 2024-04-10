using Kafein.ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Domain.Entities
{
	public class Order : BaseEntity
	{
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public string Description { get; set; } = string.Empty;
        public required string Address { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
