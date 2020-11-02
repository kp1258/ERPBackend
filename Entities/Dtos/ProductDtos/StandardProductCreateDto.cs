using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class StandardProductCreateDto
    {
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public int StandardProductCategoryId { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}