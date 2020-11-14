using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ERPBackend.Entities.Dtos.OrderItemDtos;

namespace ERPBackend.Entities.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int SalesmanId { get; set; }
        public ICollection<CustomOrderItemCreateDto> CustomOrderItems { get; set; }
        public ICollection<StandardOrderItemCreateDto> StandardOrderItems { get; set; }
    }
}