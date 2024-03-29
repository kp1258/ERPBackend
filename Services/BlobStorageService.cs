using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using ERPBackend.Entities.Models.Additional;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Models;
using ERPBackend.Contracts;

namespace ERPBackend.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IRepositoryWrapper _repository;

        public BlobStorageService(BlobServiceClient blobServiceClient, IRepositoryWrapper repositoryWrapper)
        {
            _blobServiceClient = blobServiceClient;
            _repository = repositoryWrapper;
        }
        public async Task DeleteBlobAsync(string blobName, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task DownloadFileBlobAsync(string blobName, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            var blobDownloadInfo = await blobClient.DownloadAsync();
        }

        public async Task<IEnumerable<string>> ListBlobsAsync(string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var items = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            };
            return items;
        }

        public async Task<string> UploadFileBlobAsync(IFormFile file, string fileName, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            using (var fileStream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(fileStream);
            }
            var fileUri = blobClient.Uri.AbsoluteUri;
            return fileUri;
        }


        public string GenerateFileName(string fileName)
        {
            string strFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileName;
            return strFileName;
        }

        public async Task UploadSolutionFilesAsync(int productId, IFormFileCollection files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    string blobName = GenerateFileName(file.FileName);
                    string filePath = await UploadFileBlobAsync(file, blobName, "customproductssolutions");
                    var fileItem = new FileItem
                    {
                        CustomProductId = productId,
                        FileName = file.FileName,
                        FilePath = filePath,
                        BlobName = blobName,
                        Type = FileType.Solution,
                    };
                    _repository.FileItem.CreateItem(fileItem);
                }
                await _repository.SaveAsync();
            }
            else
            {
                Console.WriteLine("Files is null");
            }

        }

        public async Task UploadOrderFilesAsync(IEnumerable<FileItem> files)
        {
            if (files != null)
            {
                foreach (var fileItem in files)
                {
                    var file = fileItem.File;
                    string blobName = GenerateFileName(file.FileName);
                    string filePath = await UploadFileBlobAsync(file, blobName, "customproductsorders");
                    fileItem.BlobName = blobName;
                    fileItem.FilePath = filePath;
                    _repository.FileItem.UpdateItem(fileItem);
                }
                await _repository.SaveAsync();
            }
            else
            {
                Console.WriteLine("Files is null");
            }
        }
    }

}