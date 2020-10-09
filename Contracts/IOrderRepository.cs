using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        IEnumerable<Order> GetOrdersBySalesman(int salesmanId);
        IEnumerable<Order> GetOrdersByStatus(OrderStatus status);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);

    }
}