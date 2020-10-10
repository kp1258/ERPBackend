using System.Collections.Generic;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.OrderDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OrderController(ILogger<OrderController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _repository.Order.GetAllOrders();
            _logger.LogInformation($"Returned all orders");

            var ordersResult = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return Ok(ordersResult);
        }

        [HttpGet("{id}", Name = "OrderById")]
        public IActionResult GetOrderById(int id)
        {
            var order = _repository.Order.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned order with specified id");
                var orderResult = _mapper.Map<OrderReadDto>(order);
                return Ok(orderResult);
            }
        }

        [HttpGet("orderdetails/{id}")]
        public IActionResult GetOrderDetailsById(int id)
        {
            var order = _repository.Order.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned order details with specified id");
                var orderResult = _mapper.Map<OrderInfoDto>(order);
                return Ok(orderResult);
            }
        }
    }
}