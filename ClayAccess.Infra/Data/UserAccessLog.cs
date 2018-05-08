using System;
using System.ComponentModel.DataAnnotations;

namespace ClayAccess.Infra.Data
{
	public class UserAccessLog
	{
		[Key]
		public int UserAccessLogId { get; set; }
		public int UserId { get; set; }
		public int ProfileId { get; set; }
		public int CompanyId { get; set; }
		public int DoorId { get; set; }
		public DateTime RequestedAccess { get; set; }
		public bool Access { get; set; }
		public Core.Entities.UserAccessLog ToEntity() // ToDo: use automapper
		{
			return new Core.Entities.UserAccessLog()
			{
				UserAccessLogId = this.UserAccessLogId,
				UserId = this.UserId,
				ProfileId = this.ProfileId,
				CompanyId = this.CompanyId,
				DoorId = this.DoorId,
				RequestedAccess = this.RequestedAccess,
				Access = this.Access
			};
		}

		public static Data.UserAccessLog ToData(Core.Entities.UserAccessLog log) // ToDo: use automapper
		{
			return new Data.UserAccessLog()
			{
				UserAccessLogId = log.UserAccessLogId,
				UserId = log.UserId,
				ProfileId = log.ProfileId,
				CompanyId = log.CompanyId,
				DoorId = log.DoorId,
				RequestedAccess = log.RequestedAccess,
				Access = log.Access
			};
		}



	}
}
