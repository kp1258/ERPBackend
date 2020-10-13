using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IProductWarehouseItemRepository : IRepositoryBase<ProductWarehouseItem>
    {
        Task<IEnumerable<ProductWarehouseItem>> GetAllItemsAsync();
        Task<ProductWarehouseItem> GetItemByIdAsync(int itemId);
        void CreateItem(ProductWarehouseItem item);
        void UpdateItem(ProductWarehouseItem item);
        void DelteItem(ProductWarehouseItem item);
    }
}