using AutoMapper;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Entities.Profiles
{
    public class CustomProductProfile : Profile
    {
        public CustomProductProfile()
        {
            CreateMap<CustomProduct, CustomProductReadDto>();
            CreateMap<CustomProductCreateDto, CustomProduct>();

            CreateMap<CustomProduct, CustomProductPatchDto>();
            CreateMap<CustomProductPatchDto, CustomProduct>();

            CreateMap<FileItem, FileItemReadDto>();
            CreateMap<FileItemCreateDto, FileItem>();
        }

    }
}