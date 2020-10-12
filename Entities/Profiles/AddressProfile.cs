using AutoMapper;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressInfoDto>().ReverseMap();
            //CreateMap<AddressInfoDto, Address>().ReverseMap();
        }
    }
}