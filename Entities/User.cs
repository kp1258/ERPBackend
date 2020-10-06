using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPBackend.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string Login { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public ICollection<Client> Clients { get; set; }
        [InverseProperty("Salesman")]
        public ICollection<Order> Salesmen { get; set; }
        [InverseProperty("Warehouseman")]
        public ICollection<Order> Warehousemen { get; set; }
        public ICollection<CustomProduct> CustomProducts { get; set; }

    }

    public enum UserRole
    {
        Administrator,
        Warehouseman,
        ProductionManager,
        Technologist,
        Salesman
    }

}