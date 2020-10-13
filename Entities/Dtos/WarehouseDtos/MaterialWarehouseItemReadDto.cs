using ERPBackend.Entities.Dtos.MaterialDtos;

namespace ERPBackend.Entities.Dtos.WarehouseDtos
{
    public class MaterialWarehouseItemReadDto
    {
        public int MaterialWarehouseItemId { get; set; }
        public int Quantity { get; set; }
        public MaterialReadDto Material { get; set; }
    }
}