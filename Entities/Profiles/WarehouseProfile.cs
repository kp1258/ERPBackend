using AutoMapper;
using ERPBackend.Entities.Dtos.WarehouseDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Entities.Profiles
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<MaterialWarehouseItem, MaterialWarehouseItemReadDto>();
            CreateMap<MaterialWarehouseItemCreateDto, MaterialWarehouseItem>();

            CreateMap<ProductWarehouseItem, ProductWarehouseItemReadDto>();
            CreateMap<ProductWarehouseItemCreateDto, ProductWarehouseItem>();
        }
    }
}