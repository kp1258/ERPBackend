using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Dtos.OrderItemDtos;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Services.ModelsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Authorize(Roles = "Production Manager")]
    [Route("production-managers")]
    public class ProductionManagerController : ControllerBase
    {
        private readonly ILogger<ProductionManagerController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IStandardProductService _standardProductService;
        private ICustomOrderItemService _customOrderItemService;

        public ProductionManagerController(ILogger<ProductionManagerController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, IStandardProductService standardProductService, ICustomOrderItemService customOrderItemService)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
            _standardProductService = standardProductService;
            _customOrderItemService = customOrderItemService;
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
        public async Task<IActionResult> CompleteCustomOrderItem(int pmId, int itemId, JsonPatchDocument<CustomOrderItemPatchDto> patchDoc)
        {
            var itemModelFromRepo = await _repository.CustomOrderItem.GetItemByIdAsync(itemId);
            if (itemModelFromRepo == null)
            {
                return NotFound();
            }
            var itemToPatch = _mapper.Map<CustomOrderItemPatchDto>(itemModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);

            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(itemToPatch, itemModelFromRepo);

            await _customOrderItemService.CompleteCustomOrderItem(itemModelFromRepo);

            return NoContent();
        }

        //GET /production-managers/{pmId}/standard-products
        [HttpGet("{pmId}/standard-products")]
        public async Task<IActionResult> GetMissingStandardProducts(int pmId)
        {

            var missingProducts = await _standardProductService.GetAllMissingProducts();

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
        public async Task<IActionResult> AcceptToProduction(int pmId, int itemId, JsonPatchDocument<CustomOrderItemPatchDto> patchDoc)
        {
            var itemModelFromRepo = await _repository.CustomOrderItem.GetItemByIdAsync(itemId);
            if (itemModelFromRepo == null)
            {
                return NotFound();
            }
            var itemToPatch = _mapper.Map<CustomOrderItemPatchDto>(itemModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);
            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(itemToPatch, itemModelFromRepo);

            await _customOrderItemService.AcceptToProduction(itemModelFromRepo, pmId);

            return NoContent();
        }
    }
}