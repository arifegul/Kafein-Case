using Kafein.ECommerce.Application.Repositories;
using Kafein.ECommerce.Domain.Entities.Common;
using Kafein.ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Persistence.Repositories
{
	public class WriteRepository<T>(KafeinECommerceDbContext dbContext) : IWriteRepository<T> where T : BaseEntity
	{
		private readonly KafeinECommerceDbContext _dbContext = dbContext;
		public DbSet<T> Table => _dbContext.Set<T>();

		public async Task<int> Create(T entity)
		{
			await Table.AddAsync(entity);
			return await Save();
		}

		public async Task<int> Delete(T entity)
		{
			Table.Remove(entity);
			return await Save();
		}

		public async Task<int> Update(T entity)
		{
			Table.Update(entity);
			return await Save();

		}

		private async Task<int> Save()
			=> await _dbContext.SaveChangesAsync();
	}
}
