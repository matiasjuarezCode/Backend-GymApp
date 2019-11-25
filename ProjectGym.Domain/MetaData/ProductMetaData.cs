using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.MetaData
{
    public class ProductMetaData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Code)
               .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.CostPrice)
              .IsRequired();

            builder.Property(x => x.SalePrice)
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.Stock)
              .IsRequired();

            builder.Property(x => x.DiscountStock)
              .IsRequired();

            builder.Property(x => x.NegativeStock)
              .IsRequired();

        }
    }
}
