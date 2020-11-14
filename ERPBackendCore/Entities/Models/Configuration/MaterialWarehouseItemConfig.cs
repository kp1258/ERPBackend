using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class MaterialItemConfiguration : IEntityTypeConfiguration<MaterialWarehouseItem>
    {
        public void Configure(EntityTypeBuilder<MaterialWarehouseItem> builder)
        {
            builder.HasData(
                new List<MaterialWarehouseItem>{
                    new MaterialWarehouseItem{
                        MaterialWarehouseItemId=1,
                        Quantity=30,
                        MaterialId=1
                    },
                    new MaterialWarehouseItem{
                        MaterialWarehouseItemId=2,
                        Quantity=50,
                        MaterialId=2
                    },
                    new MaterialWarehouseItem{
                        MaterialWarehouseItemId=3,
                        Quantity=10,
                        MaterialId=3
                    },
                    new MaterialWarehouseItem{
                        MaterialWarehouseItemId=4,
                        Quantity=30,
                        MaterialId=4
                    }
                }
            );
        }
    }
}