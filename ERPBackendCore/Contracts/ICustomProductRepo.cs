using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface ICustomProductRepository : IRepositoryBase<CustomProduct>
    {
        Task<IEnumerable<CustomProduct>> GetAllProductsAsync();
        Task<CustomProduct> GetProductByIdAsync(int productId);
        Task<IEnumerable<CustomProduct>> GetAllProductsByTechnologist(int technologistId);
        Task<IEnumerable<CustomProduct>> GetAllProductsByTechnologistAndStatus(int technologistId, CustomProductStatus status);
        Task<IEnumerable<CustomProduct>> GetAllProductsByStatus(CustomProductStatus status);
        void CreateProduct(CustomProduct product);
        void UpdateProduct(CustomProduct product);
        void DeleteProduct(CustomProduct product);
    }
}