using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.QueryParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("orders")]
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

            var ordersResult = _mapper.Map<IEnumerable<OrderInfoDto>>(orders);
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
                var orderResult = _mapper.Map<OrderInfoDto>(order);
                return Ok(orderResult);
            }
        }

        //POST /order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto order)
        {
            if (order == null)
            {
                _logger.LogError("Order object sent from client is null");
                return BadRequest("Order object is null");
            }
            var orderEntity = _mapper.Map<Order>(order);
            DateTime placingDate = DateTime.Now;
            orderEntity.PlacingDate = placingDate;
            orderEntity.Status = OrderStatus.Placed;
            _repository.Order.CreateOrder(orderEntity);
            await _repository.SaveAsync();

            var createdOrder = _mapper.Map<OrderInfoDto>(orderEntity);
            return CreatedAtRoute("OrderDetailsById", new { id = createdOrder.OrderId }, createdOrder);
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

            var ordersResult = _mapper.Map<IEnumerable<OrderInfoDto>>(orders);
            return Ok(ordersResult);
        }

        //GET /orders/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveOrders([FromQuery] OrderParameters parameters)
        {
            var orders = await _repository.Order.GetAllActiveOrders(parameters);
            if (!orders.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all orders");

            var ordersResult = _mapper.Map<IEnumerable<OrderInfoDto>>(orders);
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

            var ordersResult = _mapper.Map<IEnumerable<OrderInfoDto>>(orders);
            return Ok(ordersResult);
        }

        //GET /order/details/{id}
        // [HttpGet("details/{id}", Name = "OrderDetailsById")]
        // public async Task<IActionResult> GetOrderDetailsById(int id)
        // {
        //     var order = await _repository.Order.GetOrderDetailsByIdAsync(id);
        //     if (order == null)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         _logger.LogInformation($"Returned order details with specified id");
        //         var orderResult = _mapper.Map<OrderInfoDto>(order);
        //         return Ok(orderResult);
        //     }
        // }
    }
}