using ClayAccess.Core.Entities;
using ClayAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Core.Services
{
	public class UserService
	{
		private readonly IUserRepo _userRepo;

		public UserService(IUserRepo userRepo)
		{
			this._userRepo = userRepo;
		}

		public void GetUserByEmailPass(string email, string password)
		{
			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException();

		}
	}
}
