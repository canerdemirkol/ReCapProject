using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class MapKeyConfiguration : IEntityTypeConfiguration<MAP_KEY>
    {
        public void Configure(EntityTypeBuilder<MAP_KEY> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            builder.ToTable("MAP_KEY");
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.MAP_API_KEY).HasColumnName("MAP_API_KEY");
        }
    }
}
