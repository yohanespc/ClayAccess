using ClayAccess.Core.Entities;
using ClayAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClayAccess.Core.Services
{
	public class AccessService : IAccessService
	{
		private readonly IUserRepository _userRepo;
		private readonly IDoorRepository _doorRepository;
		private readonly IProfileAccessRepository _profileAccessRepository;

		public AccessService(IUserRepository userRepo, IDoorRepository doorRepository, IProfileAccessRepository profileAccessRepository)
		{
			_userRepo = userRepo;
			_doorRepository = doorRepository;
			_profileAccessRepository = profileAccessRepository;
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

		public async Task<Door> GetDoorByCompanyIdName(int companyId, string name)
		{
			Door dbDoor = await _doorRepository.GetDoorByCompanyIdName(companyId, name);
			return dbDoor;
		}

		public async Task<bool> GetProfileAccess(int profileId, int doorId)
		{
			ProfileAccess dbProfileAccess = await _profileAccessRepository.GetProfileAccess(profileId, doorId);
			return dbProfileAccess != null ? dbProfileAccess.EntryAccess : false;
		}

	}
}
