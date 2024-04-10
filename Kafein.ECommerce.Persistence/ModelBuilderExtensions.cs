using Kafein.ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Persistence
{
	public static class ModelBuilderExtensions
	{
		public static void MockData(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData(
				new Product { Id = 1, Name = "Product 1", UnitPrice = 500, Stock = 2500, CreatedBy = "Arife Gül Yalçın" },
				new Product { Id = 2, Name = "Product 2", UnitPrice = 1500, Stock = 50, CreatedBy = "Arife Gül Yalçın" },
				new Product { Id = 3, Name = "Product 3", UnitPrice = 10000, Stock = 5, CreatedBy = "Arife Gül Yalçın" },
				new Product { Id = 4, Name = "Product 4", UnitPrice = 4000, Stock = 10, CreatedBy = "Arife Gül Yalçın" }
			);

			modelBuilder.Entity<User>().HasData(
				new User { Id = 1, Name = "Arife Gül", Surname = "Yalçın", Email = "a.yalcin@diten.tech", CreatedBy = "Arife Gül Yalçın" }
			);
		}
	}
}
