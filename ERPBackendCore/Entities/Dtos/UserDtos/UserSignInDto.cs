using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos
{
    public class UserSignInDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}