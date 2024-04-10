using Kafein.ECommerce.Application.Repositories;
using Kafein.ECommerce.Domain.Entities;
using Kafein.ECommerce.Domain.Entities.Common;
using Kafein.ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Persistence.Repositories
{
	public class ReadRepository<T>(KafeinECommerceDbContext dbContext) : IReadRepository<T> where T : BaseEntity
	{
		private readonly KafeinECommerceDbContext _dbContext = dbContext;

		public DbSet<T> Table => _dbContext.Set<T>();

		public async Task<T> Find(Expression<Func<T, bool>> expression)
			=> await Table.AsNoTracking().FirstOrDefaultAsync(expression);

		public async Task<List<T>> GetAll()
		=> await Table.AsNoTracking().ToListAsync();

		public async Task<List<T>> GetAllIncluding(params Expression<Func<T, object>>[] includes)
		{
			var query = _dbContext.Set<T>().AsQueryable();

			if (includes != null)
			{
				query = includes.Aggregate(query, (current, include) => current.Include(include));
			}

			return await query.ToListAsync();
		}
	}
}
