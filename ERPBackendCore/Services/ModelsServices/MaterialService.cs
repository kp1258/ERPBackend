using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public class MaterialService : IMaterialService
    {
        private IRepositoryWrapper _repository;
        public MaterialService(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        public async Task CreateMaterial(Material material)
        {
            _repository.Material.CreateMaterial(material);
            await _repository.SaveAsync();
            var materialWarehouseItem = new MaterialWarehouseItem()
            {
                MaterialId = material.MaterialId,
                Quantity = 0
            };
            _repository.MaterialWarehouseItem.CreateItem(materialWarehouseItem);
            await _repository.SaveAsync();
        }
    }
}