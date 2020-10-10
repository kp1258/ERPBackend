using System;
using ERPBackend.Entities.Models.Configuration;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<MaterialItem> MaterialWarehouse { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<StandardOrderItem> StandardOrderDetails { get; set; }
        public DbSet<CustomOrderItem> CustomOrderDetails { get; set; }
        public DbSet<StandardProduct> StandardProducts { get; set; }
        public DbSet<CustomProduct> CustomProducts { get; set; }
        public DbSet<StandardProductCategory> StandardProductCategories { get; set; }
        public DbSet<StandardProductItem> StandardProductWarehouse { get; set; }
        public DbSet<User> Users { get; set; }



        //fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StandardProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StandardProductCategoryConfiguration());

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
        }
    }

}