using System.Collections.Generic;
using System.Linq;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;

namespace ERPBackend.Repositories
{
    public class StandardProductRepository : RepositoryBase<StandardProduct>, IStandardProductRepository
    {
        public StandardProductRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public IEnumerable<StandardProduct> GetAllProducts()
        {
            return FindAll()
                    .OrderBy(product => product.Name)
                    .ToList();
        }
        public StandardProduct GetProductById(int productId)
        {
            return FindByCondition(product => product.StandardProductId.Equals(productId)).FirstOrDefault();
        }

        public void CreateProduct(StandardProduct product)
        {
            Create(product);
        }
        public void UpdateProduct(StandardProduct product)
        {
            Update(product);
        }

        public void DeleteProduct(StandardProduct product)
        {
            Delete(product);
        }

    }
}