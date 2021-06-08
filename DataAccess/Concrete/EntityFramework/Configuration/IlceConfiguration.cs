using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class IlceConfiguration : IEntityTypeConfiguration<ILCE>
    {
        public void Configure(EntityTypeBuilder<ILCE> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ILCE_KODU);

            builder.Property(t => t.ILCE_ADI)
                .HasMaxLength(250);

            // Table & Column Mappings
            builder.ToTable("ILCELER");
            builder.Property(t => t.ILCE_KODU).HasColumnName("ILCE_KODU");
            builder.Property(t => t.IL_KODU).HasColumnName("IL_KODU");
            builder.Property(t => t.ILCE_ADI).HasColumnName("ILCE_ADI");
            builder.Property(t => t.DURUM).HasColumnName("DURUM");

        }

    }
}
