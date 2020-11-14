using System;
using System.Collections.Generic;
using ERPBackend.Entities.Dtos.ClientDtos;
using ERPBackend.Entities.Dtos.OrderItemDtos;
using ERPBackend.Entities.Dtos.UserDtos;

namespace ERPBackend.Entities.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }
        public DateTime PlacingDate { get; set; }
        public DateTime RealizationStartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public ClientInfoDto Client { get; set; }
        public UserInfoDto Salesman { get; set; }
        public UserInfoDto Warehouseman { get; set; }
        public IEnumerable<CustomOrderItemReadDto> CustomOrderItems { get; set; }
        public IEnumerable<StandardOrderItemReadDto> StandardOrderItems { get; set; }
    }
}