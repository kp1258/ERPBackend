using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class MaterialWarehouseItemRepository : RepositoryBase<MaterialWarehouseItem>, IMaterialWarehouseItemRepository
    {
        public MaterialWarehouseItemRepository(ERPContext erpContext) : base(erpContext)
        {

        }

        public void CreateItem(MaterialWarehouseItem item)
        {
            Create(item);
        }

        public void DelteItem(MaterialWarehouseItem item)
        {
            Delete(item);
        }

        public async Task<IEnumerable<MaterialWarehouseItem>> GetAllItemsAsync()
        {
            return await FindAll()
                            .OrderBy(item => item.Material.Name)
                            .Include(i => i.Material)
                            .ToListAsync();
        }

        public async Task<MaterialWarehouseItem> GetItemByIdAsync(int itemId)
        {
            return await FindByCondition(item => item.MaterialWarehouseItemId.Equals(itemId))
                    .Include(i => i.Material)
                    .FirstOrDefaultAsync();
        }

        public void UpdateItem(MaterialWarehouseItem item)
        {
            Update(item);
        }
    }
}