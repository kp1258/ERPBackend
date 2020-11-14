using System.ComponentModel.DataAnnotations;
using ERPBackend.Entities.Models;

namespace ERPBackend.Entities.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}