using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class CAR_STATUSConfiguration : IEntityTypeConfiguration<CAR_STATUS>
    {
        public void Configure(EntityTypeBuilder<CAR_STATUS> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.NAME).IsRequired().HasMaxLength(250).HasColumnName("NAME");
            builder.ToTable("CAR_STATUS");
        }
    }
}
