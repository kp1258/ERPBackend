using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.MaterialDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("materials")]
    public class MaterialController : ControllerBase
    {
        private readonly ILogger<MaterialController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public MaterialController(ILogger<MaterialController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //GET /material
        [HttpGet]
        public async Task<IActionResult> GetAllMaterials()
        {
            var materials = await _repository.Material.GetAllMaterialsAsync();
            if (!materials.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all materials");

            var materialsResult = _mapper.Map<IEnumerable<MaterialReadDto>>(materials);
            return Ok(materialsResult);
        }

        //GET /material/{id}
        [HttpGet("{id}", Name = "MaterialById")]
        public async Task<IActionResult> GetMaterialById(int id)
        {
            var material = await _repository.Material.GetMaterialByIdAsync(id);
            if (material == null)
            {
                _logger.LogInformation($"Material with id {id} does not exist");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned material with id {id}");
                var materialResult = _mapper.Map<MaterialReadDto>(material);
                return Ok(materialResult);
            }
        }

        //POST /materials
        [HttpPost]
        public async Task<IActionResult> CreateMaterial([FromBody] MaterialCreateDto material)
        {
            if (material == null)
            {
                _logger.LogError("Material object sent from client is null");
                return BadRequest("Material object is null");
            }
            var materialEntity = _mapper.Map<Material>(material);
            _repository.Material.CreateMaterial(materialEntity);
            await _repository.SaveAsync();

            var createdMaterial = _mapper.Map<MaterialReadDto>(materialEntity);
            var materialWarehouseItem = new MaterialWarehouseItem()
            {
                MaterialId = createdMaterial.MaterialId,
                Quantity = 0
            };
            _repository.MaterialWarehouseItem.CreateItem(materialWarehouseItem);
            await _repository.SaveAsync();
            return CreatedAtRoute("MaterialById", new { id = createdMaterial.MaterialId }, createdMaterial);
        }

        //PUT /material/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(int id, [FromBody] MaterialUpdateDto material)
        {
            if (material == null)
            {
                _logger.LogError("Material object sent from client is null");
                return BadRequest("Material object is null");
            }
            var materialEntity = await _repository.Material.GetMaterialByIdAsync(id);
            if (materialEntity == null)
            {
                _logger.LogError($"Material with id {id} does not exist");
                return NotFound();
            }
            _mapper.Map(material, materialEntity);

            _repository.Material.UpdateMaterial(materialEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}