using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPBackend.Entities.Models.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(new List<Address>{
                new Address
                {
                    AddressId=1,
                    Street="ul.Witosa 10",
                    PostalCode="69-100",
                    City="Słubice"
                },
                new Address
                {
                    AddressId=2,
                    Street="ul.Nowodworska 80",
                    PostalCode="61-222",
                    City="Poznań"
                },
                new Address
                {
                    AddressId=3,
                    Street="al. Wojska Polskiego 33",
                    PostalCode="66-400",
                    City="Gorzów Wielkopolski"
                }
            });
        }
    }
}