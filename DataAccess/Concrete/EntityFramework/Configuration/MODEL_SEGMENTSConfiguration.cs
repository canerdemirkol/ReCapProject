using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configuration
{
    public class MODEL_SEGMENTConfiguration : IEntityTypeConfiguration<MODEL_SEGMENT>
    {
        public void Configure(EntityTypeBuilder<MODEL_SEGMENT> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.ToTable("MODEL_SEGMENTS");
        }
    }
}
