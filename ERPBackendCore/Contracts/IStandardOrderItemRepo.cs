using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IStandardOrderItemRepository
    {
        Task<IEnumerable<StandardOrderItem>> GetAllItemsAsync();
        Task<StandardOrderItem> GetItemByIdAsync(int itemId);
        Task<IEnumerable<StandardOrderItem>> GetAllItemsFromActiveOrders();
        Task<IEnumerable<StandardOrderItem>> GetAllItemsByOrder(int orderId);
        void CreateItem(StandardOrderItem item);
        void UpdateItem(StandardOrderItem item);
        void DeleteItem(StandardOrderItem item);

    }

}