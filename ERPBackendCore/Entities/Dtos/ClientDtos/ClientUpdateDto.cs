using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.ClientDtos
{
    public class ClientUpdateDto
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public AddressInfoDto Address { get; set; }

    }
}