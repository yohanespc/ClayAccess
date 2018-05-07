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
			this._userRepo = userRepo;
		}

		public User AuthenticateUser(string email, string password)
		{
			Core.Entities.User user = null;
			if (email == "yohanes@email.com" && password == "AdminAlwaysRight")
			{
				user = new Core.Entities.User { UserId = 1, Name = "Yohanes", Email = "yohanes@email.com", Profile = (int)UserProfile.Admin };
			}
			else if (email == "guest@email.com" && password == "GuestAlwaysWelcome")
			{
				user = new Core.Entities.User { UserId = 2, Name = "Guest 1", Email = "guest@email.com", Profile = (int)UserProfile.Guest };
			}
			else if (email == "intern@email.com" && password == "InternNeedToWorkHarder")
			{
				user = new Core.Entities.User { UserId = 2, Name = "Intern 1", Email = "intern@email.com", Profile = (int)UserProfile.Intern };
			}
			else if (email == "employee@email.com" && password == "EmployeeNeedMoreBonus")
			{
				user = new Core.Entities.User { UserId = 2, Name = "Employee 1", Email = "employee@email.com", Profile = (int)UserProfile.Employee };
			}
			return user;
		}

	}
}
