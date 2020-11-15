using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ERPBackend.Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public DateTime PlacingDate { get; set; }
        public DateTime RealizationStartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public OrderType Type { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public int SalesmanId { get; set; }
        [ForeignKey("SalesmanId")]
        public User Salesman { get; set; }
        public int? WarehousemanId { get; set; }
        [ForeignKey("WarehousemanId")]
        public User Warehouseman { get; set; }

        public ICollection<CustomOrderItem> CustomOrderItems { get; set; }
        public ICollection<StandardOrderItem> StandardOrderItems { get; set; }

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        [EnumMember(Value = "Złożone")]
        Placed,
        [EnumMember(Value = "W realizacji")]
        InRealization,
        [EnumMember(Value = "Zrealizowane")]
        Completed
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        [EnumMember(Value = "Standardowy")]
        Standard,
        [EnumMember(Value = "Niestandardowy")]
        Custom
    }
}