using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using ERPBackend.Repositories;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(ERPContext erpContext) : base(erpContext)
    {

    }

    public void CreateOrder(Order order)
    {
        Create(order);
    }

    public void DeleteOrder(Order order)
    {
        Delete(order);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await FindAll().OrderBy(order => order.PlacingDate)
                        .ToListAsync();
    }

    public async Task<Order> GetOrderDetailsByIdAsync(int orderId)
    {
        return await FindByCondition(order => order.OrderId.Equals(orderId))
                        .OrderBy(order => order.PlacingDate)
                        .Include(o => o.Client)
                            .ThenInclude(c => c.Address)
                        .Include(o => o.Salesman)
                        .Include(o => o.Warehouseman)
                        .Include(o => o.CustomOrderItems)
                            .ThenInclude(o => o.CustomProduct)
                        .Include(o => o.StandardOrderItems)
                            .ThenInclude(o => o.StandardProduct)
                                .ThenInclude(o => o.StandardProductCategory)
                        .FirstOrDefaultAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
        return await FindByCondition(order => order.OrderId.Equals(orderId))

                        .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersBySalesmanAsync(int salesmanId)
    {
        return await FindByCondition(order => order.SalesmanId.Equals(salesmanId))
                        .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetAllActiveOrdersByWarehouseman(int warehousemanId)
    {
        return await FindByCondition(o => (o.WarehousemanId.Equals(warehousemanId)) && (o.Status == OrderStatus.InRealization))
                        .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await FindByCondition(order => order.Status.Equals(status))
                        .ToListAsync();
    }

    public void UpdateOrder(Order order)
    {
        Update(order);
    }

}