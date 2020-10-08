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
        public DateTime FulfillmentDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public OrderType Type { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int SalesmanId { get; set; }
        [ForeignKey("SalesmanId")]
        public User Salesman { get; set; }
        public int WarehousemanId { get; set; }
        [ForeignKey("WarehousemanId")]
        public User Warehouseman { get; set; }

        public ICollection<CustomOrderDetail> CustomOrderDetails { get; set; }
        public ICollection<StandardOrderDetail> StandardOrderDetails { get; set; }

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        [EnumMember(Value = "placed")]
        Placed,
        [EnumMember(Value = "inProgress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        [EnumMember(Value = "standard")]
        Standard,
        [EnumMember(Value = "custom")]
        Custom
    }
}