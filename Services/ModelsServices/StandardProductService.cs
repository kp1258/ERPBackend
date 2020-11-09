using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Services.ModelsServices
{
    public class StandardProductService : IStandardProductService
    {
        private IRepositoryWrapper _repository;
        public IBlobStorageService _blobStorageService;

        public StandardProductService(IRepositoryWrapper repositoryWrapper, IBlobStorageService blobStorageService)
        {
            _repository = repositoryWrapper;
            _blobStorageService = blobStorageService;

        }
        public async Task CreateStandardProduct(StandardProduct productEntity, StandardProductCreateDto product)
        {
            if (product.ImageFile != null)
            {
                var blobName = _blobStorageService.GenerateFileName(product.ImageName);
                var filePath = await _blobStorageService.UploadFileBlobAsync(product.ImageFile, blobName, "standardproducts");
                productEntity.ImageName = product.ImageName;
                productEntity.ImagePath = filePath;
                productEntity.BlobName = blobName;
            }


            productEntity.Status = StandardProductStatus.Produced;

            _repository.StandardProduct.CreateProduct(productEntity);
            await _repository.SaveAsync();

            var productWarehouseItem = new ProductWarehouseItem()
            {
                StandardProductId = productEntity.StandardProductId,
                Quantity = 0
            };
            _repository.ProductWarehouseItem.CreateItem(productWarehouseItem);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<MissingProduct>> GetAllMissingProducts()
        {
            var standardOrderItems = await _repository.StandardOrderItem.GetAllItemsFromActiveOrders();

            var orderedProducts = standardOrderItems
                            .GroupBy(i => i.StandardProductId)
                            .Select(i => new { productId = i.Key, quantity = i.Sum(i => i.Quantity) });
            List<MissingProduct> missingProducts = new List<MissingProduct>();
            var items = await _repository.ProductWarehouseItem.GetAllItemsAsync();

            foreach (var orderedProduct in orderedProducts)
            {
                var item = items.FirstOrDefault(i => i.StandardProductId.Equals(orderedProduct.productId));
                if (item.Quantity < orderedProduct.quantity)
                {
                    var missingQuantity = orderedProduct.quantity - item.Quantity;
                    var missingProduct = new MissingProduct
                    {
                        StandardProductId = item.StandardProductId,
                        StandardProduct = item.StandardProduct,
                        Quantity = missingQuantity
                    };
                    missingProducts.Add(missingProduct);
                }

            }
            return missingProducts;
        }

        public async Task UpdateStandardProduct(StandardProduct productEntity, StandardProductUpdateDto product)
        {
            if (product.ImageFile != null)
            {
                var blobName = _blobStorageService.GenerateFileName(productEntity.ImageName);
                var filePath = await _blobStorageService.UploadFileBlobAsync(product.ImageFile, blobName, "standardproducts");
                productEntity.ImagePath = filePath;
                productEntity.BlobName = blobName;
            }
            productEntity.StandardProductCategoryId = product.StandardProductCategoryId;

            var category = await _repository.StandardProductCategory.GetCategoryByIdAsync(productEntity.StandardProductCategoryId);
            productEntity.StandardProductCategory = category;

            _repository.StandardProduct.UpdateProduct(productEntity);
            await _repository.SaveAsync();
        }
    }
}