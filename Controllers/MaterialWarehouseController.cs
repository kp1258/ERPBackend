using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.WarehouseDtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("materialwarehouse")]
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
            if (items == null)
            {
                return NoContent();
            }
            _logger.LogInformation("Returned all material warehouse items");

            var itemsResult = _mapper.Map<IEnumerable<MaterialWarehouseItemReadDto>>(items);
            return Ok(itemsResult);
        }
    }
}