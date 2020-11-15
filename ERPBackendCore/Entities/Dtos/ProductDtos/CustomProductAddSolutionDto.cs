using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class CustomProductAddSolutionDto
    {
        [Required]
        public string SolutionDescription { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}