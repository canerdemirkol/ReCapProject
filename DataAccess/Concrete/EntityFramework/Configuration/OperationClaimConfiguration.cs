using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            builder.ToTable("OperationClaims");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
