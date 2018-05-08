using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayAccess.Infra.Data.Map
{
	public class DoorMap
	{
		public DoorMap(EntityTypeBuilder<Door> entityBuilder)
		{
			entityBuilder.HasKey(t => t.DoorId);
			entityBuilder.Property(t => t.Name).IsRequired();
			entityBuilder.Property(t => t.CompanyId).IsRequired();
		}
	}
}
