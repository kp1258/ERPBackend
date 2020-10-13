using System.Collections.Generic;
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

        //GET api/materialwarehouse
        [HttpGet]
        public IActionResult GetAllMaterialWarehouseItems()
        {
            var items = _repository.MaterialWarehouseItem.GetAllItems();
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