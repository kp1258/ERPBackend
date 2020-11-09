using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.MaterialDtos
{
    public class MaterialReadDto
    {
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}