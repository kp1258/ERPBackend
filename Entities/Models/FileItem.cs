using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Converters;

namespace ERPBackend.Entities.Models
{
    public class FileItem
    {
        public int FileItemId { get; set; }
        public int CustomProductId { get; set; }
        [ForeignKey("CustomProductId")]
        public CustomProduct CustomProduct { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string BlobName { get; set; }
        [Required]
        public FileType Type { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileType
    {
        [EnumMember(Value = "order")]
        Order,
        [EnumMember(Value = "solution")]
        Solution
    }
}