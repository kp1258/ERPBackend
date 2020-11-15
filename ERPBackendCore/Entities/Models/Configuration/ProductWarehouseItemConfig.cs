using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class StandardProductItemConfiguration : IEntityTypeConfiguration<ProductWarehouseItem>
    {
        public void Configure(EntityTypeBuilder<ProductWarehouseItem> builder)
        {
            builder.HasData(new List<ProductWarehouseItem>{
                new ProductWarehouseItem
                {
                    ProductWarehouseItemId=1,
                    Quantity=20,
                    StandardProductId=1,
                },
                new ProductWarehouseItem{
                    ProductWarehouseItemId=2,
                    Quantity=30,
                    StandardProductId=2,
                },
                new ProductWarehouseItem{
                    ProductWarehouseItemId=3,
                    Quantity=10,
                    StandardProductId=3,
                },
                new ProductWarehouseItem{
                    ProductWarehouseItemId=4,
                    Quantity=25,
                    StandardProductId=4,
                },
            });
        }
    }
}