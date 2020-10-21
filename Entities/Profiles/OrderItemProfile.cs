using AutoMapper;
using ERPBackend.Entities.Dtos.OrderItemDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Entities.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<CustomOrderItem, CustomOrderItemReadDto>().ReverseMap();
            CreateMap<StandardOrderItem, StandardOrderItemReadDto>().ReverseMap();

            CreateMap<CustomOrderItemCreateDto, CustomOrderItem>();
            CreateMap<StandardOrderItemCreateDto, StandardOrderItem>();
        }
    }
}