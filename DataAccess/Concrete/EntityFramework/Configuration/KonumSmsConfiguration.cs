using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class KurumSmsConfiguration : IEntityTypeConfiguration<KURUM_SMS>
    {
        public void Configure(EntityTypeBuilder<KURUM_SMS> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.USERNAME)
                .HasMaxLength(50);

            builder.Property(t => t.PASSWORD)
                .HasMaxLength(50);

            builder.Property(t => t.COMPANY)
                .HasMaxLength(50);

            builder.Property(t => t.HEADER)
                .HasMaxLength(50);

            builder.Property(t => t.LANGUAGE)
                .HasMaxLength(50);

            builder.Property(t => t.BAYI_KODU)
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("KURUM_SMS");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.KURUM_ID).HasColumnName("KURUM_ID");
            builder.Property(t => t.USERNAME).HasColumnName("USERNAME");
            builder.Property(t => t.PASSWORD).HasColumnName("PASSWORD");
            builder.Property(t => t.COMPANY).HasColumnName("COMPANY");
            builder.Property(t => t.HEADER).HasColumnName("HEADER");
            builder.Property(t => t.DATE).HasColumnName("DATE");
            builder.Property(t => t.END_DATE).HasColumnName("END_DATE");
            builder.Property(t => t.LANGUAGE).HasColumnName("LANGUAGE");
            builder.Property(t => t.STOP_DATE).HasColumnName("STOP_DATE");
            builder.Property(t => t.BAYI_KODU).HasColumnName("BAYI_KODU");
            builder.Property(t => t.DURUM).HasColumnName("DURUM");
            builder.Property(t => t.KAYIT_TARIHI).HasColumnName("KAYIT_TARIHI");
            builder.Property(t => t.ISLEM_YAPAN_USER).HasColumnName("ISLEM_YAPAN_USER");
            builder.Property(t => t.GUNCELLEME_TARIHI).HasColumnName("GUNCELLEME_TARIHI");
            builder.Property(t => t.GUNCELLEYEN_ID).HasColumnName("GUNCELLEYEN_ID");
        }
    }
}
