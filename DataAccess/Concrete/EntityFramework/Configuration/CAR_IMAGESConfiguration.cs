using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class CAR_IMAGESConfiguration : IEntityTypeConfiguration<CAR_IMAGE>
    {
        public void Configure(EntityTypeBuilder<CAR_IMAGE> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.IMAGE_PATH).HasColumnName("IMAGE_PATH");
            builder.Property(x => x.DATE_OF_REGISTRATION).IsRequired().HasColumnType("datetime").HasDefaultValueSql("getdate()").HasColumnName("DATE_OF_REGISTRATION");
            builder.ToTable("CAR_IMAGES");
        }
    }

}
