using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class CustomProductCreateDto
    {
        public string Name { get; set; }
        public string OrderDescription { get; set; }
        public IEnumerable<FileItemCreateDto> FileList { get; set; }
    }
}