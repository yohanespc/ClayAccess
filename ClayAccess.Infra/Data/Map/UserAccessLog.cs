using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClayAccess.Infra.Data.Map
{
	public class UserAccessLogMap
	{
		public UserAccessLogMap(EntityTypeBuilder<UserAccessLog> entityBuilder)
		{
			entityBuilder.HasKey(t => t.UserAccessLogId);
			entityBuilder.Property(t => t.UserId).IsRequired();
			entityBuilder.Property(t => t.ProfileId).IsRequired();
			entityBuilder.Property(t => t.CompanyId).IsRequired();
			entityBuilder.Property(t => t.DoorId).IsRequired();
			entityBuilder.Property(t => t.RequestedAccess).IsRequired();
			entityBuilder.Property(t => t.Access).IsRequired();
		}
	}
}
