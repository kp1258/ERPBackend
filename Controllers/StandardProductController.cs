using System.Collections.Generic;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("api/standardproduct")]
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

        //GET api/standardproduct
        [HttpGet]
        public IActionResult GetAllStandardProducts()
        {
            var products = _repository.StandardProduct.GetAllProducts();
            if (products == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all standard products");

            var productsResult = _mapper.Map<IEnumerable<StandardProductReadDto>>(products);
            return Ok(productsResult);
        }

        //GET api/standardproduct/{id}
        [HttpGet("{id}", Name = "StandardProductById")]
        public IActionResult GetStandardProductById(int id)
        {
            var product = _repository.StandardProduct.GetProductById(id);
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

        //POST api/standardproduct
        [HttpPost]
        public IActionResult CreateStandardProduct([FromBody] StandardProductCreateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Standard product object sent from client is null");
                return BadRequest("Standard product object is null");
            }
            var productEntity = _mapper.Map<StandardProduct>(product);
            _repository.StandardProduct.CreateProduct(productEntity);
            _repository.Save();

            var createdProduct = _mapper.Map<StandardProductReadDto>(productEntity);
            return CreatedAtRoute("StandardProductById", new { id = createdProduct.StandardProductId }, createdProduct);
        }

        //PUT api/standardproduct/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStandardProduc(int id, [FromBody] StandardProductUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Standard product object sent from client is null");
                return BadRequest("Standard product object is null");
            }
            var productEntity = _repository.StandardProduct.GetProductById(id);
            if (productEntity == null)
            {
                _logger.LogError($"Standard product with id: {id}, does not exist");
                return NotFound();
            }
            _mapper.Map(product, productEntity);

            _repository.StandardProduct.UpdateProduct(productEntity);
            _repository.Save();
            return NoContent();
        }

    }
}