using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class KonumRequestConfiguration : IEntityTypeConfiguration<KONUM_REQUEST>
    {
        public void Configure(EntityTypeBuilder<KONUM_REQUEST> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.IL)
                .HasMaxLength(50);

            builder.Property(t => t.ILCE)
                .HasMaxLength(50);

            builder.Property(t => t.MAHALLE)
                .HasMaxLength(50);

            builder.Property(t => t.CSBM)
                .HasMaxLength(50);

            builder.Property(t => t.BINA_ADI)
                .HasMaxLength(100);

            builder.Property(t => t.BINA_NO)
                .HasMaxLength(100);

            builder.Property(t => t.MEVKI)
                .HasMaxLength(250);

            builder.Property(t => t.LAT_LNG)
                .HasMaxLength(50);

            builder.Property(t => t.LAT)
                .HasMaxLength(50);

            builder.Property(t => t.LNG)
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("KONUM_REQUEST");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.IL).HasColumnName("IL");
            builder.Property(t => t.ILCE).HasColumnName("ILCE");
            builder.Property(t => t.MAHALLE).HasColumnName("MAHALLE");
            builder.Property(t => t.CSBM).HasColumnName("CSBM");
            builder.Property(t => t.BINA_ADI).HasColumnName("BINA_ADI");
            builder.Property(t => t.BINA_NO).HasColumnName("BINA_NO");
            builder.Property(t => t.MEVKI).HasColumnName("MEVKI");
            builder.Property(t => t.LAT_LNG).HasColumnName("LAT_LNG");
            builder.Property(t => t.LAT).HasColumnName("LAT");
            builder.Property(t => t.LNG).HasColumnName("LNG");
        }
    }
}
