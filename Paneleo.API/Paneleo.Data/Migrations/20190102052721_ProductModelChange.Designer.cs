﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Paneleo.Data.DatabaseContext;

namespace Paneleo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190102052721_ProductModelChange")]
    partial class ProductModelChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Paneleo.Models.Model.Contractor.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatedById");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HouseNumber");

                    b.Property<bool>("IsCompany");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int?>("ModifiedById");

                    b.Property<string>("Name");

                    b.Property<string>("Nip");

                    b.Property<string>("Phone");

                    b.Property<string>("PostCity");

                    b.Property<string>("PostCode");

                    b.Property<string>("Street");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("Www");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("Paneleo.Models.Model.Order.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractorId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int?>("ModifiedById");

                    b.Property<string>("Name");

                    b.Property<string>("Place");

                    b.Property<double>("TotalCost");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Paneleo.Models.Model.Order.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int?>("ModifiedById");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<double>("Quantity");

                    b.Property<double>("TotalCost");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Paneleo.Models.Model.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int?>("ModifiedById");

                    b.Property<string>("Name");

                    b.Property<double>("PricePerUnit");

                    b.Property<double>("Quantity");

                    b.Property<string>("UnitOfMeasure");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Paneleo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Forename");

                    b.Property<string>("KnownAs");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PaswordHash");

                    b.Property<byte[]>("PaswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Paneleo.Models.Model.Contractor.Contractor", b =>
                {
                    b.HasOne("Paneleo.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Paneleo.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");
                });

            modelBuilder.Entity("Paneleo.Models.Model.Order.Order", b =>
                {
                    b.HasOne("Paneleo.Models.Model.Contractor.Contractor", "Contractor")
                        .WithMany("Orders")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Paneleo.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Paneleo.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");
                });

            modelBuilder.Entity("Paneleo.Models.Model.Order.OrderProduct", b =>
                {
                    b.HasOne("Paneleo.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Paneleo.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("Paneleo.Models.Model.Order.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Paneleo.Models.Model.Product.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Paneleo.Models.Model.Product.Product", b =>
                {
                    b.HasOne("Paneleo.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Paneleo.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");
                });
#pragma warning restore 612, 618
        }
    }
}
