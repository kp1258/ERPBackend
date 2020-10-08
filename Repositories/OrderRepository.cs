using System.Collections.Generic;
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
        throw new System.NotImplementedException();
    }

    public void DeleteOrder(Order order)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<Order> GetAllOrders()
    {
        throw new System.NotImplementedException();
    }

    public Order GetOrderById(int id)
    {
        throw new System.NotImplementedException();
    }

    public void GetOrdersBySalesman(int id)
    {
        throw new System.NotImplementedException();
    }

    public void GetOrdersByStatus(OrderStatus status)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateOrder(Order order)
    {
        throw new System.NotImplementedException();
    }
}