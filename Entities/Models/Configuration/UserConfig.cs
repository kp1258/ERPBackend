using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERPBackend.Entities;

namespace ERPBackend.Entities.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new[]{
                new User
                {
                    UserId = 1,
                    Login = "jan_k",
                    Password = "password",
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    PhoneNumber="607934182",
                    Email="jan_k@email.com",
                    Role = UserRole.Administrator,
                    Status = UserStatus.Active
                },
                new User
                {
                    UserId=2,
                    Login="anna_n",
                    Password="password",
                    FirstName="Anna",
                    LastName="Nowak",
                    PhoneNumber="709856234",
                    Email="anna_n@email.com",
                    Role=UserRole.Salesman,
                    Status=UserStatus.Active
                },
                new User
                {
                    UserId=3,
                    Login="andrzej_m",
                    Password="password",
                    FirstName="Andrzej",
                    LastName="Malinowski",
                    PhoneNumber="679234374",
                    Email="andrzej_m@email.com",
                    Role=UserRole.ProductionManager,
                    Status=UserStatus.Active,
                },
                new User
                {
                    UserId=4,
                    Login="agata_k",
                    Password="password",
                    FirstName="Agata",
                    LastName="Krzeszowska",
                    PhoneNumber="685234054",
                    Email="agata_k@email.com",
                    Role=UserRole.Technologist,
                    Status=UserStatus.Active
                },
                new User
                {
                    UserId=5,
                    Login="edward_r",
                    Password="password",
                    FirstName="Edward",
                    LastName="Rak",
                    PhoneNumber="978345278",
                    Email="edward_r@email.com",
                    Role=UserRole.Warehouseman,
                    Status=UserStatus.Active
                }
            }

            );
        }
    }
}