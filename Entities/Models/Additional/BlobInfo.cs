using System.IO;

namespace ERPBackend.Entities.Models.Additional
{
    public class BlobInfo
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }
    }
}