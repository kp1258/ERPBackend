using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("standard-products/categories")]
    public class StandardProductCategoryController : ControllerBase
    {
        private readonly ILogger<StandardProductCategoryController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public StandardProductCategoryController(ILogger<StandardProductCategoryController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //GET /standardproduct/category
        [HttpGet]
        public async Task<IActionResult> GetAllStandardProductCategories()
        {
            var categories = await _repository.StandardProductCategory.GetAllCategoriesAsync();
            if (!categories.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all standard product categories");

            var categoriesResult = _mapper.Map<IEnumerable<StandardProductCategoryDto>>(categories);
            return Ok(categoriesResult);
        }

        //GET /standardproduct/category/{id}
        [HttpGet("{id}", Name = "CategoryById")]
        public async Task<IActionResult> GetStandardProductCategoryById(int id)
        {
            var category = await _repository.StandardProductCategory.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned standard product category with specified id");
                var categoryResult = _mapper.Map<StandardProductCategoryDto>(category);
                return Ok(categoryResult);
            }
        }

        //POST /standardproduct/category
        [HttpPost]
        public async Task<IActionResult> CreateStandardProductCategory([FromBody] StandardProductCategoryCreateDto category)
        {
            if (category == null)
            {
                _logger.LogError("Standard product category object sent from client is null");
                return BadRequest("Standard product category object is null");
            }
            var categoryEntity = _mapper.Map<StandardProductCategory>(category);
            _repository.StandardProductCategory.CreateCategory(categoryEntity);
            await _repository.SaveAsync();

            var createdCategory = _mapper.Map<StandardProductCategoryDto>(categoryEntity);
            return CreatedAtRoute("CategoryById", new { id = createdCategory.StandardProductCategoryId }, createdCategory);
        }

        //PUT /standardproduct/category/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] StandardProductCategoryUpdateDto category)
        {
            if (category == null)
            {
                _logger.LogError("Stanard product category object sent from client is null");
                return BadRequest("Standard product category object is null");
            }
            var categoryEntity = await _repository.StandardProductCategory.GetCategoryByIdAsync(id);
            if (categoryEntity == null)
            {
                _logger.LogError($"Standard product category with id {id} does not exist");
                return NotFound();
            }
            _mapper.Map(category, categoryEntity);

            _repository.StandardProductCategory.UpdateCategory(categoryEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}