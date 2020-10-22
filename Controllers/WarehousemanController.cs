using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.AdditionalDtos;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("warehousemen")]
    public class WarehousemanController : ControllerBase
    {
        private readonly ILogger<WarehousemanController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IOrderManagementService _serivce;

        public WarehousemanController(ILogger<WarehousemanController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, IOrderManagementService service)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
            _serivce = service;
        }

        //PATCH /warehousemen/{warehousemanId}/orders/{orderId}
        [HttpPatch("{warehousemanId}/orders/{orderId}")]
        public async Task<IActionResult> AcceptOrderForRealization(int warehousemanId, int orderId, JsonPatchDocument<OrderUpdateDto> patchDoc)
        {
            var orderModelFromRepo = await _repository.Order.GetOrderByIdAsync(orderId);
            if (orderModelFromRepo == null)
            {
                return NotFound();
            }
            var orderToPatch = _mapper.Map<OrderUpdateDto>(orderModelFromRepo);
            patchDoc.ApplyTo(orderToPatch, ModelState);
            if (!TryValidateModel(orderToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(orderToPatch, orderModelFromRepo);
            orderModelFromRepo.WarehousemanId = warehousemanId;
            orderModelFromRepo.RealizationStartDate = DateTime.Now;

            _repository.Order.UpdateOrder(orderModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }
        //PATCH /warehousemen/{warehousemanId}/orders/{orderId}/completion
        [HttpPatch("{warehousemanId}/orders/{orderId}/completion")]
        public async Task<IActionResult> CompleteOrder(int warehousemanId, int orderId, JsonPatchDocument<OrderUpdateDto> patchDoc)
        {
            var orderModelFromRepo = await _repository.Order.GetOrderByIdAsync(orderId);
            if (orderModelFromRepo == null)
            {
                return NotFound();
            }
            var orderToPatch = _mapper.Map<OrderUpdateDto>(orderModelFromRepo);
            patchDoc.ApplyTo(orderToPatch, ModelState);
            if (!TryValidateModel(orderToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(orderToPatch, orderModelFromRepo);
            orderModelFromRepo.CompletionDate = DateTime.Now;

            _repository.Order.UpdateOrder(orderModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }

        //GET /warehousemen/{warehousemanId}/orders
        [HttpGet("{warehousemanId}/orders")]
        public async Task<IActionResult> GetAllActiveOrdersByWarehouseman(int warehousemanId)
        {
            var orders = await _serivce.GetAllOrderDetailsByWarehouseman(warehousemanId);
            if (orders == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all orders realized by specified warehouseman");

            var ordersResult = _mapper.Map<IEnumerable<OrderDetailsDto>>(orders);
            return Ok(ordersResult);
        }

    }
}