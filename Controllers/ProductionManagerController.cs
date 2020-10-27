using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("production-managers")]
    public class ProductionManagerController : ControllerBase
    {
        private readonly ILogger<ProductionManagerController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IOrderManagementService _service;
        public ProductionManagerController(ILogger<ProductionManagerController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, IOrderManagementService orderService)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
            _service = orderService;
        }

        //GET /production-managers/{pmId}/custom-order-items
        [HttpGet("{pmId}/custom-order-items")]
        public async Task<IActionResult> GetAllCustomOrderItemsByPM(int pmId)
        {
            var items = await _repository.CustomOrderItem.GetAllActiveItemsByProductionManager(pmId);
            if (!items.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all custom order items accepted to realization by production manager");

            var itemsResult = _mapper.Map<IEnumerable<CustomOrderItemReadDto>>(items);
            return Ok(itemsResult);
        }

        //PATCH /production-managers/{pmId}/custom-order-items/{itemId}
        [HttpPatch("{pmId}/custom-order-items/{itemId}/complete")]
        public async Task<IActionResult> CompleteCustomOrderItem(int pmId, int itemId, JsonPatchDocument<CustomOrderItemUpdateDto> patchDoc)
        {
            var itemModelFromRepo = await _repository.CustomOrderItem.GetItemByIdAsync(itemId);
            if (itemModelFromRepo == null)
            {
                return NotFound();
            }
            var itemToPatch = _mapper.Map<CustomOrderItemUpdateDto>(itemModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);

            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(itemToPatch, itemModelFromRepo);
            itemModelFromRepo.CompletionDate = DateTime.Now;
            _repository.CustomOrderItem.UpdateItem(itemModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }

        //GET /production-managers/{pmId}/standard-products
        [HttpGet("{pmId}/standard-products")]
        public async Task<IActionResult> GetMissingStandardProducts(int pmId)
        {
            var missingProducts = await _service.GetAllMissingProducts();
            if (!missingProducts.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all missing products");
            var missingProductsResult = _mapper.Map<IEnumerable<MissingProductDto>>(missingProducts);
            return Ok(missingProductsResult);
        }

        //PATCH /production-mamangers/{pmId}/custom-order-items/{itemId}
        [HttpPatch("{pmId}/custom-order-items/{itemId}")]
        public async Task<IActionResult> AcceptToProduction(int pmId, int itemId, JsonPatchDocument<CustomOrderItemUpdateDto> patchDoc)
        {
            var itemModelFromRepo = await _repository.CustomOrderItem.GetItemByIdAsync(itemId);
            if (itemModelFromRepo == null)
            {
                return NotFound();
            }
            var itemToPatch = _mapper.Map<CustomOrderItemUpdateDto>(itemModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);
            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(itemToPatch, itemModelFromRepo);

            itemModelFromRepo.ProductionManagerId = pmId;
            itemModelFromRepo.ProductionStartDate = DateTime.Now;

            _repository.CustomOrderItem.UpdateItem(itemModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}