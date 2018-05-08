using System.ComponentModel.DataAnnotations;

namespace ClayAccess.Infra.Data
{
	public class Profile
    {
		[Key]
		public int ProfielId { get; set; }
		public int CompanyId { get; set; }
		public string Name { get; set; }
	}
}
