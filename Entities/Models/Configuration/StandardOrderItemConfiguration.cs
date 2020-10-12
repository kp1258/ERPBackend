using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class StandardOrderItemConfiguration : IEntityTypeConfiguration<StandardOrderItem>
    {
        public void Configure(EntityTypeBuilder<StandardOrderItem> builder)
        {
            builder.HasData(
                new List<StandardOrderItem>{
                    new StandardOrderItem{
                        StandardOrderItemId=1,
                        OrderId=1,
                        StandardProductId=1,
                        Quantity=10
                    },
                    new StandardOrderItem{
                        StandardOrderItemId=2,
                        OrderId=1,
                        StandardProductId=2,
                        Quantity=10
                    },
                    new StandardOrderItem{
                        StandardOrderItemId=3,
                        OrderId=1,
                        StandardProductId=3,
                        Quantity=10
                    },
                    new StandardOrderItem{
                        StandardOrderItemId=4,
                        OrderId=2,
                        StandardProductId=3,
                        Quantity=10
                    },
                    new StandardOrderItem{
                        StandardOrderItemId=5,
                        OrderId=2,
                        StandardProductId=4,
                        Quantity=10
                    },
                    new StandardOrderItem{
                        StandardOrderItemId=6,
                        OrderId=5,
                        StandardProductId=1,
                        Quantity=10
                    },
                    new StandardOrderItem{
                        StandardOrderItemId=7,
                        OrderId=5,
                        StandardProductId=2,
                        Quantity=10
                    },
                }
            );
        }
    }
}