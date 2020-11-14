using System.Threading.Tasks;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public interface ICustomProductService
    {
        Task AddSolution(CustomProduct product, CustomProductAddSolutionDto solution);
        Task AcceptToPreparation(CustomProduct product, int technologistId);
    }
}