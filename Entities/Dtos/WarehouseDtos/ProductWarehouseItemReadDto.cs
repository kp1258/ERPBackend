using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos.WarehouseDtos
{
    public class ProductWarehouseItemReadDto
    {
        public int ProductWarehouseItemId { get; set; }
        public int Quantity { get; set; }
        public StandardProductReadDto StandardProduct { get; set; }
    }
}