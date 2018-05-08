using ClayAccess.Api.Misc;
using ClayAccess.Api.Models;
using ClayAccess.Core.Entities;
using ClayAccess.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

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

		[HttpGet]
		[Route("GetLogs")]
		public async Task<IActionResult> GetLogs() => new OkObjectResult(await _accessService.GetLogsByCompanyId(1));

		[HttpGet, Authorize]
		[Route("RequestFrontGateAccess")]
		public async Task<IActionResult> RequestFrontGateAccess()
		{
			bool grantAccess = false;
			AuthorizedUserModel authUser = new AuthorizedUserModel(HttpContext.User);
			if (authUser != null && authUser.UserId > 0 && authUser.ProfileId > 0)
			{
				Door frontGate = await _accessService.GetDoorByCompanyIdName(1, Misc.Enum.Door.FrontGate.ToString());
				grantAccess = await _accessService.GetProfileAccess(authUser.ProfileId, frontGate.DoorId);
				_accessService.WriteAccessLog(grantAccess, frontGate.DoorId, authUser.ProfileId, authUser.UserId);
			}
			if (grantAccess)
				return Ok();
			return Unauthorized();
		}

		[HttpGet, Authorize]
		[Route("RequestMainMeetingRoomAccess")]
		public async Task<IActionResult> RequestMainMeetingRoomAccess()
		{
			bool grantAccess = false;
			AuthorizedUserModel authUser = new AuthorizedUserModel(HttpContext.User);
			if (authUser != null && authUser.UserId > 0 && authUser.ProfileId > 0)
			{
				Door mainMeetingRoom = await _accessService.GetDoorByCompanyIdName(1, Misc.Enum.Door.MainMeetingRoom.ToString());
				grantAccess = await _accessService.GetProfileAccess(authUser.ProfileId, mainMeetingRoom.DoorId);
				_accessService.WriteAccessLog(grantAccess, mainMeetingRoom.DoorId, authUser.ProfileId, authUser.UserId);
			}
			if (grantAccess)
				return Ok();
			return Unauthorized();
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