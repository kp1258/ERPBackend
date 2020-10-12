using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.ClientDtos
{
    public class ClientReadDto
    {
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        [Required]
        public AddressInfoDto Address { get; set; }
    }
}