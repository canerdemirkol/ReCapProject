using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Concrete.EntityFramework.Configuration
{

    public class AdresTipConfiguration : IEntityTypeConfiguration<ADRES_TIP>
    {
        public void Configure(EntityTypeBuilder<ADRES_TIP> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.TIP_ADI)
                .HasMaxLength(150);

            // Table & Column Mappings           
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.TIP_ADI).HasColumnName("TIP_ADI");
            builder.ToTable("ADRES_TIPLERI");
        }


    }
}
