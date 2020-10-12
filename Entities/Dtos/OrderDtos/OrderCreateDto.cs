using System;
using System.Collections.Generic;
using ERPBackend.Entities.Dtos.OrderItemDtos;

namespace ERPBackend.Entities.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        public string Type { get; set; }
        public int ClientId { get; set; }
        public int SalesmanId { get; set; }
        public ICollection<CustomOrderItemCreateDto> CustomOrderItems { get; set; }
        public ICollection<StandardOrderItemCreateDto> StandardOrderItems { get; set; }
    }
}