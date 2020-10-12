using System.Collections.Generic;
using System.Linq;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;

namespace ERPBackend.Repositories
{
    public class MaterialRepository : RepositoryBase<Material>, IMaterialRepository
    {
        public MaterialRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public IEnumerable<Material> GetAllMaterials()
        {
            return FindAll()
                .OrderBy(material => material.Name)
                .ToList();
        }
        public Material GetMaterialById(int materialId)
        {
            return FindByCondition(material => material.MaterialId.Equals(materialId)).FirstOrDefault();
        }

        public void CreateMaterial(Material material)
        {
            Create(material);
        }

        public void DelteMaterial(Material material)
        {
            Delete(material);
        }

        public void UpdateMaterial(Material material)
        {
            Update(material);
        }
    }
}