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
                    OrderDescription="Opis zamówienia",
                    SolutionDescription="Opis rozwiązania",
                    TechnologistId=4,
                    Status=CustomProductStatus.Prepared,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    PreparationStartDate=new DateTime(year:2020, month:9,day:2),
                    PreparationCompletionDate=new DateTime(year:2020, month:9,day:3)
                },
                new CustomProduct{
                    CustomProductId=2,
                    Name="Produkt specjalny 2",
                    OrderDescription="Opis zamówienia",
                    SolutionDescription="Opis rozwiązania",
                    TechnologistId=4,
                    Status=CustomProductStatus.Prepared,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    PreparationStartDate=new DateTime(year:2020, month:9,day:3),
                    PreparationCompletionDate=new DateTime(year:2020, month:9,day:4)
                },
                new CustomProduct{
                    CustomProductId=3,
                    Name="Produkt specjalny 3",
                    OrderDescription="Opis zamówienia",
                    SolutionDescription="Opis rozwiązania",
                    TechnologistId=4,
                    Status=CustomProductStatus.Prepared,
                    OrderDate=new DateTime(year:2020, month:9,day:1),
                    PreparationStartDate=new DateTime(year:2020, month:9,day:4),
                    PreparationCompletionDate=new DateTime(year:2020, month:9,day:5)
                },
                new CustomProduct{
                    CustomProductId=4,
                    Name="Produkt specjalny 4",
                    OrderDescription="Opis zamówienia",
                    TechnologistId=null,
                    Status=CustomProductStatus.Ordered,
                    OrderDate=new DateTime(year:2020, month:10, day:20),
                },
                    new CustomProduct{
                    CustomProductId=5,
                    Name="Produkt specjalny 5",
                    OrderDescription="Opis zamówienia",
                    TechnologistId=null,
                    Status=CustomProductStatus.Ordered,
                    OrderDate=new DateTime(year:2020, month:10, day:20),
                },
                    new CustomProduct{
                    CustomProductId=6,
                    Name="Produkt specjalny 6",
                    OrderDescription="Opis zamówienia",
                    TechnologistId=null,
                    Status=CustomProductStatus.Ordered,
                    OrderDate=new DateTime(year:2020, month:10, day:20),
                },
                    new CustomProduct{
                    CustomProductId=7,
                    Name="Produkt specjalny 7",
                    OrderDescription="Opis zamówienia",
                    TechnologistId=4,
                    Status=CustomProductStatus.InPreparation,
                    OrderDate=new DateTime(year:2020, month:10, day:20),
                    PreparationStartDate=new DateTime(year:2020, month:10, day:21),
                },
                    new CustomProduct{
                    CustomProductId=8,
                    Name="Produkt specjalny 8",
                    OrderDescription="Opis zamówienia",
                    SolutionDescription="Opis rozwiązania",
                    TechnologistId=4,
                    Status=CustomProductStatus.Prepared,
                    OrderDate=new DateTime(year:2020, month:10, day:20),
                    PreparationStartDate=new DateTime(year:2020, month:10, day:21),
                    PreparationCompletionDate=new DateTime(year:2020, month:10, day:23)
                },
                    new CustomProduct{
                    CustomProductId=9,
                    Name="Produkt specjalny 9",
                    OrderDescription="Opis zamówienia",
                    SolutionDescription="Opis rozwiązania",
                    TechnologistId=4,
                    Status=CustomProductStatus.Prepared,
                    OrderDate=new DateTime(year:2020, month:10, day:20),
                    PreparationStartDate=new DateTime(year:2020, month:10, day:21),
                    PreparationCompletionDate=new DateTime(year:2020, month:10, day:23)
                },
            });
        }
    }
}