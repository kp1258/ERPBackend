using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class CustomProductAddSolutionDto
    {
        public string SolutionDescription { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}