using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.AdditionalDtos
{
    public class ChangePasswordAdminDto
    {
        [Required]
        public string NewPassword { get; set; }
    }
}