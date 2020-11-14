using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public interface ICustomOrderItemService
    {
        Task CompleteCustomOrderItem(CustomOrderItem item);
        Task AcceptToProduction(CustomOrderItem item, int productionManagerId);
    }
}