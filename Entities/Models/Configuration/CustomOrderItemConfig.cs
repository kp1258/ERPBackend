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
                    ProductionStartDate=null,
                    CompletionDate=null
                },
                new CustomOrderItem{
                    CustomOrderItemId=2,
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
                    CustomOrderItemId=3,
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
                    CustomOrderItemId=4,
                    OrderId=4,
                    CustomProductId=3,
                    Quantity=9,
                    Status=CustomOrderItemStatus.Completed,
                    ProductionManagerId=3,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    ProductionStartDate=new DateTime(year:2020, month:9,day:8),
                    CompletionDate=new DateTime(year:2020, month:9,day:12)
                },
            });
        }
    }
}