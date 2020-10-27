using System.Collections.Generic;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ERPBackend.Repositories
{
    public class CustomProductRepository : RepositoryBase<CustomProduct>, ICustomProductRepository
    {
        public CustomProductRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public async Task<IEnumerable<CustomProduct>> GetAllProductsAsync()
        {
            return await FindAll()
                            .OrderBy(products => products.Name)
                            .Include(p => p.Technologist)
                            .ToListAsync();
        }

        public async Task<CustomProduct> GetProductByIdAsync(int productId)
        {
            return await FindByCondition(product => product.CustomProductId.Equals(productId))
                            .Include(p => p.Technologist)
                            .FirstOrDefaultAsync();
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

        public async Task<IEnumerable<CustomProduct>> GetAllProductsByTechnologist(int technologistId)
        {
            return await FindByCondition(p => p.TechnologistId.Equals(technologistId))
                            .ToListAsync();
        }

        public async Task<IEnumerable<CustomProduct>> GetAllProductsByStatus(CustomProductStatus status)
        {
            return await FindByCondition(p => p.Status == status)
                            .ToListAsync();
        }

        public async Task<IEnumerable<CustomProduct>> GetAllProductsByTechnologistAndStatus(int technologistId, CustomProductStatus status)
        {
            return await FindByCondition(p => (p.Status == status && p.TechnologistId.Equals(technologistId)))
                        .ToListAsync();
        }
    }
}