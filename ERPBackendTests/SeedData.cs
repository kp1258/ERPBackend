using ERPBackend.Entities;
using ERPBackend.Entities.Models;

namespace ERPBackendTests
{
    public static class SeedData
    {
        public static void InsertTestData(ERPContext erpContext)
        {
            erpContext.Users.Add(new User { Login = "ewa_f", Password = "password", FirstName = "Ewa", LastName = "Frankowska", PhoneNumber = "123456789", Email = "ewa_f@mail.com", Role = UserRole.Administrator, Status = UserStatus.Active });
            erpContext.SaveChanges();
        }
    }
}