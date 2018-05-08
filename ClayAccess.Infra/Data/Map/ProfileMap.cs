using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Infra.Data.Map
{
	public class ProfileMap
	{
		public ProfileMap(EntityTypeBuilder<Profile> entityBuilder)
		{
			entityBuilder.HasKey(t => t.ProfielId);
			entityBuilder.Property(t => t.CompanyId).IsRequired();
			entityBuilder.Property(t => t.Name).IsRequired();
		}
	}
}
