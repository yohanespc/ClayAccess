using ClayAccess.Infra.Data.Map;
using Microsoft.EntityFrameworkCore;

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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			new UserMap(modelBuilder.Entity<User>());
			new DoorMap(modelBuilder.Entity<Door>());
			new ProfileAccessMap(modelBuilder.Entity<ProfileAccess>());
			new ProfileMap(modelBuilder.Entity<Profile>());

		}
	}
}
