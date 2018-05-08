using System.Linq;
using System.Security.Claims;

namespace ClayAccess.Api.Models
{
	public class AuthorizedUserModel
	{
		public int UserId { get; set; }
		public int ProfileId { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }

		public AuthorizedUserModel(ClaimsPrincipal httpUser)
		{
			if (httpUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier)) // JwtRegisteredClaimNames.Sub
			{
				UserId = int.Parse(httpUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value); //ToDo implement better validation
			}
			if (httpUser.HasClaim(c => c.Type == ClaimTypes.Actor)) // JwtRegisteredClaimNames.Sub
			{
				ProfileId = int.Parse(httpUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor).Value); //ToDo implement better validation
			}
			if (httpUser.HasClaim(c => c.Type == ClaimTypes.Email)) // JwtRegisteredClaimNames.Email
			{
				Email = httpUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
			}
			if (httpUser.HasClaim(c => c.Type == ClaimTypes.Name)) // JwtRegisteredClaimNames.Email
			{
				Name = httpUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
			}
		}

	}
}
