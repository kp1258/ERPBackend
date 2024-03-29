using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.AdditionalDtos;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.QueryParameters;
using ERPBackend.Services.ModelsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IOrderService _service;

        public OrderController(ILogger<OrderController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, IOrderService service)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
            _service = service;
        }

        //GET /orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _repository.Order.GetAllOrdersAsync();
            if (!orders.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all orders");

            var ordersResult = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return Ok(ordersResult);
        }

        //GET /order/{id}
        [HttpGet("{id}", Name = "OrderById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _repository.Order.GetOrderByIdAsync(id);
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

        //POST /orders
        [Authorize(Roles = "Salesman")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromForm] OrderCreateDto orderDto)
        {
            if (orderDto == null)
            {
                _logger.LogError("Order object sent from client is null");
                return BadRequest("Order object is null");
            }
            var orderEntity = _mapper.Map<Order>(orderDto);

            await _service.PlaceOrder(orderEntity);

            var createdOrder = _mapper.Map<OrderReadDto>(orderEntity);
            return CreatedAtRoute("OrderById", new { id = createdOrder.OrderId }, createdOrder);
        }

        //GET /order/placed
        [HttpGet("placed")]
        public async Task<IActionResult> GetPlacedOrders()
        {
            var orders = await _repository.Order.GetOrdersByStatusAsync(OrderStatus.Placed);
            if (!orders.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all orders");

            var ordersResult = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return Ok(ordersResult);
        }

        //GET /orders/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveOrders([FromQuery] OrderParameters parameters)
        {
            // var orders = await _repository.Order.GetAllActiveOrders(parameters);
            var orders = await _service.GetAllOrderDetails(parameters);
            if (!orders.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all orders");

            var ordersResult = _mapper.Map<IEnumerable<OrderDetailsDto>>(orders);
            return Ok(ordersResult);
        }

        //GET /orders/history
        [HttpGet("history")]
        public async Task<IActionResult> GetOrdersHistory([FromQuery] OrderParameters parameters)
        {
            var orders = await _repository.Order.GetAllOrdersHistory(parameters);
            if (!orders.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all orders");

            var ordersResult = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return Ok(ordersResult);
        }
    }
}