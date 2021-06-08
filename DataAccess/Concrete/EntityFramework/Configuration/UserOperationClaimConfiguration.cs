using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            builder.ToTable("UserOperationClaims");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.UserId).HasColumnName("UserId");
            builder.Property(t => t.OperationClaimId).HasColumnName("OperationClaimId");
        }
    }
}
