using AutoMapper;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDto>();
        }
    }
}