using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERPBackend.Entities;
using System.Collections.Generic;

namespace ERPBackend.Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<StandardProduct>
    {
        public void Configure(EntityTypeBuilder<StandardProduct> builder)
        {
            builder.HasData(new List<StandardProduct>{
                new StandardProduct
                {
                    StandardProductId = 1,
                    Name = "Produkt",
                }
            }
            );
        }
    }
}