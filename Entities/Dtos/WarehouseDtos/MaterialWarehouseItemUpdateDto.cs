using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.WarehouseDtos
{
    public class MaterialWarehouseItemUpdateDto
    {
        [Required]
        public int Quantity { get; set; }
    }
}