using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class CustomProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string OrderDescription { get; set; }
        [Required]
        public IEnumerable<FileItemCreateDto> FileList { get; set; }
    }
}