using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ERPBackend.Entities.QueryParameters;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Authorize]
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
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all custom order items");
            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //GET /custom-order-items/active
        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveCustomOrderItems([FromQuery] CustomOrderItemPrameters parameters)
        {
            var items = await _repository.CustomOrderItem.GetAllActiveItems(parameters);
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned active custom order items");
            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //GET /custom-order-items/history
        [HttpGet("history")]
        public async Task<IActionResult> GetAllCustomOrderItemsHistory([FromQuery] CustomOrderItemPrameters parameters)
        {
            var items = await _repository.CustomOrderItem.GetAllItemsHistory(parameters);
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned custom order items history");
            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //GET /custom-order-items/active-orders
        [HttpGet("active-orders")]
        public async Task<IActionResult> GetAllCustomOrderItemsFromActiveOrders([FromQuery] CustomOrderItemPrameters parameters)
        {
            var items = await _repository.CustomOrderItem.GetAllItemsFromActiveOrders(parameters);
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned active custom order items");
            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //GET /custom-order-items/orders-history
        [HttpGet("orders-history")]
        public async Task<IActionResult> GetAllCustomOrderItemsFromOrdersHistory([FromQuery] CustomOrderItemPrameters parameters)
        {
            var items = await _repository.CustomOrderItem.GetAllItemsFromOrdersHistory(parameters);
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned custom order items history");
            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //GET /custom-order-items/prepared
        [HttpGet("prepared")]
        public async Task<IActionResult> GetAllOrderedCustomOrderItemsWithSolution()
        {
            var items = await _repository.CustomOrderItem.GetAllOrderedItemsWithSolution();
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all ordered custom order items with prepared solution");
            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }
    }
}