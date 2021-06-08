using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class CAR_DETAILConfiguration : IEntityTypeConfiguration<CAR_DETAIL>
    {
        public void Configure(EntityTypeBuilder<CAR_DETAIL> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.KM).HasColumnType("float").HasColumnName("KM");
            builder.Property(x => x.YEAR).HasColumnName("YEAR");
            builder.Property(x => x.PRICE).HasColumnType("decimal(18,3)").HasColumnName("PRICE");
            builder.Property(x => x.DALIY_PRICE).HasColumnType("decimal(18,3)").HasColumnName("DALIY_PRICE");
            builder.ToTable("CAR_DETAILS");
        }
    }
}
