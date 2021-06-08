using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
  

    public class CAR_FUEL_CONSUMPTIONConfiguration : IEntityTypeConfiguration<CAR_FUEL_CONSUMPTION>
    {
        public void Configure(EntityTypeBuilder<CAR_FUEL_CONSUMPTION> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.FUEL_TYPE).IsRequired().HasMaxLength(50).HasColumnName("FUEL_TYPE");
            builder.Property(x => x.INNER_CITY).HasColumnType("decimal(18,2)").HasColumnName("INNER_CITY");
            builder.Property(x => x.OUT_OF_TOWN).HasColumnType("decimal(18,2)").HasColumnName("OUT_OF_TOWN");
            builder.Property(x => x.AVERAGE).HasColumnType("decimal(18,2)").HasColumnName("AVERAGE");
            builder.ToTable("CAR_FUEL_CONSUMPTIONS");
        }


    }
}
