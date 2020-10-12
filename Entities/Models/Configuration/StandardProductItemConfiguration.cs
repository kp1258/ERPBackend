using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class StandardProductItemConfiguration : IEntityTypeConfiguration<StandardProductItem>
    {
        public void Configure(EntityTypeBuilder<StandardProductItem> builder)
        {
            builder.HasData(new List<StandardProductItem>{
                new StandardProductItem{
                    StandardProductItemId=1,
                    Quantity=40,
                    StandardProductId=1,
                },
                new StandardProductItem{
                    StandardProductItemId=2,
                    Quantity=50,
                    StandardProductId=2,
                },
                new StandardProductItem{
                    StandardProductItemId=3,
                    Quantity=10,
                    StandardProductId=3,
                },
                new StandardProductItem{
                    StandardProductItemId=4,
                    Quantity=25,
                    StandardProductId=4,
                },
            });
        }
    }
}