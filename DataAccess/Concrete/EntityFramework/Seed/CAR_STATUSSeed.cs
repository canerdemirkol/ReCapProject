using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Seed
{
   

    public class CAR_STATUSSeed : IEntityTypeConfiguration<CAR_STATUS>
    {
        public void Configure(EntityTypeBuilder<CAR_STATUS> builder)
        {
            builder.HasData(
                new CAR_STATUS { ID = 1, NAME = "Sıfır" },
                new CAR_STATUS { ID = 2, NAME = "İkinci El" });
        }
    }
}
