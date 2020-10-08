using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void GetOrdersBySalesman(int id);
        void GetOrdersByStatus(OrderStatus status);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);

    }
}