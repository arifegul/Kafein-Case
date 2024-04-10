using Kafein.ECommerce.Application.Repositories;
using Kafein.ECommerce.Application.Repositories.OrderRepositories;
using Kafein.ECommerce.Application.Repositories.ProductRepositories;
using Kafein.ECommerce.Application.Repositories.UserRepositories;
using Kafein.ECommerce.Persistence.Context;
using Kafein.ECommerce.Persistence.Repositories;
using Kafein.ECommerce.Persistence.Repositories.OrderRepositories;
using Kafein.ECommerce.Persistence.Repositories.ProductRepositories;
using Kafein.ECommerce.Persistence.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<KafeinECommerceDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
			services.AddScoped<IUserReadRepository, UserReadRepository>();
			services.AddScoped<IUserWriteRepository, UserWriteRepository>();
			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
		}
	}
}
