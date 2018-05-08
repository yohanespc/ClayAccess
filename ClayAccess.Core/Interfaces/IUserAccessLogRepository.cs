using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClayAccess.Core.Interfaces
{
	public interface IUserAccessLogRepository
	{
		Task<List<Core.Entities.UserAccessLog>> GetAllLogs(int companyId);
		void InsertLog(Core.Entities.UserAccessLog inputLog);
	}
}
