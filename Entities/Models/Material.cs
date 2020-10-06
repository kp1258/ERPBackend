using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ERPBackend.Entities.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public MaterialItem MaterialItem { get; set; }
    }
}