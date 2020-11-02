using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> AcceptOrderForRealization(int warehousemanId, int orderId, JsonPatchDocument<OrderPatchDto> patchDoc)
        {
            var orderModelFromRepo = await _repository.Order.GetOrderByIdAsync(orderId);
            if (orderModelFromRepo == null)
            {
                return NotFound();
            }
            var orderToPatch = _mapper.Map<OrderPatchDto>(orderModelFromRepo);
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
        //PATCH /warehousemen/{warehousemanId}/orders/{orderId}/complete
        [HttpPatch("{warehousemanId}/orders/{orderId}/complete")]
        public async Task<IActionResult> CompleteOrder(int warehousemanId, int orderId, JsonPatchDocument<OrderPatchDto> patchDoc)
        {
            var orderModelFromRepo = await _repository.Order.GetOrderByIdAsync(orderId);
            if (orderModelFromRepo == null)
            {
                return NotFound();
            }
            var orderToPatch = _mapper.Map<OrderPatchDto>(orderModelFromRepo);
            patchDoc.ApplyTo(orderToPatch, ModelState);
            if (!TryValidateModel(orderToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(orderToPatch, orderModelFromRepo);
            orderModelFromRepo.CompletionDate = DateTime.Now;
            await _serivce.CompleteOrder(orderModelFromRepo.OrderId);

            _repository.Order.UpdateOrder(orderModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}