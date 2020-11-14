using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        [MinLength(5), MaxLength(30)]
        public string Street { get; set; }
        [Required]
        [MinLength(6), MaxLength(6)]
        public string PostalCode { get; set; }
        [Required]
        [MinLength(3), MaxLength(30)]
        public string City { get; set; }
    }
}