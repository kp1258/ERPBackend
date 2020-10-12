using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPBackend.Entities.Models
{
    public class ProductWarehouseItem
    {
        public int ProductWarehouseItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int StandardProductId { get; set; }
        public StandardProduct StandardProduct { get; set; }
    }
}