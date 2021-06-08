using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class TIRE_SIZEConfiguration : IEntityTypeConfiguration<TIRE_SIZE>
    {
        public void Configure(EntityTypeBuilder<TIRE_SIZE> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.SIZE).IsRequired().HasMaxLength(50).HasColumnName("SIZE");
            builder.ToTable("TIRE_SIZES");
        }

    
    }
}
