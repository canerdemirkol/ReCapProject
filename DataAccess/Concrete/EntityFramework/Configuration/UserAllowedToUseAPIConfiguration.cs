using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class UserAllowedToUseAPIConfiguration : IEntityTypeConfiguration<UserAllowedToUseAPI>
    {
        public void Configure(EntityTypeBuilder<UserAllowedToUseAPI> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("UsersAllowedToUseAPI");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.Email).HasColumnName("Email");
            builder.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
