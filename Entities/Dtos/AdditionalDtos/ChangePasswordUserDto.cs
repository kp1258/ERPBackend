using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.AdditionalDtos
{
    public class ChangePasswordUserDto
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}