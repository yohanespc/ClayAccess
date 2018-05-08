using ClayAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClayAccess.Core.Interfaces
{
	public interface IAccessService
	{
		Tuple<bool, User> AuthenticateUser(string email, string password);
		Task<List<User>> GetAllUsers();
		Task<Door> GetDoorByCompanyIdName(int companyId, string name);
		Task<bool> GetProfileAccess(int profileId, int doorId);
		Task<List<UserAccessLog>> GetLogsByCompanyId(int companyId);
		void WriteAccessLog(bool access, int doorId, int profileId, int userId);
	}
}