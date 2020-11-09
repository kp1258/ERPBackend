using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.UserDtos
{
    public class UserInfoDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}