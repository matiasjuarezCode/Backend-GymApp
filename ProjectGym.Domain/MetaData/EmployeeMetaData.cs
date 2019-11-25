using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectGym.Domain.Entities;

namespace ProjectGym.Domain.MetaData
{
    public class EmployeeMetaData : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Legacy)
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

            builder.Property(x => x.Username)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
