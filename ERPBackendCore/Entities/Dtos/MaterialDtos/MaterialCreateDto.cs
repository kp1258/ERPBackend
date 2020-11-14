using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.MaterialDtos
{
    public class MaterialCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}