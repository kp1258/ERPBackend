using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(new List<Client>{
                new Client{
                    ClientId=1,
                    CompanyName="Zakłady mięsne Stokłosa",
                    FirstName="Adam",
                    LastName="Markowski",
                    PhoneNumber="678234765",
                    EMail="zm_stokolosa@mail.com",
                    AddressId=1,
                    SalesmanId=2,
                    Status=ClientStatus.Active
                },
                new Client{
                    ClientId=2,
                    CompanyName="Zakłady mięsne Solańscy",
                    FirstName="Edward",
                    LastName="Solański",
                    PhoneNumber="978456723",
                    EMail="zm_solanscy@mail.com",
                    AddressId=2,
                    SalesmanId=2,
                    Status=ClientStatus.Active
                },
                new Client{
                    ClientId=3,
                    CompanyName="ZM Turowski",
                    FirstName="Piotr",
                    LastName="Turowski",
                    PhoneNumber="867544765",
                    EMail="zm_turowski@mail.com",
                    AddressId=3,
                    SalesmanId=2,
                    Status=ClientStatus.Active
                }
            });
        }
    }
}