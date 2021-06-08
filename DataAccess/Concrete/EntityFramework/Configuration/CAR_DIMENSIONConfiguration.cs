using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{

    public class CAR_DIMENSIONConfiguration : IEntityTypeConfiguration<CAR_DIMENSION>
    {
        public void Configure(EntityTypeBuilder<CAR_DIMENSION> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.NUMBER_OF_SEATS).HasColumnName("NUMBER_OF_SEATS");
            builder.Property(x => x.LENGTH).HasColumnName("LENGTH");
            builder.Property(x => x.WIDTH).HasColumnName("WIDTH");
            builder.Property(x => x.HEIGHT).HasColumnName("HEIGHT");
            builder.Property(x => x.NET_WEIGHT).HasColumnName("NET_WEIGHT");
            builder.Property(x => x.CAPACITY).HasColumnName("CAPACITY");
            builder.Property(x => x.LUGGAGE_CAPACITY).HasColumnName("LUGGAGE_CAPACITY");
            builder.ToTable("CAR_DIMENSIONS");
    }


    }
}
