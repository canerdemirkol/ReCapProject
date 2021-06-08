using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class SistemOnayKodKontrolConfiguration : IEntityTypeConfiguration<SISTEM_ONAY_KOD_KONTROL>
    {
        public void Configure(EntityTypeBuilder<SISTEM_ONAY_KOD_KONTROL> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.HESAP)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            builder.ToTable("SISTEM_ONAY_KOD_KONTROL");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.FK_ILETISIM_TIP).HasColumnName("FK_ILETISIM_TIP");
            builder.Property(t => t.HESAP).HasColumnName("HESAP");
            builder.Property(t => t.ONAY_KODU).HasColumnName("ONAY_KODU");
            builder.Property(t => t.ONAY_KODU_HATALI_GIRIS).HasColumnName("ONAY_KODU_HATALI_GIRIS");
            builder.Property(t => t.ONAY_KODU_KONTROL).HasColumnName("ONAY_KODU_KONTROL");
            builder.Property(t => t.KAYIT_TARIH).HasColumnName("KAYIT_TARIH");
            builder.Property(t => t.GIRIS_TARIH).HasColumnName("GIRIS_TARIH");
        }
    }
}
