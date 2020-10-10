using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetAllMaterials();
        Material GetMaterialById(int materialId);
        void CreateMaterial(Material material);
        void UpdateMaterial(Material material);
        void DelteMaterial(Material material);
    }
}