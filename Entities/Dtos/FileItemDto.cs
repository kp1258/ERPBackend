using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ERPBackend.Entities.Dtos
{
    public class FileItemReadDto
    {
        public int FileItemId { get; set; }
        public int CustomProductId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string Type { get; set; }
    }

    public class FileItemCreateDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Type { get; set; }
    }
}