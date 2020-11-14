using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IProductWarehouseItemRepository : IRepositoryBase<ProductWarehouseItem>
    {
        Task<IEnumerable<ProductWarehouseItem>> GetAllItemsAsync();
        Task<IEnumerable<ProductWarehouseItem>> GetAllItemsBaseAsync();
        Task<ProductWarehouseItem> GetItemByIdAsync(int itemId);
        Task<ProductWarehouseItem> GetItemByProductIdAsync(int productId);
        void CreateItem(ProductWarehouseItem item);
        void UpdateItem(ProductWarehouseItem item);
        void DelteItem(ProductWarehouseItem item);
    }
}