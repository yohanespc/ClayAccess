using System.Threading.Tasks;

namespace ClayAccess.Core.Interfaces
{
	public interface IDoorRepository
    {
		Task<Core.Entities.Door> GetDoorByCompanyIdName(int companyId, string name);
	}
}
