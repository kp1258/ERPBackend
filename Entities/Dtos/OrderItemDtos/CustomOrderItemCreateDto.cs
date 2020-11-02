using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos.OrderItemDtos
{
    public class CustomOrderItemCreateDto
    {
        public CustomProductCreateDto customProduct { get; set; }
        public int Quantity { get; set; }
    }
}