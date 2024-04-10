using Kafein.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Responses
{
	public class OrderResponse
	{
        public int Id { get; set; }
		public int ProductId { get; set; }
		public int UserId { get; set; }
		public int ProductQuantity { get; set; }
		public string Description { get; set; } = string.Empty;
		public required string Address { get; set; }
        public string CreatedBy { get; set; }
	}
}
