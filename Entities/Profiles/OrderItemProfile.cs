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
            CreateMap<CustomOrderItemUpdateDto, CustomOrderItem>();
            CreateMap<CustomOrderItem, CustomOrderItemUpdateDto>();

            CreateMap<StandardOrderItem, StandardOrderItemReadDto>();
            CreateMap<StandardOrderItemCreateDto, StandardOrderItem>();

            CreateMap<StandardOrderItemDetail, StandardOrderItemDetailDto>();
        }
    }
}