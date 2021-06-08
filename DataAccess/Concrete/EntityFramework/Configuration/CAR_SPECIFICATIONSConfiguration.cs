using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{

    public class CAR_SPECIFICATIONConfiguration : IEntityTypeConfiguration<CAR_SPECIFICATION>
    {
        public void Configure(EntityTypeBuilder<CAR_SPECIFICATION> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();           
            builder.ToTable("CAR_SPECIFICATIONS");
        }


    }
}
