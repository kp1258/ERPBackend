using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.UserDtos
{
    public class UserPasswordUpdateDto
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}