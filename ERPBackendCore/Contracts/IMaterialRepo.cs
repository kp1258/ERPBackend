using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllMaterialsAsync();
        Task<Material> GetMaterialByIdAsync(int materialId);
        void CreateMaterial(Material material);
        void UpdateMaterial(Material material);
        void DelteMaterial(Material material);
    }
}