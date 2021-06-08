using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class MODELConfiguration : IEntityTypeConfiguration<MODEL>
    {
        public void Configure(EntityTypeBuilder<MODEL> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.NAME).IsRequired().HasMaxLength(250).HasColumnName("NAME");
            builder.Property(x => x.DATE_OF_REGISTRATION).IsRequired().HasColumnType("datetime").HasDefaultValueSql("getdate()").HasColumnName("DATE_OF_REGISTRATION");
            builder.Property(x => x.STATUS).HasColumnType("bit").HasDefaultValue(true).HasColumnName("STATUS");
            builder.Property(x => x.DATE_OF_UPDATE).HasColumnType("datetime").HasColumnName("DATE_OF_UPDATE");
            builder.ToTable("MODELS");
        }

    
    }
}
