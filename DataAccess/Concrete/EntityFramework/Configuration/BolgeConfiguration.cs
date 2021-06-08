using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class BolgeConfiguration : IEntityTypeConfiguration<BOLGE>
    {
        public void Configure(EntityTypeBuilder<BOLGE> builder)
        {
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.BOLGE_ADI)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            builder.ToTable("BOLGELER");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.BOLGE_ADI).HasColumnName("BOLGE_ADI");
            builder.Property(t => t.DURUM).HasColumnName("DURUM");
        }

    }
}
