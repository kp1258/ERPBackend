using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
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

        public TechnologistController(ILogger<TechnologistController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //PATCH /technologists/{technologistId}/custom-products/{productId}
        [HttpPatch("{technologistId}/custom-products/{productId}")]
        public async Task<IActionResult> AcceptProductToPreparation(int technologistId, int productId, JsonPatchDocument<CustomProductUpdateDto> patchDoc)
        {
            var productModelFromRepo = await _repository.CustomProduct.GetProductByIdAsync(productId);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }
            var productToPatch = _mapper.Map<CustomProductUpdateDto>(productModelFromRepo);
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
        //PATCH /technologists/{technologistId}/custom-products/{productId}/solution
        // [HttpPatch("{technologistId}/custom-products/{productId}/solution")]
        // public async Task<IActionResult> AddSolutionToCustomProduct

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