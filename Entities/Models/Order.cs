using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public enum OrderStatus
    {
        Placed,
        InProgress,
        Completed
    }

    public enum OrderType
    {
        Standard,
        Custom
    }
}