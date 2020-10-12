using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class MaterialItemConfiguration : IEntityTypeConfiguration<MaterialItem>
    {
        public void Configure(EntityTypeBuilder<MaterialItem> builder)
        {
            builder.HasData(
                new List<MaterialItem>{
                    new MaterialItem{
                        MaterialItemId=1,
                        Quantity=30,
                        MaterialId=1
                    },
                    new MaterialItem{
                        MaterialItemId=2,
                        Quantity=50,
                        MaterialId=2
                    },
                    new MaterialItem{
                        MaterialItemId=3,
                        Quantity=10,
                        MaterialId=3
                    },
                    new MaterialItem{
                        MaterialItemId=4,
                        Quantity=30,
                        MaterialId=4
                    }
                }
            );
        }
    }
}