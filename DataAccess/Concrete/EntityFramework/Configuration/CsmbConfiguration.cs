using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class CsmbConfiguration : IEntityTypeConfiguration<CSBM>
    {
        public void Configure(EntityTypeBuilder<CSBM> builder)
        {
            // Primary Key
            builder.HasKey(t => t.CSBM_KODU);


            builder.Property(t => t.CSBM_ADI)
                .HasMaxLength(150);

            builder.Property(t => t.CSBM_TIP)
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("CSBM");
            builder.Property(t => t.CSBM_KODU).HasColumnName("CSBM_KODU");
            builder.Property(t => t.CSBM_ADI).HasColumnName("CSBM_ADI");
            builder.Property(t => t.MAHALLE_KODU).HasColumnName("MAHALLE_KODU");
            builder.Property(t => t.CSBM_TIP).HasColumnName("CSBM_TIP");

        }

    }
}
