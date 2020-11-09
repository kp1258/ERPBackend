using AutoMapper;
using ERPBackend.Entities.Dtos.AdditionalDtos;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();

            CreateMap<OrderDetails, OrderDetailsDto>();

            CreateMap<OrderPatchDto, Order>();
            CreateMap<Order, OrderPatchDto>();
        }
    }
}