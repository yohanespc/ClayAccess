using ClayAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Core.Interfaces
{
	public interface IUserRepo
	{
		User GetUserByNamePassword(string email, string password);

	}
}
