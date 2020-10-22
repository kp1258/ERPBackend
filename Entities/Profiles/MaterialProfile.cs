using AutoMapper;
using ERPBackend.Entities.Dtos.MaterialDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Entities.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialReadDto>();
            CreateMap<MaterialCreateDto, Material>();
            CreateMap<MaterialUpdateDto, Material>();
        }
    }
}