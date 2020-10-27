using AutoMapper;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Entities.Profiles
{
    public class StandardProductProfile : Profile
    {
        public StandardProductProfile()
        {
            CreateMap<StandardProduct, StandardProductReadDto>();
            CreateMap<StandardProductCreateDto, StandardProduct>();
            CreateMap<StandardProductUpdateDto, StandardProduct>();
            CreateMap<StandardProduct, StandardProductUpdateDto>();
        }
    }
}