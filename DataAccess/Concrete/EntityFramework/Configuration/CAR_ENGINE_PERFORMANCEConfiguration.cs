using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
  

    public class CAR_ENGINE_PERFORMANCEConfiguration : IEntityTypeConfiguration<CAR_ENGINE_PERFORMANCE>
    {
        public void Configure(EntityTypeBuilder<CAR_ENGINE_PERFORMANCE> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.MAX_POWER).IsRequired().HasMaxLength(50).HasColumnName("MAX_POWER");
            builder.Property(x => x.MAX_TORQUE).HasMaxLength(50).HasColumnName("MAX_TORQUE");
            builder.Property(x => x.SPEED_LIMIT).HasMaxLength(50).HasColumnName("SPEED_LIMIT");       
            builder.ToTable("CAR_ENGINE_PERFORMANCES");
        }


    }
}
