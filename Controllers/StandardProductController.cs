using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Services;
using ERPBackend.Services.ModelsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("standard-products")]
    public class StandardProductController : ControllerBase
    {
        private readonly ILogger<StandardProductController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public IStandardProductService _service;

        public StandardProductController(ILogger<StandardProductController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, IStandardProductService service)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
            _service = service;
        }

        //GET /standard-products
        [HttpGet]
        public async Task<IActionResult> GetAllStandardProducts()
        {
            var products = await _repository.StandardProduct.GetAllProductsAsync();
            if (!products.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all standard products");

            var productsResult = _mapper.Map<IEnumerable<StandardProductReadDto>>(products);
            return Ok(productsResult);
        }

        // GET /standard-products/produced
        [HttpGet("produced")]
        public async Task<IActionResult> GetAllProducedStandardProducts()
        {
            var products = await _repository.StandardProduct.GetAllProducedProductsAsync();
            if (!products.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all produced standard products");

            var productsResult = _mapper.Map<IEnumerable<StandardProductReadDto>>(products);
            return Ok(productsResult);
        }

        //GET /standard-products/{id}
        [HttpGet("{id}", Name = "StandardProductById")]
        public async Task<IActionResult> GetStandardProductById(int id)
        {
            var product = await _repository.StandardProduct.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned standard product with specified id");
                var productResult = _mapper.Map<StandardProductReadDto>(product);
                return Ok(productResult);
            }
        }

        //POST /standard-products
        [HttpPost]
        public async Task<IActionResult> CreateStandardProduct([FromForm] StandardProductCreateDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogError("Standard product object sent from client is null");
                return BadRequest("Standard product object is null");
            }
            var productEntity = _mapper.Map<StandardProduct>(productDto);

            await _service.CreateStandardProduct(productEntity, productDto);

            return CreatedAtRoute("StandardProductById", new { id = productEntity.StandardProductId }, productEntity);
        }

        //PUT /standardproduct/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStandardProduct(int id, [FromForm] StandardProductUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Standard product object sent from client is null");
                return BadRequest("Standard product object is null");
            }
            var productEntity = await _repository.StandardProduct.GetProductByIdAsync(id);
            if (productEntity == null)
            {
                _logger.LogError($"Standard product with id: {id}, does not exist");
                return NotFound();
            }
            _mapper.Map(product, productEntity);

            await _service.UpdateStandardProduct(productEntity, product);

            return NoContent();
        }

        //PATCH /standard-products/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStandardProductPatch(int id, JsonPatchDocument<StandardProductPatchDto> patchDoc)
        {
            var productModelFromRepo = await _repository.StandardProduct.GetProductByIdAsync(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }
            var productToPatch = _mapper.Map<StandardProductPatchDto>(productModelFromRepo);
            patchDoc.ApplyTo(productToPatch, ModelState);
            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(productToPatch, productModelFromRepo);
            _repository.StandardProduct.UpdateProduct(productModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }

    }
}