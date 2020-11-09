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
        public string Email { get; set; }
        public AddressInfoDto Address { get; set; }
        public string Status { get; set; }
    }
}