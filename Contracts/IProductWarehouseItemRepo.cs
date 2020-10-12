using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IProductWarehouseItemRepository : IRepositoryBase<ProductWarehouseItem>
    {
        IEnumerable<ProductWarehouseItem> GetAllItems();
        ProductWarehouseItem GetItemById(int itemId);
        void CreateItem(ProductWarehouseItem item);
        void UpdateItem(ProductWarehouseItem item);
        void DelteItem(ProductWarehouseItem item);
    }
}