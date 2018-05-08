using System;

namespace ClayAccess.Core.Entities
{
	public class UserAccessLog
	{
		public int UserAccessLogId { get; set; }
		public int UserId { get; set; }
		public int ProfileId { get; set; }
		public int CompanyId { get; set; }
		public int DoorId { get; set; }
		public DateTime RequestedAccess { get; set; }
		public bool Access { get; set; }
		public UserAccessLog() { }
	}
}
