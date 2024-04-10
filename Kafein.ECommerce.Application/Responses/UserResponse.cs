using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Responses
{
	public class UserResponse
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string CreatedBy { get; set; }
        public ICollection<OrderResponse> Orders { get; set; }
    }
}
