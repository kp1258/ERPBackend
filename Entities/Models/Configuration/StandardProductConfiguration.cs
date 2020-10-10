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
                    Name = "Produkt",
                    Dimensions="100x100",
                    StandardProductCategoryId=1
                }
            }
            );
        }
    }
}