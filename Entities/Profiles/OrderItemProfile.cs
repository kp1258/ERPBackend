using AutoMapper;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Dtos.AdditionalDtos;
using ERPBackend.Entities.Dtos.OrderItemDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Entities.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<CustomOrderItem, CustomOrderItemReadDto>();
            CreateMap<CustomOrderItemCreateDto, CustomOrderItem>();
            CreateMap<CustomOrderItem, CustomOrderItemPatchDto>();
            CreateMap<CustomOrderItemPatchDto, CustomOrderItem>();

            CreateMap<StandardOrderItem, StandardOrderItemReadDto>();
            CreateMap<StandardOrderItemCreateDto, StandardOrderItem>();

            CreateMap<StandardOrderItemDetail, StandardOrderItemDetailDto>();
        }
    }
}