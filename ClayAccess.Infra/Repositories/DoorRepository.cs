using ClayAccess.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClayAccess.Infra.Repositories
{
	public class DoorRepository : IDoorRepository
	{
		private readonly Data.ClayDbContext _clayDb;
		private DbSet<Data.Door> dbDoors;

		public DoorRepository(Data.ClayDbContext clayDb)
		{
			_clayDb = clayDb;
			dbDoors = clayDb.Set<Data.Door>();
		}

		public async Task<Core.Entities.Door> GetDoorByCompanyIdName(int companyId, string name)
		{
			Data.Door dbDoor = await dbDoors.FirstOrDefaultAsync(x => x.CompanyId == companyId && x.Name == name);
			return dbDoor == null
				? null
				: dbDoor.ToEntity();
		}


	}
}
