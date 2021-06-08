using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class CATEGORYConfiguration : IEntityTypeConfiguration<CATEGORY>
    {
        public void Configure(EntityTypeBuilder<CATEGORY> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.NAME).IsRequired().HasMaxLength(250).HasColumnName("NAME");
            builder.Property(x => x.STATUS).HasColumnType("bit").HasDefaultValue(true).HasColumnName("STATUS");
            builder.ToTable("CATEGORIES");
        }    
    }
}
