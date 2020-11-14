using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos.OrderItemDtos
{
    public class StandardOrderItemCreateDto
    {
        public int StandardProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class StandardOrderItemReadDto
    {
        public StandardProductReadDto StandardProduct { get; set; }
        public int Quantity { get; set; }
    }

}