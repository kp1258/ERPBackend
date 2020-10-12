using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class CustomOrderItemConfiguration : IEntityTypeConfiguration<CustomOrderItem>
    {
        public void Configure(EntityTypeBuilder<CustomOrderItem> builder)
        {
            builder.HasData(new List<CustomOrderItem>{
                new CustomOrderItem{
                    CustomOrderItemId=1,
                    OrderId=3,
                    CustomProductId=4,
                    Quantity=10
                },
                new CustomOrderItem{
                    CustomOrderItemId=2,
                    OrderId=4,
                    CustomProductId=1,
                    Quantity=5
                },
                new CustomOrderItem{
                    CustomOrderItemId=3,
                    OrderId=4,
                    CustomProductId=2,
                    Quantity=15
                },
                new CustomOrderItem{
                    CustomOrderItemId=4,
                    OrderId=4,
                    CustomProductId=3,
                    Quantity=9
                },
            });
        }
    }
}