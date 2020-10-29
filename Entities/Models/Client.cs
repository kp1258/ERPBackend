using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        public string Email { get; set; }
        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [Required]
        public ClientStatus Status { get; set; }
        [Required]
        public int SalesmanId { get; set; }
        public User Salesman { get; set; }

        public ICollection<Order> Orders { get; set; }

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ClientStatus
    {
        [EnumMember(Value = "aktywny")]
        Active,
        [EnumMember(Value = "nieaktywny")]
        Inactive

    }

}
