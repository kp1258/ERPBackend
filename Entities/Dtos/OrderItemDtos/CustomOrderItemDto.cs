using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos.OrderItemDtos
{
    public class CustomOrderItemDto
    {
        public CustomProductReadDto CustomProduct { get; set; }
        public int Quantity { get; set; }
    }
}