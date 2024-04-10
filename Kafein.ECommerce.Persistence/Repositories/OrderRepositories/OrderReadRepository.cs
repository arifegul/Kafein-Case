using Kafein.ECommerce.Application.Repositories.OrderRepositories;
using Kafein.ECommerce.Domain.Entities;
using Kafein.ECommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Persistence.Repositories.OrderRepositories
{
	public class OrderReadRepository(KafeinECommerceDbContext dbContext) : ReadRepository<Order>(dbContext), IOrderReadRepository
	{
	}
}
