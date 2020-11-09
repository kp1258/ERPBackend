using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERPBackend.Entities;
using System.Collections.Generic;

namespace ERPBackend.Entities.Models.Configuration
{
    public class StandardProductConfiguration : IEntityTypeConfiguration<StandardProduct>
    {
        public void Configure(EntityTypeBuilder<StandardProduct> builder)
        {
            builder.HasData(new List<StandardProduct>{
                new StandardProduct
                {
                    StandardProductId = 1,
                    Name = "Produkt 1",
                    Dimensions="100x100",
                    StandardProductCategoryId=1,
                    Status=StandardProductStatus.Produced
                },
                new StandardProduct
                {
                    StandardProductId=2,
                    Name = "Produkt 2",
                    Dimensions="100x100",
                    StandardProductCategoryId=2,
                    Status=StandardProductStatus.Produced
                },
                new StandardProduct
                {
                    StandardProductId=3,
                    Name = "Produkt 3",
                    Dimensions="100x100",
                    StandardProductCategoryId=3,
                    Status=StandardProductStatus.Produced
                },
                new StandardProduct
                {
                    StandardProductId=4,
                    Name = "Produkt 4",
                    Dimensions="100x100",
                    StandardProductCategoryId=4,
                    Status=StandardProductStatus.Produced
                },

            }
            );
        }
    }
}