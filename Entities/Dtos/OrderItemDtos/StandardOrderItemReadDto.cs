using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos.OrderItemDtos
{
    public class StandardOrderItemReadDto
    {
        public StandardProductReadDto StandardProduct { get; set; }
        public int Quantity { get; set; }
    }
}