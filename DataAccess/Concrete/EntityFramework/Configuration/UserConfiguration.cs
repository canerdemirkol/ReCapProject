using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(t => t.PasswordSalt)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            builder.ToTable("Users");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.FirstName).HasColumnName("FirstName");
            builder.Property(t => t.LastName).HasColumnName("LastName");
            builder.Property(t => t.Email).HasColumnName("Email");
            builder.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
