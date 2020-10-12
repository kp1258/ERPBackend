using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos
{
    public class AddressInfoDto
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
    }
}