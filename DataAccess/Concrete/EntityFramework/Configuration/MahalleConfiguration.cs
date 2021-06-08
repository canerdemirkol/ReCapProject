using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class MahalleConfiguration : IEntityTypeConfiguration<MAHALLE>
    {
        public void Configure(EntityTypeBuilder<MAHALLE> builder)
        {
            // Primary Key
            builder.HasKey(t => t.MAHALLE_KODU);

            builder.Property(t => t.MAHALLE_ADI)
                .HasMaxLength(150);

            // Table & Column Mappings
            builder.ToTable("MAHALLELER");
            builder.Property(t => t.MAHALLE_KODU).HasColumnName("MAHALLE_KODU");
            builder.Property(t => t.MAHALLE_ADI).HasColumnName("MAHALLE_ADI");
            builder.Property(t => t.ILCE_KODU).HasColumnName("ILCE_KODU");
        }
    }
}
