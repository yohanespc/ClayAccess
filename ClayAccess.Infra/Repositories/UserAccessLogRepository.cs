using ClayAccess.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClayAccess.Infra.Repositories
{
	public class UserAccessLogRepository : IUserAccessLogRepository
	{
		private readonly Data.ClayDbContext _clayDb;
		private DbSet<Data.UserAccessLog> dbUserAccessLog;

		public UserAccessLogRepository(Data.ClayDbContext clayDb)
		{
			_clayDb = clayDb;
			dbUserAccessLog = clayDb.Set<Data.UserAccessLog>();
		}

		public async Task<List<Core.Entities.UserAccessLog>> GetAllLogs(int companyId)
		{
			List<Data.UserAccessLog> dbLogs = await dbUserAccessLog.Where(x => x.CompanyId == companyId).ToListAsync();
			List<Core.Entities.UserAccessLog> logs = new List<Core.Entities.UserAccessLog>();
			dbLogs.ForEach(x => logs.Add(x.ToEntity()));
			return logs;
		}

		public async void InsertLog(Core.Entities.UserAccessLog inputLog)
		{
			Data.UserAccessLog newLog = Data.UserAccessLog.ToData(inputLog);
			await dbUserAccessLog.AddAsync(newLog);
			_clayDb.SaveChanges();
		}

	}
}
