using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class IlConfiguration : IEntityTypeConfiguration<IL>
    {
        public void Configure(EntityTypeBuilder<IL> builder)
        {
            builder.HasKey(t => t.IL_KODU);


            builder.Property(t => t.IL_ADI)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("ILLER");
            builder.Property(t => t.IL_KODU).HasColumnName("IL_KODU");
            builder.Property(t => t.IL_ADI).HasColumnName("IL_ADI");
            builder.Property(t => t.DURUM).HasColumnName("DURUM");
        }


    }
}
