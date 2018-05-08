using System.ComponentModel.DataAnnotations;

namespace ClayAccess.Infra.Data
{
	public class Door
	{
		[Key]
		public int DoorId { get; set; }
		public int CompanyId { get; set; }
		public string Name { get; set; }

		public Door() { }

		public Core.Entities.Door ToEntity() // ToDo: use automapper
		{
			return new Core.Entities.Door()
			{
				DoorId = this.DoorId,
				CompanyId = this.CompanyId,
				Name = this.Name
			};
		}

	}
}
