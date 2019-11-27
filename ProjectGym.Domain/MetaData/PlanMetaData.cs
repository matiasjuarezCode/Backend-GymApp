using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectGym.Domain.Entities;

namespace ProjectGym.Domain.MetaData
{
    public class PlanMetaData : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();
        }
    }
}
