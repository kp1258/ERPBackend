using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class StandardProductUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dimensions { get; set; }
        [Required]
        public int StandardProductCategoryId { get; set; }

        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}