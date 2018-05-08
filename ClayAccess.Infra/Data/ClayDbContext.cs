using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Infra.Data
{
	public class ClayDbContext : DbContext
	{
		public ClayDbContext()
		{
		}

		public ClayDbContext(DbContextOptions<ClayDbContext> options) : base(options)
		{
		}

		//public DbSet<User> User { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			new UserMap(modelBuilder.Entity<User>());
		}
	}
}
