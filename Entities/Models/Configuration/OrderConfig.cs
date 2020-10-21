using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new List<Order>
            {
                new Order{
                    OrderId=1,
                    PlacingDate=new DateTime(year:2020, month:9, day:1),
                    RealizationStartDate=new DateTime(year:2020, month:9, day:2),
                    CompletionDate=new DateTime(year:2020,month:9, day:10),
                    Status=OrderStatus.Completed,
                    Type=OrderType.Standard,
                    ClientId=1,
                    SalesmanId=2,
                    WarehousemanId=5
                },
                new Order{
                    OrderId=2,
                    PlacingDate=new DateTime(year:2020, month:10, day:20),
                    RealizationStartDate=null,
                    CompletionDate=null,
                    Status=OrderStatus.Placed,
                    Type=OrderType.Standard,
                    ClientId=2,
                    SalesmanId=2,
                    WarehousemanId=null
                },
                new Order{
                    OrderId=3,
                    PlacingDate=new DateTime(year:2020, month:10, day:20),
                    RealizationStartDate=null,
                    CompletionDate=null,
                    Status=OrderStatus.Placed,
                    Type=OrderType.Custom,
                    ClientId=3,
                    SalesmanId=2,
                    WarehousemanId=null,
                },
                new Order{
                    OrderId=4,
                    PlacingDate=new DateTime(year:2020, month:9,day:1),
                    RealizationStartDate=new DateTime(year:2020, month:9, day:2),
                    CompletionDate=new DateTime(year:2020, month:9, day:14),
                    Status=OrderStatus.Completed,
                    Type=OrderType.Custom,
                    ClientId=1,
                    SalesmanId=2,
                    WarehousemanId=5
                },
                new Order{
                    OrderId=5,
                    PlacingDate=new DateTime(year:2020, month:10, day:20),
                    RealizationStartDate=new DateTime(year:2020, month:10, day:21),
                    CompletionDate=null,
                    Status=OrderStatus.InRealization,
                    Type=OrderType.Standard,
                    ClientId=2,
                    SalesmanId=2,
                    WarehousemanId=5
                }
            });
        }
    }
}