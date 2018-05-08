using ClayAccess.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClayAccess.Infra.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly Data.ClayDbContext _clayDb;
		private DbSet<Data.User> dbUsers;

		public UserRepository(Data.ClayDbContext clayDb)
		{
			_clayDb = clayDb;
			dbUsers = clayDb.Set<Data.User>();
		}

		public async Task<Core.Entities.User> GetUserByEmailPassword(string email, string password)
		{
			Data.User dbUser = await dbUsers.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
			return dbUser == null
				? null
				: dbUser.ToUserEntity();
		}

		public async Task<List<Core.Entities.User>> GetAllUsers()
		{
			List<Data.User> dbUser = await dbUsers.ToListAsync();
			List<Core.Entities.User> users = new List<Core.Entities.User>();
			dbUser.ForEach(x => users.Add(x.ToUserEntity()));
			return users;
		}

	}
}
