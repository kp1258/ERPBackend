using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Models.Additional
{
    public class AuthenticationResponse
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Token { get; set; }
    }
}