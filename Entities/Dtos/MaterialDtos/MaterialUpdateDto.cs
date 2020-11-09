using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.MaterialDtos
{
    public class MaterialUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}