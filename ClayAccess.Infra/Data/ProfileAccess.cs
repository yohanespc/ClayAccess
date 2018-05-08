using System.ComponentModel.DataAnnotations;

namespace ClayAccess.Infra.Data
{
	public class ProfileAccess
	{
		[Key]
		public int ProfileAccessId { get; set; }
		public int ProfileId { get; set; }
		public int DoorId { get; set; }
		public bool EntryAccess { get; set; }

		public Core.Entities.ProfileAccess ToEntity() // ToDo: use automapper
		{
			return new Core.Entities.ProfileAccess()
			{
				ProfileAccessId = this.ProfileAccessId,
				ProfileId = this.ProfileId,
				DoorId = this.DoorId,
				EntryAccess = this.EntryAccess
			};
		}

	}
}
