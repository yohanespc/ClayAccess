using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClayAccess.Core.Interfaces
{
	public interface IUserRepository
	{
		Task<Core.Entities.User> GetUserByEmailPassword(string email, string password);
		Task<List<Core.Entities.User>> GetAllUsers();
		void UpdateLastLoginTimestamp(int userId);
	}
}
