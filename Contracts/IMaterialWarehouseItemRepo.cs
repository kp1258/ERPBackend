using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IMaterialWarehouseItemRepository : IRepositoryBase<MaterialWarehouseItem>
    {
        IEnumerable<MaterialWarehouseItem> GetAllItems();
        MaterialWarehouseItem GetItemById(int itemId);
        void CreateItem(MaterialWarehouseItem item);
        void UpdateItem(MaterialWarehouseItem item);
        void DelteItem(MaterialWarehouseItem item);
    }
}