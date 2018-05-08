using ClayAccess.Api.Misc;
using ClayAccess.Api.Models;
using ClayAccess.Core.Entities;
using ClayAccess.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static ClayAccess.Core.Misc.Enum;

namespace ClayAccess.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/User")]
	public class UserController : Controller
	{
		protected IAccessService _accessService;
		private IConfiguration _config;

		public UserController(IConfiguration config, IAccessService accessService)
		{
			_config = config;
			_accessService = accessService;
		}

		[HttpGet]
		[Route("GetAllUsers")]
		public async Task<IActionResult> GetAllUsers() => new OkObjectResult(await _accessService.GetAllUsers());

		[HttpGet, Authorize]
		[Route("RequestFrontGateOpen")]
		public IActionResult RequestFrontGateOpen()
		{
			var currentUser = HttpContext.User;
			if (currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier)) // profile
			{
				UserProfile profile = (UserProfile)int.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
			}
			return Ok();
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("CreateUserToken")]
		public IActionResult CreateUserToken([FromBody]UserLoginModel login)
		{
			IActionResult response = Unauthorized();
			Tuple<bool, User> userAuthorized = _accessService.AuthenticateUser(login.Email, login.Password);

			if (userAuthorized.Item1)
			{
				string tokenString = new UserToken(_config).BuildToken(userAuthorized.Item2);
				response = Ok(new { token = tokenString });
			}

			return response;
		}

	}
}