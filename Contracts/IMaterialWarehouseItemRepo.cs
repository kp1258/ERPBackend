using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IMaterialWarehouseItemRepository : IRepositoryBase<MaterialWarehouseItem>
    {
        Task<IEnumerable<MaterialWarehouseItem>> GetAllItemsAsync();
        Task<MaterialWarehouseItem> GetItemByIdAsync(int itemId);
        void CreateItem(MaterialWarehouseItem item);
        void UpdateItem(MaterialWarehouseItem item);
        void DelteItem(MaterialWarehouseItem item);
    }
}