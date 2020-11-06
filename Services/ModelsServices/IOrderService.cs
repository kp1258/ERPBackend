using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;
using ERPBackend.Entities.QueryParameters;

namespace ERPBackend.Services.ModelsServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDetails>> GetAllOrderDetails(OrderParameters parameters);
        Task<OrderDetails> GetOrderDetails(int orderId);
        Task FulfillOrder(int orderId);
        Task PlaceOrder(Order orderEntity);

        Task AccepOrderToRealization(Order order, int warehousemanId);
        Task CompleteOrder(Order order);
    }
}