using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.MetaData
{
    public class PaymentMetaData : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.InscriptionId)
                .IsRequired();

            builder.Property(x => x.Money)
               .IsRequired();

            builder.Property(x => x.PaymentDate)
               .IsRequired();
        }
    }
}
