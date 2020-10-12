using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ERPBackend.Entities.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [Required]
        public int SalesmanId { get; set; }
        public User Salesman { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
