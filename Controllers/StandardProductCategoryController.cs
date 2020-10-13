using System.Collections.Generic;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("standardproductcategory")]
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

        //GET api/standardproductcategory
        [HttpGet]
        public IActionResult GetAllStandardProductCategories()
        {
            var categories = _repository.StandardProductCategory.GetAllCategories();
            if (categories == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all standard product categories");

            var categoriesResult = _mapper.Map<IEnumerable<StandardProductCategoryDto>>(categories);
            return Ok(categoriesResult);
        }

        //GET api/standardproductcategory/{id}
        [HttpGet("{id}", Name = "CategoryById")]
        public IActionResult GetStandardProductCategoryById(int id)
        {
            var category = _repository.StandardProductCategory.GetCategoryById(id);
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

        //POST api/standardproductcategory
        [HttpPost]
        public IActionResult CreateStandardProductCategory([FromBody] StandardProductCategoryDto category)
        {
            if (category == null)
            {
                _logger.LogError("Standard product category object sent from client is null");
                return BadRequest("Standard product category object is null");
            }
            var categoryEntity = _mapper.Map<StandardProductCategory>(category);
            _repository.StandardProductCategory.CreateCategory(categoryEntity);
            _repository.Save();

            var createdCategory = _mapper.Map<StandardProductCategoryDto>(categoryEntity);
            return CreatedAtRoute("CategoryById", new { id = createdCategory.StandardProductCategoryId }, createdCategory);
        }

        //PUT api/standardproductcategory/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] StandardProductCategoryDto category)
        {
            if (category == null)
            {
                _logger.LogError("Stanard product category object sent from client is null");
                return BadRequest("Standard product category object is null");
            }
            var categoryEntity = _repository.StandardProductCategory.GetCategoryById(id);
            if (categoryEntity == null)
            {
                _logger.LogError($"Standard product category with id {id} does not exist");
                return NotFound();
            }
            _mapper.Map(category, categoryEntity);

            _repository.StandardProductCategory.UpdateCategory(categoryEntity);
            _repository.Save();
            return NoContent();
        }
    }
}