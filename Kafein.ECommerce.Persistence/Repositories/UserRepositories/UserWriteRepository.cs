using Kafein.ECommerce.Application.Repositories.UserRepositories;
using Kafein.ECommerce.Domain.Entities;
using Kafein.ECommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Persistence.Repositories.UserRepositories
{
	public class UserWriteRepository(KafeinECommerceDbContext dbContext) : WriteRepository<User>(dbContext), IUserWriteRepository
	{
	}
}
