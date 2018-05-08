using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClayAccess.Infra.Data
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Profile { get; set; }
		public DateTime ValidFrom { get; set; }
		public DateTime? ValidUntil { get; set; }

		public User() { }

		public Core.Entities.User ToUserEntity() // ToDo: use automapper
		{
			return new Core.Entities.User()
			{
				UserId = this.UserId,
				Email = this.Email,
				Name = this.Name,
				Password = this.Password,
				Profile = this.Profile,
				ValidFrom = this.ValidFrom,
				ValidUntil = this.ValidUntil
			};
		}

	}
}
