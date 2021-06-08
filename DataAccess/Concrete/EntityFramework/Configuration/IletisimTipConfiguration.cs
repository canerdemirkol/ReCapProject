using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class IletisimTipConfiguration : IEntityTypeConfiguration<ILETISIM_TIP>
    {
        public void Configure(EntityTypeBuilder<ILETISIM_TIP> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.TIP_ADI)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("ILETISIM_TIPLERI");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.TIP_ADI).HasColumnName("TIP_ADI");

        }
    }
}
