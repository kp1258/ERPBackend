using System;
using System.Collections.Generic;
using ERPBackend.Entities.Dtos.ClientDtos;
using ERPBackend.Entities.Dtos.OrderItemDtos;
using ERPBackend.Entities.Dtos.UserDtos;

namespace ERPBackend.Entities.Dtos.OrderDtos
{
    public class OrderInfoDto
    {
        public int OrderId { get; set; }
        public DateTime PlacingDate { get; set; }
        public DateTime FulfillmentDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public ClientInfoDto Client { get; set; }
        public UserInfoDto Salesman { get; set; }
        public UserInfoDto Warehouseman { get; set; }
        public IEnumerable<CustomOrderItemDto> CustomOrderItems { get; set; }
        public IEnumerable<StandardOrderItemDto> StandardOrderItems { get; set; }
    }
}