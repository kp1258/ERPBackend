using System;
using ERPBackend.Entities.Models.Configuration;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Entities
{
    public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialWarehouseItem> MaterialWarehouse { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<StandardOrderItem> StandardOrderItems { get; set; }
        public DbSet<CustomOrderItem> CustomOrderItems { get; set; }
        public DbSet<StandardProduct> StandardProducts { get; set; }
        public DbSet<CustomProduct> CustomProducts { get; set; }
        public DbSet<StandardProductCategory> StandardProductCategories { get; set; }
        public DbSet<ProductWarehouseItem> ProductWarehouse { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FileItem> FileItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

        }
        //fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());

            //modelBuilder.ApplyConfiguration(new CustomOrderItemConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomProductConfiguration());

            //modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            //modelBuilder.ApplyConfiguration(new MaterialItemConfiguration());

            //modelBuilder.ApplyConfiguration(new OrderConfiguration());

            //modelBuilder.ApplyConfiguration(new StandardProductConfiguration());
            modelBuilder.ApplyConfiguration(new StandardProductCategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new StandardOrderItemConfiguration());
            //modelBuilder.ApplyConfiguration(new StandardProductItemConfiguration());

            modelBuilder
                .Entity<User>()
                .Property(e => e.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserRole)Enum.Parse(typeof(UserRole), v)
                );
            modelBuilder
                .Entity<User>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserStatus)Enum.Parse(typeof(UserStatus), v)
                );
            modelBuilder
                .Entity<Order>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v)
                );
            modelBuilder
                .Entity<Order>()
                .Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (OrderType)Enum.Parse(typeof(OrderType), v)
                );
            modelBuilder
                .Entity<CustomOrderItem>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (CustomOrderItemStatus)Enum.Parse(typeof(CustomOrderItemStatus), v)
                );
            modelBuilder
                .Entity<Client>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (ClientStatus)Enum.Parse(typeof(ClientStatus), v)
                );
            modelBuilder
                .Entity<StandardProduct>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (StandardProductStatus)Enum.Parse(typeof(StandardProductStatus), v)
                );
            modelBuilder
                .Entity<CustomProduct>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (CustomProductStatus)Enum.Parse(typeof(CustomProductStatus), v)

                );
            modelBuilder
                .Entity<StandardOrderItemDetail>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (OrderItemDetailStatus)Enum.Parse(typeof(OrderItemDetailStatus), v)
                );
            modelBuilder
                .Entity<FileItem>()
                .Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (FileType)Enum.Parse(typeof(FileType), v)
                );
        }
    }

}