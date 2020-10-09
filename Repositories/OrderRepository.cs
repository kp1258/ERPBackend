using System.Collections.Generic;
using System.Linq;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using ERPBackend.Repositories;

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

    public Order GetOrderById(int clientId)
    {
        return FindByCondition(client => client.ClientId.Equals(clientId)).FirstOrDefault();
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