using System.Collections.Generic;
using AutoMapper;
using ERPBackend.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("custom-products")]
    public class CustomProductController : ControllerBase
    {
        private readonly ILogger<CustomProductController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public CustomProductController(ILogger<CustomProductController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //GET /custom-products
        [HttpGet]
        public async Task<IActionResult> GetAllCustomProducts()
        {
            var products = await _repository.CustomProduct.GetAllProductsAsync();
            if (!products.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all custom products");

            var productsResult = _mapper.Map<IEnumerable<CustomProductReadDto>>(products);
            return Ok(productsResult);
        }

        //GET /custom-products/{id}
        [HttpGet("{id}", Name = "CustomProductById")]
        public async Task<IActionResult> GetCustomProductById(int id)
        {
            var product = await _repository.CustomProduct.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned custom product with id {id}");
                var productResult = _mapper.Map<CustomProductReadDto>(product);
                return Ok(productResult);
            }
        }

        //POST /custom-products
        [HttpPost]
        public async Task<IActionResult> CreateCustomProduct([FromBody] CustomProductCreateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Custom product object sent from client is null");
                return BadRequest("Custom product object is null");
            }
            var productEntity = _mapper.Map<CustomProduct>(product);

            _repository.CustomProduct.CreateProduct(productEntity);
            await _repository.SaveAsync();

            var createdProduct = _mapper.Map<CustomProductReadDto>(productEntity);
            return CreatedAtRoute("CustomProductById", new { id = createdProduct.CustomProductId }, createdProduct);
        }

        //PUT /custom-products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomProduct(int id, [FromBody] CustomProductUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Custom product object sent from client is null");
                return BadRequest("Custom product is null");
            }
            var productEntity = await _repository.CustomProduct.GetProductByIdAsync(id);
            if (productEntity == null)
            {
                _logger.LogError($"Custom product with id {id} does not exist");
                return NotFound();
            }
            _mapper.Map(product, productEntity);

            _repository.CustomProduct.UpdateProduct(productEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        //GET /custom-products/ordered
        [HttpGet("ordered")]
        public async Task<IActionResult> GetAllOrderedProducts()
        {
            var product = await _repository.CustomProduct.GetAllProductsByStatus(CustomProductStatus.Ordered);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned ordered custom products");
                var productResult = _mapper.Map<CustomProductReadDto>(product);
                return Ok(productResult);
            }
        }
        //GET /custom-products/prepared
        [HttpGet("prepared")]
        public async Task<IActionResult> GetAllPreparedProducts()
        {
            var product = await _repository.CustomProduct.GetAllProductsByStatus(CustomProductStatus.Prepared);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned prepared custom products");
                var productResult = _mapper.Map<CustomProductReadDto>(product);
                return Ok(productResult);
            }
        }
    }
}