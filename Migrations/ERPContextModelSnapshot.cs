﻿// <auto-generated />
using System;
using ERPBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPBackend.Migrations
{
    [DbContext(typeof(ERPContext))]
    partial class ERPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

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
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.HasData(
                        new
                        {
                            CustomOrderItemId = 1,
                            CustomProductId = 4,
                            OrderDate = new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = 3,
                            Quantity = 10,
                            Status = "Ordered"
                        },
                        new
                        {
                            CustomOrderItemId = 2,
                            CompletionDate = new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomProductId = 1,
                            OrderDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = 4,
                            ProductionManagerId = 3,
                            ProductionStartDate = new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 5,
                            Status = "Completed"
                        },
                        new
                        {
                            CustomOrderItemId = 3,
                            CompletionDate = new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomProductId = 2,
                            OrderDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = 4,
                            ProductionManagerId = 3,
                            ProductionStartDate = new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 15,
                            Status = "Completed"
                        },
                        new
                        {
                            CustomOrderItemId = 4,
                            CompletionDate = new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomProductId = 3,
                            OrderDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = 4,
                            ProductionManagerId = 3,
                            ProductionStartDate = new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 9,
                            Status = "Completed"
                        });
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.CustomProduct", b =>
                {
                    b.Property<int>("CustomProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("PreparationCompletionDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("PreparationStartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TechnologistId")
                        .HasColumnType("int");

                    b.HasKey("CustomProductId");

                    b.HasIndex("TechnologistId");

                    b.ToTable("CustomProducts");

                    b.HasData(
                        new
                        {
                            CustomProductId = 1,
                            Description = "Opis",
                            Name = "Produkt specjalny 1",
                            OrderDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PreparationCompletionDate = new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PreparationStartDate = new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Prepared",
                            TechnologistId = 4
                        },
                        new
                        {
                            CustomProductId = 2,
                            Description = "Opis",
                            Name = "Produkt specjalny 2",
                            OrderDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PreparationCompletionDate = new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PreparationStartDate = new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Prepared",
                            TechnologistId = 4
                        },
                        new
                        {
                            CustomProductId = 3,
                            Description = "Opis",
                            Name = "Produkt specjalny 3",
                            OrderDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PreparationCompletionDate = new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PreparationStartDate = new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Prepared",
                            TechnologistId = 4
                        },
                        new
                        {
                            CustomProductId = 4,
                            Description = "Opis",
                            Name = "Produkt specjalny 4",
                            OrderDate = new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Ordered"
                        });
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

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            MaterialId = 1,
                            Name = "Materiał 1"
                        },
                        new
                        {
                            MaterialId = 2,
                            Name = "Materiał 2"
                        },
                        new
                        {
                            MaterialId = 3,
                            Name = "Materiał 3"
                        },
                        new
                        {
                            MaterialId = 4,
                            Name = "Materiał 4"
                        });
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

                    b.HasData(
                        new
                        {
                            MaterialWarehouseItemId = 1,
                            MaterialId = 1,
                            Quantity = 30
                        },
                        new
                        {
                            MaterialWarehouseItemId = 2,
                            MaterialId = 2,
                            Quantity = 50
                        },
                        new
                        {
                            MaterialWarehouseItemId = 3,
                            MaterialId = 3,
                            Quantity = 10
                        },
                        new
                        {
                            MaterialWarehouseItemId = 4,
                            MaterialId = 4,
                            Quantity = 30
                        });
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

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ClientId = 1,
                            CompletionDate = new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlacingDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RealizationStartDate = new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SalesmanId = 2,
                            Status = "Completed",
                            Type = "Standard",
                            WarehousemanId = 5
                        },
                        new
                        {
                            OrderId = 2,
                            ClientId = 2,
                            PlacingDate = new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SalesmanId = 2,
                            Status = "Placed",
                            Type = "Standard"
                        },
                        new
                        {
                            OrderId = 3,
                            ClientId = 3,
                            PlacingDate = new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SalesmanId = 2,
                            Status = "Placed",
                            Type = "Custom"
                        },
                        new
                        {
                            OrderId = 4,
                            ClientId = 1,
                            CompletionDate = new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlacingDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RealizationStartDate = new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SalesmanId = 2,
                            Status = "Completed",
                            Type = "Custom",
                            WarehousemanId = 5
                        },
                        new
                        {
                            OrderId = 5,
                            ClientId = 2,
                            PlacingDate = new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RealizationStartDate = new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SalesmanId = 2,
                            Status = "InRealization",
                            Type = "Standard",
                            WarehousemanId = 5
                        });
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

                    b.HasData(
                        new
                        {
                            ProductWarehouseItemId = 1,
                            Quantity = 40,
                            StandardProductId = 1
                        },
                        new
                        {
                            ProductWarehouseItemId = 2,
                            Quantity = 50,
                            StandardProductId = 2
                        },
                        new
                        {
                            ProductWarehouseItemId = 3,
                            Quantity = 10,
                            StandardProductId = 3
                        },
                        new
                        {
                            ProductWarehouseItemId = 4,
                            Quantity = 25,
                            StandardProductId = 4
                        });
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

                    b.HasData(
                        new
                        {
                            StandardOrderItemId = 1,
                            OrderId = 1,
                            Quantity = 10,
                            StandardProductId = 1
                        },
                        new
                        {
                            StandardOrderItemId = 2,
                            OrderId = 1,
                            Quantity = 10,
                            StandardProductId = 2
                        },
                        new
                        {
                            StandardOrderItemId = 3,
                            OrderId = 1,
                            Quantity = 10,
                            StandardProductId = 3
                        },
                        new
                        {
                            StandardOrderItemId = 4,
                            OrderId = 2,
                            Quantity = 10,
                            StandardProductId = 3
                        },
                        new
                        {
                            StandardOrderItemId = 5,
                            OrderId = 2,
                            Quantity = 10,
                            StandardProductId = 4
                        },
                        new
                        {
                            StandardOrderItemId = 6,
                            OrderId = 5,
                            Quantity = 10,
                            StandardProductId = 1
                        },
                        new
                        {
                            StandardOrderItemId = 7,
                            OrderId = 5,
                            Quantity = 10,
                            StandardProductId = 2
                        });
                });

            modelBuilder.Entity("ERPBackend.Entities.Models.StandardProduct", b =>
                {
                    b.Property<int>("StandardProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Dimensions")
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

                    b.HasData(
                        new
                        {
                            StandardProductId = 1,
                            Dimensions = "100x100",
                            Name = "Produkt 1",
                            StandardProductCategoryId = 1,
                            Status = "InProduction"
                        },
                        new
                        {
                            StandardProductId = 2,
                            Dimensions = "100x100",
                            Name = "Produkt 2",
                            StandardProductCategoryId = 2,
                            Status = "InProduction"
                        },
                        new
                        {
                            StandardProductId = 3,
                            Dimensions = "100x100",
                            Name = "Produkt 3",
                            StandardProductCategoryId = 3,
                            Status = "InProduction"
                        },
                        new
                        {
                            StandardProductId = 4,
                            Dimensions = "100x100",
                            Name = "Produkt 4",
                            StandardProductCategoryId = 4,
                            Status = "InProduction"
                        });
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
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

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
                            Password = "password",
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
                            Password = "password",
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
                            Password = "password",
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
                            Password = "password",
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
                            Password = "password",
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
