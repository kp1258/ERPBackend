using System;
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
                    Quantity=10,
                    Status=CustomOrderItemStatus.Ordered,
                    ProductionManagerId=null,
                    OrderDate=new DateTime(year:2020, month:10,day:20),
                },
                new CustomOrderItem{
                    CustomOrderItemId=2,
                    OrderId=3,
                    CustomProductId=5,
                    Quantity=10,
                    Status=CustomOrderItemStatus.Ordered,
                    ProductionManagerId=null,
                    OrderDate=new DateTime(year:2020, month:10,day:20),
                },
                new CustomOrderItem{
                    CustomOrderItemId=3,
                    OrderId=4,
                    CustomProductId=1,
                    Quantity=5,
                    Status=CustomOrderItemStatus.Completed,
                    ProductionManagerId=3,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    ProductionStartDate=new DateTime(year:2020, month:9,day:4),
                    CompletionDate=new DateTime(year:2020, month:9,day:6)
                },
                new CustomOrderItem{
                    CustomOrderItemId=4,
                    OrderId=4,
                    CustomProductId=2,
                    Quantity=15,
                    Status=CustomOrderItemStatus.Completed,
                    ProductionManagerId=3,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    ProductionStartDate=new DateTime(year:2020, month:9,day:5),
                    CompletionDate=new DateTime(year:2020, month:9,day:10)
                },
                new CustomOrderItem{
                    CustomOrderItemId=5,
                    OrderId=4,
                    CustomProductId=3,
                    Quantity=9,
                    Status=CustomOrderItemStatus.Completed,
                    ProductionManagerId=3,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    ProductionStartDate=new DateTime(year:2020, month:9,day:8),
                    CompletionDate=new DateTime(year:2020, month:9,day:12)
                },
                    new CustomOrderItem{
                    CustomOrderItemId=6,
                    OrderId=6,
                    CustomProductId=6,
                    Quantity=9,
                    Status=CustomOrderItemStatus.Ordered,
                    ProductionManagerId=3,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                },
                    new CustomOrderItem{
                    CustomOrderItemId=7,
                    OrderId=6,
                    CustomProductId=7,
                    Quantity=9,
                    Status=CustomOrderItemStatus.Ordered,
                    ProductionManagerId=3,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                },
                    new CustomOrderItem{
                    CustomOrderItemId=8,
                    OrderId=6,
                    CustomProductId=8,
                    Quantity=9,
                    Status=CustomOrderItemStatus.InProduction,
                    ProductionManagerId=3,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    ProductionStartDate=new DateTime(year:2020, month:9,day:8),
                },
                    new CustomOrderItem{
                    CustomOrderItemId=9,
                    OrderId=6,
                    CustomProductId=9,
                    Quantity=9,
                    Status=CustomOrderItemStatus.Ordered,
                    ProductionManagerId=null,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                },
            });
        }
    }
}