using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
    }
}