using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class CustomProductConfiguration : IEntityTypeConfiguration<CustomProduct>
    {
        public void Configure(EntityTypeBuilder<CustomProduct> builder)
        {
            builder.HasData(new List<CustomProduct>
            {
                new CustomProduct{
                    CustomProductId=1,
                    Name="Produkt specjalny 1",
                    Description="Opis",
                    TechnologistId=4,
                    Status=CustomProductStatus.Prepared,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    PreparationStartDate=new DateTime(year:2020, month:9,day:2),
                    PreparationCompletionDate=new DateTime(year:2020, month:9,day:3)
                },
                new CustomProduct{
                    CustomProductId=2,
                    Name="Produkt specjalny 2",
                    Description="Opis",
                    TechnologistId=4,
                    Status=CustomProductStatus.Prepared,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    PreparationStartDate=new DateTime(year:2020, month:9,day:3),
                    PreparationCompletionDate=new DateTime(year:2020, month:9,day:4)
                },
                new CustomProduct{
                    CustomProductId=3,
                    Name="Produkt specjalny 3",
                    Description="Opis",
                    TechnologistId=4,
                    Status=CustomProductStatus.Prepared,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    PreparationStartDate=new DateTime(year:2020, month:9,day:4),
                    PreparationCompletionDate=new DateTime(year:2020, month:9,day:5)
                },
                new CustomProduct{
                    CustomProductId=4,
                    Name="Produkt specjalny 4",
                    Description="Opis",
                    TechnologistId=null,
                    Status=CustomProductStatus.Ordered,
                    OrderDate=new DateTime(year:2020, month:10, day:20),
                    PreparationStartDate=null,
                    PreparationCompletionDate=null
                },
            });
        }
    }
}