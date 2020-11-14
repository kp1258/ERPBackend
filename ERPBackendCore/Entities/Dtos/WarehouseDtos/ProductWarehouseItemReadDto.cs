using System.ComponentModel.DataAnnotations;
using ERPBackend.Entities.Dtos.ProductDtos;

namespace ERPBackend.Entities.Dtos.WarehouseDtos
{
    public class ProductWarehouseItemReadDto
    {
        [Required]
        public int ProductWarehouseItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public StandardProductReadDto StandardProduct { get; set; }
    }
}