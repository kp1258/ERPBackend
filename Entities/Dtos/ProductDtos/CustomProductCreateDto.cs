using System.Collections.Generic;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class CustomProductCreateDto
    {
        public string Name { get; set; }
        public string OrderDescription { get; set; }
        public IEnumerable<FileItemCreateDto> OrderFileList { get; set; }
    }
}