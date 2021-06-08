using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Seed
{


    public class CATEGORYSeed : IEntityTypeConfiguration<CATEGORY>
    {
        public void Configure(EntityTypeBuilder<CATEGORY> builder)
        {
            builder.HasData(
                new CATEGORY { ID = 1, NAME = "Otomobil", STATUS = true },
                new CATEGORY { ID = 2, NAME = "Arazi, SUV & Pickup", STATUS = true },
                new CATEGORY { ID = 3, NAME = "Motosiklet", STATUS = true },
                new CATEGORY { ID = 4, NAME = "Minivan & Panelvan", STATUS = true },
                new CATEGORY { ID = 5, NAME = "Ticari Araçlar", STATUS = true },
                new CATEGORY { ID = 6, NAME = "Elektrikli Araçlar", STATUS = true });
        }
    }
}
