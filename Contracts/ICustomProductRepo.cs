using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface ICustomProductRepository : IRepositoryBase<CustomProduct>
    {
        IEnumerable<CustomProduct> GetAllProducts();
        CustomProduct GetProductById(int productId);
        void CreateProduct(CustomProduct product);
        void UpdateProduct(CustomProduct product);
        void DeleteProduct(CustomProduct product);
    }
}