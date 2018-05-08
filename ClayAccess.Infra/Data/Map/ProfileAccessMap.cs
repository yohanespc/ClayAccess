using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Infra.Data.Map
{
	public class ProfileAccessMap
	{
		public ProfileAccessMap(EntityTypeBuilder<ProfileAccess> entityBuilder)
		{
			entityBuilder.HasKey(t => t.ProfileAccessId);
			entityBuilder.Property(t => t.ProfileId).IsRequired();
			entityBuilder.Property(t => t.DoorId).IsRequired();
			entityBuilder.Property(t => t.EntryAccess).IsRequired();
		}
	}
}
