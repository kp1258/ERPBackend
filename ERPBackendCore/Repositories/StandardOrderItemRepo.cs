using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class StandardOrderItemRepository : RepositoryBase<StandardOrderItem>, IStandardOrderItemRepository
    {
        public StandardOrderItemRepository(ERPContext erpContext) : base(erpContext)
        {

        }

        public async Task<IEnumerable<StandardOrderItem>> GetAllItemsAsync()
        {
            return await FindAll()
                    .Include(i => i.StandardProduct)
                    .ToListAsync();
        }

        public async Task<StandardOrderItem> GetItemByIdAsync(int itemId)
        {
            return await FindByCondition(i => i.StandardOrderItemId.Equals(itemId))
                         .FirstOrDefaultAsync();
        }

        public void UpdateItem(StandardOrderItem item)
        {
            Update(item);
        }
        public void CreateItem(StandardOrderItem item)
        {
            Create(item);
        }

        public void DeleteItem(StandardOrderItem item)
        {
            Delete(item);
        }

        public async Task<IEnumerable<StandardOrderItem>> GetAllItemsFromActiveOrders()
        {
            return await FindByCondition(i => i.Order.Status == OrderStatus.InRealization)
                            .ToListAsync();
        }

        public async Task<IEnumerable<StandardOrderItem>> GetAllItemsByOrder(int orderId)
        {
            return await FindByCondition(i => i.OrderId.Equals(orderId))
                            .Include(i => i.StandardProduct)
                            .ThenInclude(p => p.StandardProductCategory)
                            .ToListAsync();
        }
    }
}