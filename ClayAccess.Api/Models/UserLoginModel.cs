using System.ComponentModel.DataAnnotations;

namespace ClayAccess.Api.Models
{
	public class UserLoginModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
