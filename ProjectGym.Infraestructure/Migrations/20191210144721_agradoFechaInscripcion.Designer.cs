﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectGym.Infraestructure;

namespace ProjectGym.Infraestructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191210144721_agradoFechaInscripcion")]
    partial class agradoFechaInscripcion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectGym.Domain.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("DateAdmission");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("MembershipNumber");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ProjectGym.Domain.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Legacy");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProjectGym.Domain.Entities.Inscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CustomerId");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<DateTime>("InscriptionDate");

                    b.Property<bool>("IsDelete");

                    b.Property<long>("PlanId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PlanId");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("ProjectGym.Domain.Entities.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("InscriptionId");

                    b.Property<bool>("IsDelete");

                    b.Property<decimal>("Money");

                    b.Property<DateTime>("PaymentDate");

                    b.HasKey("Id");

                    b.HasIndex("InscriptionId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ProjectGym.Domain.Entities.Plan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("IsDelete");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("ProjectGym.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<decimal>("CostPrice");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("DiscountStock");

                    b.Property<bool>("IsDelete");

                    b.Property<bool>("NegativeStock");

                    b.Property<decimal>("SalePrice")
                        .HasMaxLength(200);

                    b.Property<int>("Stock");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProjectGym.Domain.Entities.Inscription", b =>
                {
                    b.HasOne("ProjectGym.Domain.Entities.Customer", "Customer")
                        .WithMany("Inscriptions")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Inscription_Customer")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectGym.Domain.Entities.Plan", "Plan")
                        .WithMany("Inscriptions")
                        .HasForeignKey("PlanId")
                        .HasConstraintName("FK_Inscription_Plan")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectGym.Domain.Entities.Payment", b =>
                {
                    b.HasOne("ProjectGym.Domain.Entities.Inscription", "Inscription")
                        .WithMany("Payments")
                        .HasForeignKey("InscriptionId")
                        .HasConstraintName("FK_Payment_Inscription")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
