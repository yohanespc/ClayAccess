using System;

namespace ClayAccess.Core.Entities
{
	public class User
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int ProfileId { get; set; }
		public DateTime LastLogin { get; set; }
		public DateTime ValidFrom { get; set; }
		public DateTime? ValidUntil { get; set; }

		public User() { }
	}
}
