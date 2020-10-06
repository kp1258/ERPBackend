using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ERPBackend.Entities.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }

        public int SalesmanId { get; set; }
        public User Salesman { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
