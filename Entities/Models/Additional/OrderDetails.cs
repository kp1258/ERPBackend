using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace ERPBackend.Entities.Models.Additional
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public DateTime PlacingDate { get; set; }
        public DateTime? RealizationStartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public OrderStatus Status { get; set; }
        public OrderType Type { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int SalesmanId { get; set; }
        [ForeignKey("SalesmanId")]
        public User Salesman { get; set; }
        public int? WarehousemanId { get; set; }
        [ForeignKey("SalesmanId")]
        public User Warehouseman { get; set; }

        public ICollection<CustomOrderItem> CustomOrderItems { get; set; }
        public ICollection<StandardOrderItemDetail> StandardOrderItemDetails { get; set; }
    }

    public class StandardOrderItemDetail
    {
        public int StandardOrderItemDetailId { get; set; }
        public int StandardOrderItemId { get; set; }
        public int StandardProductId { get; set; }
        public StandardProduct StandardProduct { get; set; }
        public int Quantity { get; set; }
        public OrderItemDetailStatus Status { get; set; }
        public int MissingQuantity { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderItemDetailStatus
    {
        [EnumMember(Value = "dotępny")]
        Available,
        [EnumMember(Value = "niedostępny")]
        Unavailable
    }
}