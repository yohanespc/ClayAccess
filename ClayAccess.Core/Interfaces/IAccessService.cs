using System.Collections.Generic;
using System.Threading.Tasks;
using ClayAccess.Core.Entities;

namespace ClayAccess.Core.Interfaces
{
	public interface IAccessService
	{
		User AuthenticateUser(string email, string password);
		Task<List<User>> GetAllUsers();
	}
}