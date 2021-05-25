using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.WarehouseDtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("material-warehouse")]
    public class MaterialWarehouseController : ControllerBase
    {
        private readonly ILogger<MaterialWarehouseController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public MaterialWarehouseController(ILogger<MaterialWarehouseController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //GET /materialwarehouse
        [HttpGet]
        public async Task<IActionResult> GetAllMaterialWarehouseItems()
        {
            var items = await _repository.MaterialWarehouseItem.GetAllItemsAsync();
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation("Returned all material warehouse items");

            var itemsResult = _mapper.Map<IEnumerable<MaterialWarehouseItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //PATCH /material-warehouse/{id}
        [Authorize(Roles = "Warehouseman")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeMaterialWarehouseStock(int id, JsonPatchDocument<MaterialWarehouseItemUpdateDto> patchDoc)
        {
            var itemModelFromRepo = await _repository.MaterialWarehouseItem.GetItemByIdAsync(id);
            if (itemModelFromRepo == null)
            {
                return NotFound();
            }
            var itemToPatch = _mapper.Map<MaterialWarehouseItemUpdateDto>(itemModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);
            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(itemToPatch, itemModelFromRepo);
            _repository.MaterialWarehouseItem.UpdateItem(itemModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}