using System;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Services;
using ERPBackend.Services.ModelsServices;

namespace ERPBackend.Services.ModelsServices
{
    public class CustomProductService : ICustomProductService
    {
        private IRepositoryWrapper _repository;
        private IBlobStorageService _service;

        public CustomProductService(IRepositoryWrapper repositoryWrapper, IBlobStorageService service)
        {
            _repository = repositoryWrapper;
            _service = service;
        }
        public async Task AcceptToPreparation(CustomProduct product, int technologistId)
        {
            product.TechnologistId = technologistId;
            product.PreparationStartDate = DateTime.Now;

            _repository.CustomProduct.UpdateProduct(product);
            await _repository.SaveAsync();
        }

        public async Task AddSolution(CustomProduct product, CustomProductAddSolutionDto solution)
        {
            product.PreparationCompletionDate = DateTime.Now;
            product.Status = CustomProductStatus.Prepared;
            product.SolutionDescription = solution.SolutionDescription;
            await _service.UploadSolutionFilesAsync(product.CustomProductId, solution.Files);
            _repository.CustomProduct.Update(product);
            await _repository.SaveAsync();
        }
    }
}