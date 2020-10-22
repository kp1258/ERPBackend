using System;
using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos
{
    public class CustomOrderItemReadDto
    {
        public int CustomOrderItemId { get; set; }
        public CustomProductReadDto CustomProduct { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime CompletionDate { get; set; }
    }

    public class CustomOrderItemUpdateDto
    {
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}