using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Models.Additional;
using Microsoft.AspNetCore.Http;

namespace ERPBackend.Services
{
    public interface IBlobStorageService
    {
        Task<BlobInfo> GetBlobAsync(string name, string containerName);
        Task<IEnumerable<string>> ListBlobsAsync(string containerName);
        Task<string> UploadFileBlobAsync(IFormFile file, string fileName, string containerName);
        Task DownloadFileBlobAsync(string blobName, string containerName);
        Task DeleteBlobAsync(string blobName, string containerName);
        Task UploadSolutionFilesAsync(int productId, IFormFileCollection files);
        string GenerateFileName(string fileName);

    }
}