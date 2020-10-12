using System.Collections.Generic;
using System.Linq;
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

        public void DelteItem(ProductWarehouseItem item)
        {
            Delete(item);
        }

        public IEnumerable<ProductWarehouseItem> GetAllItems()
        {
            return FindAll()
                    .OrderBy(item => item.StandardProduct.Name)
                    .Include(i => i.StandardProduct)
                    .ToList();
        }

        public ProductWarehouseItem GetItemById(int itemId)
        {
            return FindByCondition(item => item.ProductWarehouseItemId.Equals(itemId))
                    .Include(i => i.StandardProduct)
                    .FirstOrDefault();
        }

        public void UpdateItem(ProductWarehouseItem item)
        {
            Update(item);
        }
    }
}