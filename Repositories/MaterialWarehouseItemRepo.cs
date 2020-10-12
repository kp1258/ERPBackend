using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<MaterialWarehouseItem> GetAllItems()
        {
            return FindAll()
                    .OrderBy(item => item.Material.Name)
                    .Include(i => i.Material)
                    .ToList();
        }

        public MaterialWarehouseItem GetItemById(int itemId)
        {
            return FindByCondition(item => item.MaterialWarehouseItemId.Equals(itemId))
                    .Include(i => i.Material)
                    .FirstOrDefault();
        }

        public void UpdateItem(MaterialWarehouseItem item)
        {
            Update(item);
        }
    }
}