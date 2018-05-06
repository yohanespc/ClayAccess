using ClayAccess.Core.Entities;
using ClayAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Infra.Repositories
{
	public class UserRepository : IUserRepo
	{
		public User GetUserByNamePassword(string email, string password)
		{
			throw new NotImplementedException();
		}
	}
}
