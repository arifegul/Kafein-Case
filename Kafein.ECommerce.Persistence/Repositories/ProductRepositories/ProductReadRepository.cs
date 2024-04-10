using Kafein.ECommerce.Application.Repositories.ProductRepositories;
using Kafein.ECommerce.Domain.Entities;
using Kafein.ECommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Persistence.Repositories.ProductRepositories
{
	public class ProductReadRepository(KafeinECommerceDbContext dbContext) : ReadRepository<Product>(dbContext), IProductReadRepository
	{
	}
}
