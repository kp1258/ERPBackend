using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;
using ERPBackend.Entities.QueryParameters;

namespace ERPBackend.Services
{
    public interface IOrderManagementService
    {
        Task<IEnumerable<MissingProduct>> GetAllMissingProducts();
        Task<IEnumerable<OrderDetails>> GetAllOrderDetails(OrderParameters parameters);
        // Task<IEnumerable<OrderDetails>> GetAllOrderDetailsByWarehouseman(int warehousemanId);
        Task<OrderDetails> GetOrderDetails(int orderId);
        Task CompleteOrder(int orderId);
        Task PlaceOrder(OrderCreateDto orderCreateDto, Order orderEntity);
    }
}