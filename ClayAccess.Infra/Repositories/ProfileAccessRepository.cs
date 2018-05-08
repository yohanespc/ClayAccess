using ClayAccess.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClayAccess.Infra.Repositories
{
	public class ProfileAccessRepository : IProfileAccessRepository
	{
		private readonly Data.ClayDbContext _clayDb;
		private DbSet<Data.ProfileAccess> _dbProfileAccess;

		public ProfileAccessRepository(Data.ClayDbContext clayDb)
		{
			_clayDb = clayDb;
			_dbProfileAccess = clayDb.Set<Data.ProfileAccess>();
		}

		public async Task<Core.Entities.ProfileAccess> GetProfileAccess(int profileId, int doorId)
		{
			Data.ProfileAccess dbProfileAccess = await _dbProfileAccess.FirstOrDefaultAsync(x => x.ProfileId == profileId && x.DoorId == doorId);
			return dbProfileAccess == null
				? null
				: dbProfileAccess.ToEntity();
		}

	}
}
