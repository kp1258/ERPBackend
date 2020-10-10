using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IStandardProductRepository : IRepositoryBase<StandardProduct>
    {
        IEnumerable<StandardProduct> GetAllProducts();
        StandardProduct GetProductById(int productId);
        void CreateProduct(StandardProduct product);
        void UpdateProduct(StandardProduct product);
        void DeleteProduct(StandardProduct product);

    }
}