using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Infra.Data
{
	public class ClayDb : DbContext
	{
		public ClayDb()
		{
		}

		public ClayDb(DbContextOptions<ClayDb> options) : base(options)
		{
		}

	}
}
