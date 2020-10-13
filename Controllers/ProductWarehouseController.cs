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
    [Route("productwarehouse")]
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

        //GET api/productwarehouse
        [HttpGet]
        public IActionResult GetAllProductWarehouseItems()
        {
            var items = _repository.ProductWarehouseItem.GetAllItems();
            if (items == null)
            {
                return NoContent();
            }
            _logger.LogInformation("Returned all product warehouse items");

            var itemsResult = _mapper.Map<IEnumerable<ProductWarehouseItemReadDto>>(items);
            return Ok(itemsResult);
        }
    }
}