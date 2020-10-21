using System;
using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos.OrderItemDtos
{
    public class CustomOrderItemReadDto
    {
        public CustomProductReadDto CustomProduct { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PreparationsStartDate { get; set; }
        public DateTime PreparationCompletionDate { get; set; }
    }
}