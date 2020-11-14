using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.QueryParameters;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class CustomOrderItemRepository : RepositoryBase<CustomOrderItem>, ICustomOrderItemRepository
    {
        public CustomOrderItemRepository(ERPContext erpContext) : base(erpContext)
        {

        }

        public async Task<IEnumerable<CustomOrderItem>> GetAllActiveItemsBySalesman(int salesmanId)
        {
            return await FindByCondition(i => (i.Order.SalesmanId.Equals(salesmanId)) && (i.Order.Status != OrderStatus.Completed))
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.Technologist)
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.FileList)
                            .ToListAsync();
        }

        public async Task<IEnumerable<CustomOrderItem>> GetAllItemsAsync()
        {
            return await FindAll()
                            .Include(i => i.CustomProduct)
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.Technologist)
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.FileList)
                            .ToListAsync();
        }

        public async Task<CustomOrderItem> GetItemByIdAsync(int itemId)
        {
            return await FindByCondition(i => i.CustomOrderItemId.Equals(itemId))
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.Technologist)
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.FileList)
                            .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<CustomOrderItem>> GetAllActiveItemsByProductionManager(int productionManagerId)
        {
            return await FindByCondition(i => (i.ProductionManagerId.Equals(productionManagerId)) && (i.Status == CustomOrderItemStatus.InProduction))
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.Technologist)
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.FileList)
                            .ToListAsync();
        }

        public void UpdateItem(CustomOrderItem item)
        {
            Update(item);
        }
        public void CreateItem(CustomOrderItem item)
        {
            Create(item);
        }

        public void DeleteItem(CustomOrderItem item)
        {
            Delete(item);
        }

        public async Task<IEnumerable<CustomOrderItem>> GetAllOrderedItemsWithSolution()
        {
            return await FindByCondition(
                            i => (i.Status == CustomOrderItemStatus.Ordered)
                            && (i.CustomProduct.Status == CustomProductStatus.Prepared))
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.Technologist)
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.FileList)
                            .ToListAsync();
        }

        public async Task<IEnumerable<CustomOrderItem>> GetAllActiveItems(CustomOrderItemPrameters parameters)
        {
            if (parameters.SalesmanId == 0 && parameters.ProductionManagerId == 0 && parameters.WarehousemanId == 0)
            {
                return await FindByCondition(i => ((i.Status == CustomOrderItemStatus.InProduction)
                                            && i.Order.Status == OrderStatus.InRealization && i.CustomProduct.Status == CustomProductStatus.Prepared))
                                                .Include(i => i.CustomProduct)
                                                    .ThenInclude(i => i.Technologist)
                                                .Include(i => i.CustomProduct)
                                                    .ThenInclude(i => i.FileList)
                                                .ToListAsync();
            }
            else
            {
                return await FindByCondition(i => (i.Status == CustomOrderItemStatus.InProduction)
                                        && (i.Order.Status == OrderStatus.InRealization && i.CustomProduct.Status == CustomProductStatus.Prepared)
                                        && ((i.ProductionManagerId.Equals(parameters.ProductionManagerId))
                                        || (i.Order.WarehousemanId.Equals(parameters.WarehousemanId))
                                        || (i.Order.SalesmanId.Equals(parameters.SalesmanId))))
                                        .Include(i => i.CustomProduct)
                                            .ThenInclude(i => i.Technologist)
                                        .Include(i => i.CustomProduct)
                                            .ThenInclude(i => i.FileList)
                                        .ToListAsync();
            }

        }

        public async Task<IEnumerable<CustomOrderItem>> GetAllItemsHistory(CustomOrderItemPrameters parameters)
        {
            if (parameters.SalesmanId == 0 && parameters.ProductionManagerId == 0 && parameters.WarehousemanId == 0)
            {
                return await FindByCondition(i => (i.Status == CustomOrderItemStatus.Completed))
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.Technologist)
                            .Include(i => i.CustomProduct)
                                .ThenInclude(i => i.FileList)
                            .ToListAsync();
            }
            else
            {
                return await FindByCondition(i => (i.Status == CustomOrderItemStatus.Completed)
                                        && ((i.ProductionManagerId.Equals(parameters.ProductionManagerId))
                                        || (i.Order.WarehousemanId.Equals(parameters.WarehousemanId))
                                        || (i.Order.SalesmanId.Equals(parameters.SalesmanId))))
                                        .Include(i => i.CustomProduct)
                                            .ThenInclude(i => i.Technologist)
                                        .Include(i => i.CustomProduct)
                                            .ThenInclude(i => i.FileList)
                                        .ToListAsync();
            }

        }

        public async Task<IEnumerable<CustomOrderItem>> GetAllItemsFromActiveOrders(CustomOrderItemPrameters parameters)
        {
            if (parameters.SalesmanId == 0 && parameters.ProductionManagerId == 0 && parameters.WarehousemanId == 0)
            {
                return await FindByCondition(i => (i.Order.Status == OrderStatus.Placed || i.Order.Status == OrderStatus.InRealization))
                .Include(i => i.CustomProduct)
                    .ThenInclude(i => i.Technologist)
                .Include(i => i.CustomProduct)
                    .ThenInclude(i => i.FileList)
                .ToListAsync();
            }
            else
            {
                return await FindByCondition(i => (i.Order.Status == OrderStatus.Placed || i.Order.Status == OrderStatus.InRealization)
                                        && ((i.ProductionManagerId.Equals(parameters.ProductionManagerId))
                                        || (i.Order.WarehousemanId.Equals(parameters.WarehousemanId))
                                        || (i.Order.SalesmanId.Equals(parameters.SalesmanId))))
                                        .Include(i => i.CustomProduct)
                                            .ThenInclude(i => i.Technologist)
                                        .Include(i => i.CustomProduct)
                                            .ThenInclude(i => i.FileList)
                                        .ToListAsync();
            }

        }

        public async Task<IEnumerable<CustomOrderItem>> GetAllItemsFromOrdersHistory(CustomOrderItemPrameters parameters)
        {
            if (parameters.SalesmanId == 0 && parameters.ProductionManagerId == 0 && parameters.WarehousemanId == 0)
            {
                return await FindByCondition(i => (i.Order.Status == OrderStatus.Completed))
                        .Include(i => i.CustomProduct)
                            .ThenInclude(i => i.Technologist)
                        .Include(i => i.CustomProduct)
                            .ThenInclude(i => i.FileList)
                        .ToListAsync();
            }
            else
            {
                return await FindByCondition(i => (i.Order.Status == OrderStatus.Completed)
                                        && ((i.ProductionManagerId.Equals(parameters.ProductionManagerId))
                                        || (i.Order.WarehousemanId.Equals(parameters.WarehousemanId))
                                        || (i.Order.SalesmanId.Equals(parameters.SalesmanId))))
                                        .Include(i => i.CustomProduct)
                                            .ThenInclude(i => i.Technologist)
                                        .Include(i => i.CustomProduct)
                                            .ThenInclude(i => i.FileList)
                                        .ToListAsync();
            }

        }
    }
}