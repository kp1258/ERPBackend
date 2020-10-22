using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Services
{
    public interface IOrderManagementService
    {
        Task<IEnumerable<MissingProduct>> GetAllMissingProducts();
        Task<IEnumerable<OrderDetails>> GetAllOrderDetailsByWarehouseman(int warehousemanId);
        Task<OrderDetails> GetOrderDetails(int orderId);
    }
}