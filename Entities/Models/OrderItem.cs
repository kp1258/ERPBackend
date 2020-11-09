using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ERPBackend.Entities.Models
{
    public class CustomOrderItem
    {
        public int CustomOrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int CustomProductId { get; set; }
        public CustomProduct CustomProduct { get; set; }
        [Required]
        public CustomOrderItemStatus Status { get; set; }
        public int? ProductionManagerId { get; set; }
        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ProductionStartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomOrderItemStatus
    {
        [EnumMember(Value = "Zamówiony")]
        Ordered,
        [EnumMember(Value = "W produkcji")]
        InProduction,
        [EnumMember(Value = "Zrealizowany")]
        Completed
    }

    public class StandardOrderItem
    {
        public int StandardOrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int StandardProductId { get; set; }
        public StandardProduct StandardProduct { get; set; }
        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }
    }
}