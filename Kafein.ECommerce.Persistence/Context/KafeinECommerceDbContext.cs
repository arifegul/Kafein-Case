using Kafein.ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Persistence.Context
{
	public class KafeinECommerceDbContext : DbContext
	{
		public KafeinECommerceDbContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.MockData();
		}
	}
}
