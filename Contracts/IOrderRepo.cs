using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> GetOrderDetailsByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrdersBySalesmanAsync(int salesmanId);
        Task<IEnumerable<Order>> GetAllActiveOrdersByWarehouseman(int warehousemanId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);

    }
}