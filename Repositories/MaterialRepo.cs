using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class MaterialRepository : RepositoryBase<Material>, IMaterialRepository
    {
        public MaterialRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            return await FindAll()
                            .OrderBy(material => material.Name)
                            .ToListAsync();
        }
        public async Task<Material> GetMaterialByIdAsync(int materialId)
        {
            return await FindByCondition(material => material.MaterialId.Equals(materialId))
                            .FirstOrDefaultAsync();
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