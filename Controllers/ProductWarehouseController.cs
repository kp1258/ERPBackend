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
    [Route("product-warehouse")]
    public class ProductWarehouseController : ControllerBase
    {
        private readonly ILogger<ProductWarehouseController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProductWarehouseController(ILogger<ProductWarehouseController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //GET /product-warehouse
        [HttpGet]
        public async Task<IActionResult> GetAllProductWarehouseItems()
        {
            var items = await _repository.ProductWarehouseItem.GetAllItemsAsync();
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation("Returned all product warehouse items");

            var itemsResult = _mapper.Map<IEnumerable<ProductWarehouseItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //PATCH /product-warehouse/{id}
        [Authorize(Roles = "Warehouseman")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeProductWarehouseStock(int id, JsonPatchDocument<ProductWarehouseItemUpdateDto> patchDoc)
        {
            var itemModelFromRepo = await _repository.ProductWarehouseItem.GetItemByIdAsync(id);
            if (itemModelFromRepo == null)
            {
                return NotFound();
            }
            var itemToPatch = _mapper.Map<ProductWarehouseItemUpdateDto>(itemModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);
            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(itemToPatch, itemModelFromRepo);
            _repository.ProductWarehouseItem.UpdateItem(itemModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}