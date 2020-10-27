using AutoMapper;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Dtos.WarehouseDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Entities.Profiles
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<MaterialWarehouseItem, MaterialWarehouseItemReadDto>();
            CreateMap<MaterialWarehouseItemUpdateDto, MaterialWarehouseItem>();
            CreateMap<MaterialWarehouseItem, MaterialWarehouseItemUpdateDto>();
            CreateMap<MaterialWarehouseItem, MaterialWarehouseItemUpdateDto>();

            CreateMap<ProductWarehouseItem, ProductWarehouseItemReadDto>();
            CreateMap<ProductWarehouseItemUpdateDto, ProductWarehouseItem>();
            CreateMap<ProductWarehouseItem, ProductWarehouseItemUpdateDto>();
            CreateMap<ProductWarehouseItem, ProductWarehouseItemUpdateDto>();

            CreateMap<MissingProduct, MissingProductDto>();
        }
    }
}