using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPBackend.Entities.Models
{
    public class MaterialWarehouseItem
    {
        public int MaterialWarehouseItemId { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}