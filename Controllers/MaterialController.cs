using System.Collections.Generic;
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
    [Route("material")]
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

        //GET api/material
        [HttpGet]
        public IActionResult GetAllMaterials()
        {
            var materials = _repository.Material.GetAllMaterials();
            if (materials == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all materials");

            var materialsResult = _mapper.Map<IEnumerable<MaterialReadDto>>(materials);
            return Ok(materialsResult);
        }

        //GET api/material/{id}
        [HttpGet("{id}", Name = "MaterialById")]
        public IActionResult GetMaterialById(int id)
        {
            var material = _repository.Material.GetMaterialById(id);
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

        //POST api/material
        [HttpPost]
        public IActionResult CreateMaterial([FromBody] MaterialCreateDto material)
        {
            if (material == null)
            {
                _logger.LogError("Material object sent from client is null");
                return BadRequest("Material object is null");
            }
            var materialEntity = _mapper.Map<Material>(material);
            _repository.Material.CreateMaterial(materialEntity);
            _repository.Save();

            var createdMaterial = _mapper.Map<MaterialReadDto>(materialEntity);
            return CreatedAtRoute("MaterialById", new { id = createdMaterial.MaterialId }, createdMaterial);
        }

        //PUT api/material/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMaterial(int id, [FromBody] MaterialUpdateDto material)
        {
            if (material == null)
            {
                _logger.LogError("Material object sent from client is null");
                return BadRequest("Material object is null");
            }
            var materialEntity = _repository.Material.GetMaterialById(id);
            if (materialEntity == null)
            {
                _logger.LogError($"Material with id {id} does not exist");
                return NotFound();
            }
            _mapper.Map(material, materialEntity);

            _repository.Material.UpdateMaterial(materialEntity);
            _repository.Save();
            return NoContent();
        }
    }
}