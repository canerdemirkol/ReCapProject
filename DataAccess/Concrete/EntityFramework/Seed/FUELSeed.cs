using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Seed
{

    public class FUELSeed : IEntityTypeConfiguration<FUEL>
    {
        public void Configure(EntityTypeBuilder<FUEL> builder)
        {
            builder.HasData(
                new FUEL { ID = 1, NAME = "Benzin" },
                new FUEL { ID = 2, NAME = "Benzin & LPG" },
                new FUEL { ID = 3, NAME = "Dizel" },
                new FUEL { ID = 4, NAME = "Hybrid" },
                new FUEL { ID = 5, NAME = "Elektrik" });
        }
    }
}
