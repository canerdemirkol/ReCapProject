using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class RENTALConfiguration : IEntityTypeConfiguration<RENTAL>
    {
        public void Configure(EntityTypeBuilder<RENTAL> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.RENT_DATE).HasColumnType("date").HasColumnName("RENT_DATE");
            builder.Property(x => x.RETURN_DATE).HasColumnType("date").HasColumnName("RETURN_DATE");
            builder.Property(x => x.DATE_OF_REGISTRATION).IsRequired().HasColumnType("datetime").HasDefaultValueSql("getdate()").HasColumnName("DATE_OF_REGISTRATION");
            builder.Property(x => x.TOTAL_PRICE).HasColumnType("decimal(18,3)").HasColumnName("TOTAL_PRICE");
            builder.ToTable("RENTALS");
        }
    }
}
