﻿// <auto-generated />
using System;
using ERPBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPBackend.Migrations
{
    [DbContext(typeof(ERPContext))]
    [Migration("20201111210325_FinalMigration")]
    partial class FinalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ERPBackend.Entities.Models.Additional.StandardOrderItemDetail", b =>
                {
                    b.Property<int>("StandardOrderItemDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MissingQuantity")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StandardOrderItemId")
                        .HasColumnType("int");

                    b.Property<int>("StandardProductId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StandardOrderItemDetailId");

                    b.HasIndex("StandardProductId");

                    b.ToTable("StandardOrderItemDetail");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "Słubice",
                            PostalCode = "69-100",
                            Street = "ul.Witosa 10"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "Poznań",
                            PostalCode = "61-222",
                            Street = "ul.Nowodworska 80"
                        },
                        new
                        {
                            AddressId = 3,
                            City = "Gorzów Wielkopolski",
                            PostalCode = "66-400",
                            Street = "al. Wojska Polskiego 33"
                        });
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12);

                    b.Property<int>("SalesmanId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ClientId");

                    b.HasIndex("AddressId");

                    b.HasIndex("SalesmanId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            AddressId = 1,
                            CompanyName = "Zakłady mięsne Stokłosa",
                            Email = "zm_stokolosa@mail.com",
                            FirstName = "Adam",
                            LastName = "Markowski",
                            PhoneNumber = "678234765",
                            SalesmanId = 2,
                            Status = "Active"
                        },
                        new
                        {
                            ClientId = 2,
                            AddressId = 2,
                            CompanyName = "Zakłady mięsne Solańscy",
                            Email = "zm_solanscy@mail.com",
                            FirstName = "Edward",
                            LastName = "Solański",
                            PhoneNumber = "978456723",
                            SalesmanId = 2,
                            Status = "Active"
                        },
                        new
                        {
                            ClientId = 3,
                            AddressId = 3,
                            CompanyName = "ZM Turowski",
                            Email = "zm_turowski@mail.com",
                            FirstName = "Piotr",
                            LastName = "Turowski",
                            PhoneNumber = "867544765",
                            SalesmanId = 2,
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.CustomOrderItem", b =>
                {
                    b.Property<int>("CustomOrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CustomProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductionManagerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProductionStartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomOrderItemId");

                    b.HasIndex("CustomProductId")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.ToTable("CustomOrderItems");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.CustomProduct", b =>
                {
                    b.Property<int>("CustomProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<string>("OrderDescription")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("PreparationCompletionDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("PreparationStartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("SolutionDescription")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TechnologistId")
                        .HasColumnType("int");

                    b.HasKey("CustomProductId");

                    b.HasIndex("TechnologistId");

                    b.ToTable("CustomProducts");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.FileItem", b =>
                {
                    b.Property<int>("FileItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BlobName")
                        .HasColumnType("text");

                    b.Property<int>("CustomProductId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FileItemId");

                    b.HasIndex("CustomProductId");

                    b.ToTable("FileItems");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.MaterialWarehouseItem", b =>
                {
                    b.Property<int>("MaterialWarehouseItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("MaterialWarehouseItemId");

                    b.HasIndex("MaterialId")
                        .IsUnique();

                    b.ToTable("MaterialWarehouse");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("PlacingDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("RealizationStartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SalesmanId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("WarehousemanId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ClientId");

                    b.HasIndex("SalesmanId");

                    b.HasIndex("WarehousemanId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.ProductWarehouseItem", b =>
                {
                    b.Property<int>("ProductWarehouseItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StandardProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductWarehouseItemId");

                    b.HasIndex("StandardProductId")
                        .IsUnique();

                    b.ToTable("ProductWarehouse");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.StandardOrderItem", b =>
                {
                    b.Property<int>("StandardOrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StandardProductId")
                        .HasColumnType("int");

                    b.HasKey("StandardOrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("StandardProductId");

                    b.ToTable("StandardOrderItems");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.StandardProduct", b =>
                {
                    b.Property<int>("StandardProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BlobName")
                        .HasColumnType("text");

                    b.Property<string>("Dimensions")
                        .HasColumnType("text");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasMaxLength(40);

                    b.Property<int>("StandardProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StandardProductId");

                    b.HasIndex("StandardProductCategoryId");

                    b.ToTable("StandardProducts");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.StandardProductCategory", b =>
                {
                    b.Property<int>("StandardProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("StandardProductCategoryId");

                    b.ToTable("StandardProductCategories");

                    b.HasData(
                        new
                        {
                            StandardProductCategoryId = 1,
                            Name = "Nóż"
                        },
                        new
                        {
                            StandardProductCategoryId = 2,
                            Name = "Sito"
                        },
                        new
                        {
                            StandardProductCategoryId = 3,
                            Name = "Szarpak"
                        },
                        new
                        {
                            StandardProductCategoryId = 4,
                            Name = "Inne"
                        });
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "jan_k@email.com",
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Login = "jan_k",
                            Password = "$2a$11$U6Us.rSgKNQOdBGsOk/bGOc4Oa6bCczKrpq1N.N/JdmVNMRj3Yvse",
                            PhoneNumber = "607934182",
                            Role = "Administrator",
                            Status = "Active"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "anna_n@email.com",
                            FirstName = "Anna",
                            LastName = "Nowak",
                            Login = "anna_n",
                            Password = "$2a$11$f7ORw/Yv7RlriQ8749XzsexBdfDkA1EiK6Jv/yddlipQVllyCxDKG",
                            PhoneNumber = "709856234",
                            Role = "Salesman",
                            Status = "Active"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "andrzej_m@email.com",
                            FirstName = "Andrzej",
                            LastName = "Malinowski",
                            Login = "andrzej_m",
                            Password = "$2a$11$fxEnaNdioUn74.61AIFQy.C.jlWAp6XapPWfN.eeuDuPDhOOWMp8C",
                            PhoneNumber = "679234374",
                            Role = "ProductionManager",
                            Status = "Active"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "agata_k@email.com",
                            FirstName = "Agata",
                            LastName = "Krzeszowska",
                            Login = "agata_k",
                            Password = "$2a$11$NfMIvAqaxAGG2DupmOQSFOoANndQiEy.9j7vD4ZZYzRD5IPNuH14S",
                            PhoneNumber = "685234054",
                            Role = "Technologist",
                            Status = "Active"
                        },
                        new
                        {
                            UserId = 5,
                            Email = "edward_r@email.com",
                            FirstName = "Edward",
                            LastName = "Rak",
                            Login = "edward_r",
                            Password = "$2a$11$cyzeXRjxn9ZAI5BWd7HJVuUnYcIk6M/H0O3d.46yIc4mr6lQb3cna",
                            PhoneNumber = "978345278",
                            Role = "Warehouseman",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.Additional.StandardOrderItemDetail", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.StandardProduct", "StandardProduct")
                        .WithMany()
                        .HasForeignKey("StandardProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.Client", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERPBackend.Entities.Models.User", "Salesman")
                        .WithMany("Clients")
                        .HasForeignKey("SalesmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.CustomOrderItem", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.CustomProduct", "CustomProduct")
                        .WithOne("CustomOrderItem")
                        .HasForeignKey("ERPBackend.Entities.Models.CustomOrderItem", "CustomProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERPBackend.Entities.Models.Order", "Order")
                        .WithMany("CustomOrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.CustomProduct", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.User", "Technologist")
                        .WithMany("CustomProducts")
                        .HasForeignKey("TechnologistId");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.FileItem", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.CustomProduct", "CustomProduct")
                        .WithMany("FileList")
                        .HasForeignKey("CustomProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.MaterialWarehouseItem", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.Material", "Material")
                        .WithOne("MaterialItem")
                        .HasForeignKey("ERPBackend.Entities.Models.MaterialWarehouseItem", "MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.Order", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERPBackend.Entities.Models.User", "Salesman")
                        .WithMany("Salesmen")
                        .HasForeignKey("SalesmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERPBackend.Entities.Models.User", "Warehouseman")
                        .WithMany("Warehousemen")
                        .HasForeignKey("WarehousemanId");
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.ProductWarehouseItem", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.StandardProduct", "StandardProduct")
                        .WithOne("ProductItem")
                        .HasForeignKey("ERPBackend.Entities.Models.ProductWarehouseItem", "StandardProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.StandardOrderItem", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.Order", "Order")
                        .WithMany("StandardOrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERPBackend.Entities.Models.StandardProduct", "StandardProduct")
                        .WithMany("StandardOrderItem")
                        .HasForeignKey("StandardProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.StandardProduct", b =>
                {
                    b.HasOne("ERPBackend.Entities.Models.StandardProductCategory", "StandardProductCategory")
                        .WithMany("StandardProducts")
                        .HasForeignKey("StandardProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}