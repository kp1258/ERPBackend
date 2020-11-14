using AutoMapper;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Dtos;

namespace ERPBackend.Entities.Profiles
{
    public class StandardProductCategoryProfile : Profile
    {
        public StandardProductCategoryProfile()
        {
            CreateMap<StandardProductCategory, StandardProductCategoryReadDto>();
            CreateMap<StandardProductCategoryReadDto, StandardProductCategory>();

            CreateMap<StandardProductCategoryUpdateDto, StandardProductCategory>();
            CreateMap<StandardProductCategoryCreateDto, StandardProductCategory>();
        }
    }
}