using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class ENGINE_CAPACITIEConfiguration : IEntityTypeConfiguration<ENGINE_CAPACITIE>
    {
        public void Configure(EntityTypeBuilder<ENGINE_CAPACITIE> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.NAME).IsRequired().HasMaxLength(250).HasColumnName("NAME");
            builder.ToTable("ENGINE_CAPACITIES");
        }
    }
}
