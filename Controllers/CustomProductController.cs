using System.Collections.Generic;
using AutoMapper;
using ERPBackend.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("api/customproduct")]
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

        //GET api/customproduct
        [HttpGet]
        public IActionResult GetAllCustomProducts()
        {
            var products = _repository.CustomProduct.GetAllProducts();
            if (products == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all custom products");

            var productsResult = _mapper.Map<IEnumerable<CustomProductReadDto>>(products);
            return Ok(productsResult);
        }

        //GET api/customproduct/{id}
        [HttpGet("{id}", Name = "CustomProductById")]
        public IActionResult GetCustomProductById(int id)
        {
            var product = _repository.CustomProduct.GetProductById(id);
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

        //POST api/customproduct
        [HttpPost]
        public IActionResult CreateCustomProduct([FromBody] CustomProductCreateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Custom product object sent from client is null");
                return BadRequest("Custom product object is null");
            }
            var productEntity = _mapper.Map<CustomProduct>(product);

            _repository.CustomProduct.CreateProduct(productEntity);
            _repository.Save();

            var createdProduct = _mapper.Map<CustomProductReadDto>(productEntity);
            return CreatedAtRoute("CustomProductById", new { id = createdProduct.CustomProductId }, createdProduct);
        }

        //PUT api/customproduct/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomProduct(int id, [FromBody] CustomProductUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Custom product object sent from client is null");
                return BadRequest("Custom product is null");
            }
            var productEntity = _repository.CustomProduct.GetProductById(id);
            if (productEntity == null)
            {
                _logger.LogError($"Custom product with id {id} does not exist");
                return NotFound();
            }
            _mapper.Map(product, productEntity);

            _repository.CustomProduct.UpdateProduct(productEntity);
            _repository.Save();
            return NoContent();
        }
    }
}