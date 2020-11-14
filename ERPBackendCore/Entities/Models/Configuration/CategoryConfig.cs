using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class StandardProductCategoryConfiguration : IEntityTypeConfiguration<StandardProductCategory>
    {
        public void Configure(EntityTypeBuilder<StandardProductCategory> builder)
        {
            builder.HasData(new List<StandardProductCategory>{
                new StandardProductCategory
                {
                    StandardProductCategoryId=1,
                    Name="Nóż"
                },
                new StandardProductCategory
                {
                    StandardProductCategoryId=2,
                    Name="Sito"
                },
                new StandardProductCategory
                {
                    StandardProductCategoryId=3,
                    Name="Szarpak"
                },
                new StandardProductCategory
                {
                    StandardProductCategoryId=4,
                    Name="Inne"
                }
            });
        }
    }
}