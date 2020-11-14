using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.WarehouseDtos
{
    public class ProductWarehouseItemUpdateDto
    {
        [Required]
        public int Quantity { get; set; }
    }
}