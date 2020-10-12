using System.Collections.Generic;
using System.Linq;
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

    public IEnumerable<Order> GetAllOrders()
    {
        return FindAll().OrderBy(order => order.PlacingDate).ToList();
    }

    public Order GetOrderDetailsById(int orderId)
    {
        return FindByCondition(order => order.OrderId.Equals(orderId))
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
                .FirstOrDefault();
    }

    public Order GetOrderById(int orderId)
    {
        return FindByCondition(order => order.OrderId.Equals(orderId)).FirstOrDefault();
    }

    public IEnumerable<Order> GetOrdersBySalesman(int salesmanId)
    {
        return FindByCondition(order => order.SalesmanId.Equals(salesmanId)).ToList();
    }

    public IEnumerable<Order> GetOrdersByStatus(OrderStatus status)
    {
        return FindByCondition(order => order.Status.Equals(status)).ToList();
    }

    public void UpdateOrder(Order order)
    {
        Update(order);
    }
}