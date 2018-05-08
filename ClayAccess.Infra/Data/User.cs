using System;
using System.ComponentModel.DataAnnotations;

namespace ClayAccess.Infra.Data
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int ProfileId { get; set; }
		public DateTime LastLogin { get; set; }
		public DateTime ValidFrom { get; set; }
		public DateTime? ValidUntil { get; set; }

		public User() { }

		public Core.Entities.User ToEntity() // ToDo: use automapper
		{
			return new Core.Entities.User()
			{
				UserId = this.UserId,
				Email = this.Email,
				Name = this.Name,
				Password = this.Password,
				ProfileId = this.ProfileId,
				LastLogin = this.LastLogin,
				ValidFrom = this.ValidFrom,
				ValidUntil = this.ValidUntil
			};
		}

	}
}
