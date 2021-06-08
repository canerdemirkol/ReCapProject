using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class CUSTOMERConfiguration : IEntityTypeConfiguration<CUSTOMER>
    {
        public void Configure(EntityTypeBuilder<CUSTOMER> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.COMPANY_NAME).IsRequired().HasMaxLength(100).HasColumnName("COMPANY_NAME");
            builder.ToTable("CUSTOMERS");
        }
    }
}
