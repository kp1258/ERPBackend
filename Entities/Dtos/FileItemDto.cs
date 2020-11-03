using Microsoft.AspNetCore.Http;

namespace ERPBackend.Entities.Dtos
{
    public class FileItemReadDto
    {
        public int FileItemId { get; set; }
        public int CustomProductId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }
    }

    public class FileItemCreateDto
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }
        public string BlobName { get; set; }
    }
}