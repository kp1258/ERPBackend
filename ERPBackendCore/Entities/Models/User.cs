using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ERPBackend.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MinLength(9), MaxLength(12)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public UserStatus Status { get; set; }

        public ICollection<Client> Clients { get; set; }
        [InverseProperty("Salesman")]
        public ICollection<Order> Salesmen { get; set; }
        [InverseProperty("Warehouseman")]
        public ICollection<Order> Warehousemen { get; set; }
        public ICollection<CustomProduct> CustomProducts { get; set; }

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserRole
    {
        [EnumMember(Value = "Administrator")]
        Administrator,
        [EnumMember(Value = "Magazynier")]
        Warehouseman,
        [EnumMember(Value = "Kierownik produkcji")]
        ProductionManager,
        [EnumMember(Value = "Technolog")]
        Technologist,
        [EnumMember(Value = "Handlowiec")]
        Salesman
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserStatus
    {
        [EnumMember(Value = "Aktywny")]
        Active,

        [EnumMember(Value = "Nieaktywny")]
        Inactive
    }

}