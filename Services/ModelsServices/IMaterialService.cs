using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public interface IMaterialService
    {
        Task CreateMaterial(Material material);
    }
}