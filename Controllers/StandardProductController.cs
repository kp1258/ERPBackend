using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("standard-products")]
    public class StandardProductController : ControllerBase
    {
        private readonly ILogger<StandardProductController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public StandardProductController(ILogger<StandardProductController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
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
        public async Task<IActionResult> CreateStandardProduct([FromBody] StandardProductCreateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Standard product object sent from client is null");
                return BadRequest("Standard product object is null");
            }
            var productEntity = _mapper.Map<StandardProduct>(product);
            _repository.StandardProduct.CreateProduct(productEntity);
            await _repository.SaveAsync();

            var createdProduct = _mapper.Map<StandardProductReadDto>(productEntity);
            var productWarehouseItem = new ProductWarehouseItem()
            {
                StandardProductId = createdProduct.StandardProductId,
                Quantity = 0
            };
            _repository.ProductWarehouseItem.CreateItem(productWarehouseItem);
            await _repository.SaveAsync();

            return CreatedAtRoute("StandardProductById", new { id = createdProduct.StandardProductId }, createdProduct);
        }

        //PUT /standardproduct/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStandardProduc(int id, [FromBody] StandardProductUpdateDto product)
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

            _repository.StandardProduct.UpdateProduct(productEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

    }
}