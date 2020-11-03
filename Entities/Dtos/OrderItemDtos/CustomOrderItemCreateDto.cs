using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos.OrderItemDtos
{
    public class CustomOrderItemCreateDto
    {
        public CustomProductCreateDto CustomProduct { get; set; }
        public int Quantity { get; set; }
    }
}