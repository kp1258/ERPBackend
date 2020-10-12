using ERPBackend.Entities.Models;

namespace ERPBackend.Entities.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
    }
}