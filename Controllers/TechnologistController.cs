using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("technologists")]
    public class TechnologistController : ControllerBase
    {
        private readonly ILogger<TechnologistController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IBlobStorageService _service;

        public TechnologistController(ILogger<TechnologistController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, IBlobStorageService service)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
            _service = service;
        }

        //PATCH /technologists/{technologistId}/custom-products/{productId}
        [HttpPatch("{technologistId}/custom-products/{productId}")]
        public async Task<IActionResult> AcceptProductToPreparation(int technologistId, int productId, JsonPatchDocument<CustomProductPatchDto> patchDoc)
        {
            var productModelFromRepo = await _repository.CustomProduct.GetProductByIdAsync(productId);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }
            var productToPatch = _mapper.Map<CustomProductPatchDto>(productModelFromRepo);
            patchDoc.ApplyTo(productToPatch, ModelState);

            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(productToPatch, productModelFromRepo);
            productModelFromRepo.TechnologistId = technologistId;
            productModelFromRepo.PreparationStartDate = DateTime.Now;

            _repository.CustomProduct.UpdateProduct(productModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }

        //POST /technologists/{technologistId}/custom-products/{productId}/solution
        [HttpPost("{technologistId}/custom-products/{productId}/solution")]
        public async Task<IActionResult> AddSolutionToCustomProduct(int technologistId, int productId, [FromForm] CustomProductAddSolutionDto solution)
        {
            var product = await _repository.CustomProduct.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            product.PreparationCompletionDate = DateTime.Now;
            product.Status = CustomProductStatus.Prepared;
            product.SolutionDescription = solution.SolutionDescription;
            await _service.UploadSolutionFilesAsync(product.CustomProductId, solution.Files);
            _repository.CustomProduct.Update(product);
            await _repository.SaveAsync();
            return NoContent();

        }

        //GET /technologists/{id}/custom-products
        [HttpGet("{technologistId}/custom-products")]
        public async Task<IActionResult> GetAllCustomProductsByTechnologist(int technologistId)
        {
            var products = await _repository.CustomProduct.GetAllProductsByTechnologist(technologistId);
            if (!products.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all custom products binded witch specified technologist");

            var productsResult = _mapper.Map<IEnumerable<CustomProductReadDto>>(products);
            return Ok(productsResult);
        }

        //GET /technologists/{id}/custom-products/prepared
        [HttpGet("{technologistId}/custom-products/prepared")]
        public async Task<IActionResult> GetAllCompletedCustomProductsByTechnologist(int technologistId)
        {
            var products = await _repository.CustomProduct.GetAllProductsByTechnologistAndStatus(technologistId, CustomProductStatus.Prepared);
            if (!products.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all prepared custom products binded with specified technologist");

            var productsResult = _mapper.Map<IEnumerable<CustomProductReadDto>>(products);
            return Ok(productsResult);
        }

        //GET /technologists/{id}/custom-products/in-preparation
        [HttpGet("{technologistId}/custom-products/in-preparation")]
        public async Task<IActionResult> GetAllInPreparationCustomProductsByTechnologist(int technologistId)
        {
            var products = await _repository.CustomProduct.GetAllProductsByTechnologistAndStatus(technologistId, CustomProductStatus.InPreparation);
            if (!products.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all custom products in preparation binded witch specified technologist");

            var productsResult = _mapper.Map<IEnumerable<CustomProductReadDto>>(products);
            Console.WriteLine(productsResult);
            return Ok(productsResult);
        }
    }
}