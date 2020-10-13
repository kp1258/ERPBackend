using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class StandardProductRepository : RepositoryBase<StandardProduct>, IStandardProductRepository
    {
        public StandardProductRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public async Task<IEnumerable<StandardProduct>> GetAllProductsAsync()
        {
            return await FindAll()
                            .Include(p => p.StandardProductCategory)
                            .OrderBy(product => product.Name)
                            .ToListAsync();
        }
        public async Task<StandardProduct> GetProductByIdAsync(int productId)
        {
            return await FindByCondition(product => product.StandardProductId.Equals(productId))
                            .Include(p => p.StandardProductCategory)
                            .FirstOrDefaultAsync();
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