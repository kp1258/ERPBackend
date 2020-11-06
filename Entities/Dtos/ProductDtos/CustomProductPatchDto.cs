using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class CustomProductPatchDto
    {
        [Required]
        public string Status { get; set; }
    }
}