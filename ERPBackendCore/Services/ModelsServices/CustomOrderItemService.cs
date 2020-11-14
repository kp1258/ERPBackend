using System;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public class CustomOrderItemService : ICustomOrderItemService
    {
        private IRepositoryWrapper _repository;

        public CustomOrderItemService(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        public async Task CompleteCustomOrderItem(CustomOrderItem item)
        {
            item.CompletionDate = DateTime.Now;
            _repository.CustomOrderItem.UpdateItem(item);
            await _repository.SaveAsync();
        }

        public async Task AcceptToProduction(CustomOrderItem item, int productionManagerId)
        {
            item.ProductionManagerId = productionManagerId;
            item.ProductionStartDate = DateTime.Now;
            _repository.CustomOrderItem.UpdateItem(item);
            await _repository.SaveAsync();
        }
    }
}