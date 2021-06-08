using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class MobileAppVersionConfiguration : IEntityTypeConfiguration<MOBILE_APP_VERSION>
    {
        public void Configure(EntityTypeBuilder<MOBILE_APP_VERSION> builder)
        {
            // Primary Key
            builder.HasKey(t => t.version_id);

            // Properties
            builder.Property(t => t.version)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("MOBILE_APP_VERSION");
            builder.Property(t => t.version_id).HasColumnName("version_id");
            builder.Property(t => t.version).HasColumnName("version");
            builder.Property(t => t.eklenme_tarihi).HasColumnName("eklenme_tarihi");
            builder.Property(t => t.durum).HasColumnName("durum");
        }
    }
}
