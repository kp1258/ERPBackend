using System.ComponentModel.DataAnnotations;
using ERPBackend.Entities.Dtos.MaterialDtos;

namespace ERPBackend.Entities.Dtos.WarehouseDtos
{
    public class MaterialWarehouseItemReadDto
    {
        [Required]
        public int MaterialWarehouseItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public MaterialReadDto Material { get; set; }
    }
}