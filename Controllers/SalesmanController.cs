using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Dtos.ClientDtos;
using ERPBackend.Entities.Dtos.OrderDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("salesmen")]
    public class SalesmanController : ControllerBase
    {
        private readonly ILogger<SalesmanController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SalesmanController(ILogger<SalesmanController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //GET /salesmen/{id}/clients
        [HttpGet("{id}/clients")]
        public async Task<IActionResult> GetAllClientsBySalesman(int id)
        {
            var clients = await _repository.Client.GetClientsBySalesmanAsync(id);
            if (!clients.Any())
            {
                return NoContent();
            }

            _logger.LogInformation($"Returned all salesman's clients");

            var clientsResult = _mapper.Map<IEnumerable<ClientReadDto>>(clients);
            return Ok(clientsResult);
        }

        //GET /salesmen/{id}/orders
        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetAllOrdersBySalesman(int id)
        {
            var orders = await _repository.Order.GetOrdersBySalesmanAsync(id);
            if (!orders.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all salesman's orders");

            var clientsResult = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return Ok(orders);
        }

        //GET /salesmen/{id}/custom-order-items
        [HttpGet("{id}/custom-order-items")]
        public async Task<IActionResult> GetAllCustomOrderItemsBySalesman(int id)
        {
            var items = await _repository.CustomOrderItem.GetAllActiveItemsBySalesman(id);
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all custom order items from salesman's active orders");

            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }

    }
}