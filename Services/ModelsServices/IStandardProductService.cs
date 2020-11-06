using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Services.ModelsServices
{
    public interface IStandardProductService
    {
        Task CreateStandardProduct(StandardProduct productEntity, StandardProductCreateDto product);
        Task UpdateStandardProduct(StandardProduct product);
        Task<IEnumerable<MissingProduct>> GetAllMissingProducts();
    }
}