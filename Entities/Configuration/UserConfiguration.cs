using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERPBackend.Entities;

namespace ERPBackend.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    UserId = 1,
                    Login = "login",
                    Password = "password",
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Role = UserRole.Administrator
                }
            );
        }
    }
}