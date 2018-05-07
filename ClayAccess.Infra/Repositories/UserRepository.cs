using ClayAccess.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ClayAccess.Infra.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly Data.ClayDb _clayDb;

		public UserRepository(Data.ClayDb clayDb)
		{
			_clayDb = clayDb;
		}

		public async Task<Core.Entities.User> GetUserByEmailPassword(string email, string password)
		{
			Data.User dbUser = await _clayDb.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
			return dbUser == null
				? null
				: new Core.Entities.User() //ToDo use automapper
				{
					Email = dbUser.Email,
					Name = dbUser.Name,
					Password = dbUser.Password,
					UserId = dbUser.UserId
				};
		}
	}
}
