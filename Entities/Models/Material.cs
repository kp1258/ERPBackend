using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ERPBackend.Entities.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public MaterialWarehouseItem MaterialItem { get; set; }
    }
}