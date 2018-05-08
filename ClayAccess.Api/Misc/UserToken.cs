using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClayAccess.Api.Misc
{
	public class UserToken
	{
		private readonly IConfiguration _config;

		public UserToken(IConfiguration config)
		{
			_config = config;
		}

		public string BuildToken(Core.Entities.User user)
		{
			var claims = new[] {
				new Claim(JwtRegisteredClaimNames.NameId, user.UserId.ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.Name.ToString()),
				new Claim(JwtRegisteredClaimNames.Actort, user.ProfileId.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims: claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: creds);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
