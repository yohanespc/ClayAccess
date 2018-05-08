namespace ClayAccess.Core.Entities
{
	public class ProfileAccess
	{
		public int ProfileAccessId { get; set; }
		public int ProfileId { get; set; }
		public int DoorId { get; set; }
		public bool EntryAccess { get; set; }
		public ProfileAccess() { }
	}
}
