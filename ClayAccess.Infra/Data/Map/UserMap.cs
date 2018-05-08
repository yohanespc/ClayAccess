using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Infra.Data.Map
{
	public class UserMap
	{
		public UserMap(EntityTypeBuilder<User> entityBuilder)
		{
			entityBuilder.HasKey(t => t.UserId);
			entityBuilder.Property(t => t.Email).IsRequired();
			entityBuilder.Property(t => t.Password).IsRequired();
			entityBuilder.Property(t => t.Name).IsRequired();
			entityBuilder.Property(t => t.ProfileId).IsRequired();
			entityBuilder.Property(t => t.LastLogin).IsRequired();
			entityBuilder.Property(t => t.ValidFrom).IsRequired();
			entityBuilder.Property(t => t.ValidUntil);
		}
	}
}
