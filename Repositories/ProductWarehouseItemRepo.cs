using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class ProductWarehouseItemRepository : RepositoryBase<ProductWarehouseItem>, IProductWarehouseItemRepository
    {
        public ProductWarehouseItemRepository(ERPContext erpContext) : base(erpContext)
        {

        }

        public void CreateItem(ProductWarehouseItem item)
        {
            Create(item);
        }

        public void DeleteItem(ProductWarehouseItem item)
        {
            Delete(item);
        }

        public async Task<IEnumerable<ProductWarehouseItem>> GetAllItemsAsync()
        {
            return await FindAll()
                            .OrderBy(item => item.StandardProduct.Name)
                            .Include(i => i.StandardProduct)
                                .ThenInclude(i => i.StandardProductCategory)
                            .ToListAsync();
        }

        public async Task<IEnumerable<ProductWarehouseItem>> GetAllItemsBaseAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<ProductWarehouseItem> GetItemByIdAsync(int itemId)
        {
            return await FindByCondition(item => item.ProductWarehouseItemId.Equals(itemId))
                            .Include(i => i.StandardProduct)
                            .FirstOrDefaultAsync();
        }

        public async Task<ProductWarehouseItem> GetItemByProductIdAsync(int productId)
        {
            return await FindByCondition(i => i.StandardProductId.Equals(productId))
                            .FirstOrDefaultAsync();
        }

        public void UpdateItem(ProductWarehouseItem item)
        {
            Update(item);
        }
    }
}