using ClayAccess.Core.Entities;
using ClayAccess.Core.Interfaces;
using ClayAccess.Core.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ClayAccess.Tests
{
	public class AccessServiceTest
	{
		protected Mock<IUserRepository> _userRepo;
		protected Mock<IDoorRepository> _doorRepository;
		protected Mock<IProfileAccessRepository> _profileAccessRepository;
		protected Mock<IUserAccessLogRepository> _userAccessLog;
		protected Mock<IAccessService> _accessService;
		public AccessServiceTest()
		{
			_userRepo = new Mock<IUserRepository>();
			_doorRepository = new Mock<IDoorRepository>();
			_profileAccessRepository = new Mock<IProfileAccessRepository>();
			_userAccessLog = new Mock<IUserAccessLogRepository>();
		}

		private User CreateTestUser()
		{
			return new User()
			{
				Name = "Test",
				Email = "test@email.com",
				Password = "pass123",
				ProfileId = 1,
				UserId = 1
			};
		}

		[Fact(DisplayName = ("Access_AuthenticateUser"))]
		public void Access_AuthenticateUser()
		{
			User testUser = CreateTestUser();
			_userRepo.Setup(x => x.GetUserByEmailPassword(testUser.Email, testUser.Password)).Returns(Task.FromResult(testUser));
			AccessService service = new AccessService(_userRepo.Object, _doorRepository.Object, _profileAccessRepository.Object, _userAccessLog.Object);
			Tuple<bool, User> result = service.AuthenticateUser(testUser.Email, testUser.Password);

			Assert.NotNull(result.Item2);
			Assert.True(result.Item2.UserId > 0);
		}

	}
}
