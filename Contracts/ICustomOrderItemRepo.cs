using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface ICustomOrderItemRepository : IRepositoryBase<CustomOrderItem>
    {
        Task<IEnumerable<CustomOrderItem>> GetAllItemsAsync();
        Task<CustomOrderItem> GetItemByIdAsync(int itemId);
        Task<IEnumerable<CustomOrderItem>> GetAllActiveItemsBySalesman(int salesmanId);
        Task<IEnumerable<CustomOrderItem>> GetAllActiveItemsByProductionManager(int productionManagerId);
        Task<IEnumerable<CustomOrderItem>> GetAllOrderedItemsWithSolution(); 
        void CreateItem(CustomOrderItem item);
        void UpdateItem(CustomOrderItem item);
        void DeleteItem(CustomOrderItem item);
    }

}