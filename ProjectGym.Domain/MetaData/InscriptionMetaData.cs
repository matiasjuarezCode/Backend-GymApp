using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.MetaData
{
    public class InscriptionMetaData : IEntityTypeConfiguration<Inscription>
    {
        public void Configure(EntityTypeBuilder<Inscription> builder)
        {
            builder.Property(x => x.CustomerId)
               .IsRequired();

            builder.Property(x => x.ExpirationDate)
               .IsRequired();

            builder.Property(x => x.InscriptionDate)
              .IsRequired();

            builder.Property(x => x.PlanId)
              .IsRequired();
        }
    }
}
