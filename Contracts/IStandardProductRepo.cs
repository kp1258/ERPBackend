using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IStandardProductRepository : IRepositoryBase<StandardProduct>
    {
        Task<IEnumerable<StandardProduct>> GetAllProductsAsync();
        Task<StandardProduct> GetProductByIdAsync(int productId);
        void CreateProduct(StandardProduct product);
        void UpdateProduct(StandardProduct product);
        void DeleteProduct(StandardProduct product);

    }
}