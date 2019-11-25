using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.MetaData
{
    public class CustomerMetaData : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.MembershipNumber)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Adress)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.DateAdmission)
                .IsRequired();
        }
    }
}
