using ClayAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClayAccess.Core.Interfaces
{
	public interface IUserRepository
	{
		Task<Core.Entities.User> GetUserByEmailPassword(string email, string password);
		Task<List<Core.Entities.User>> GetAllUsers();
	}
}
