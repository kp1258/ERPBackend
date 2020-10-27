using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ProductDtos;
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
    }
}