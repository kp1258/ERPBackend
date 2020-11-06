using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class StandardProductUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dimensions { get; set; }
        [Required]
        public int standardProductCategoryId { get; set; }
    }
}