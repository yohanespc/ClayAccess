using ClayAccess.Core.Entities;
using ClayAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ClayAccess.Core.Misc.Enum;

namespace ClayAccess.Core.Services
{
	public class AccessService : IAccessService
	{
		private readonly IUserRepository _userRepo;

		public AccessService(IUserRepository userRepo)
		{
			_userRepo = userRepo;
		}

		public Tuple<bool, User> AuthenticateUser(string email, string password)
		{
			bool result = false;
			User dbUser = _userRepo.GetUserByEmailPassword(email, password).Result;
			if ((dbUser.ValidUntil == null) || (DateTime.Now > dbUser.ValidFrom || dbUser.ValidUntil < dbUser.ValidFrom))
			{
				_userRepo.UpdateLastLoginTimestamp(dbUser.UserId);
				result = true;
			}
			return new Tuple<bool, User>(result, dbUser);
		}

		public async Task<List<User>> GetAllUsers()
		{
			return await _userRepo.GetAllUsers();
		}

	}
}
