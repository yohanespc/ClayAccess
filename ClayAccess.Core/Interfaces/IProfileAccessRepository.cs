using System.Threading.Tasks;

namespace ClayAccess.Core.Interfaces
{
	public interface IProfileAccessRepository
    {
		Task<Entities.ProfileAccess> GetProfileAccess(int profileId, int doorId);
	}
}
