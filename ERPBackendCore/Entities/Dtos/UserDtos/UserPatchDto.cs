using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.UserDtos
{
    public class UserPatchDto
    {
        [Required]
        public string Status { get; set; }
    }
}