using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("custom-order-items")]
    public class CustomOrderItemController : ControllerBase
    {
        private readonly ILogger<CustomOrderItemController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public CustomOrderItemController(ILogger<CustomOrderItemController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //GET /custom-order-items
        [HttpGet]
        public async Task<IActionResult> GetAllCustomOrderItems()
        {
            var items = await _repository.CustomOrderItem.GetAllItemsAsync();
            if (items == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all custom order items");
            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //GET /custom-order-items/prepared
        [HttpGet("prepared")]
        public async Task<IActionResult> GetAllOrderedCustomOrderItemsWithSolution()
        {
            var items = await _repository.CustomOrderItem.GetAllOrderedItemsWithSolution();
            if (items == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all ordered custom order items with prepared solution");
            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }
    }
}