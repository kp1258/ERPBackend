using System.Collections.Generic;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using System.Linq;

namespace ERPBackend.Repositories
{
    public class CustomProductRepository : RepositoryBase<CustomProduct>, ICustomProductRepository
    {
        public CustomProductRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public IEnumerable<CustomProduct> GetAllProducts()
        {
            return FindAll().OrderBy(products => products.Name).ToList();
        }

        public CustomProduct GetProductById(int productId)
        {
            return FindByCondition(product => product.CustomProductId.Equals(productId)).FirstOrDefault();
        }

        public void CreateProduct(CustomProduct product)
        {
            Create(product);
        }

        public void DeleteProduct(CustomProduct product)
        {
            Delete(product);
        }

        public void UpdateProduct(CustomProduct product)
        {
            Update(product);
        }
    }
}