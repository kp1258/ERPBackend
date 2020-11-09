using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasData(new List<Material>{
                new Material{
                    MaterialId=1,
                    Name="Materiał 1",
                    Unit="kilogramy"
                },
                new Material{
                    MaterialId=2,
                    Name="Materiał 2",
                    Unit="kilogramy"
                },
                new Material{
                    MaterialId=3,
                    Name="Materiał 3",
                    Unit="kilogramy"
                },
                new Material{
                    MaterialId=4,
                    Name="Materiał 4",
                    Unit="kilogramy"
                }
            });
        }
    }
}