using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class StandardProductPatchDto
    {
        [Required]
        public string Status { get; set; }
    }
}