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
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public Status Status { get; set; }

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
        [EnumMember(Value = "administrator")]
        Administrator,
        [EnumMember(Value = "warehouseman")]
        Warehouseman,
        [EnumMember(Value = "productionManager")]
        ProductionManager,
        [EnumMember(Value = "technologist")]
        Technologist,
        [EnumMember(Value = "salesman")]
        Salesman
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "inactive")]
        Inactive
    }

}