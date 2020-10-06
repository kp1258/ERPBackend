using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPBackend.Entities
{
    public class MaterialItem
    {
        public int MaterialItemId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}