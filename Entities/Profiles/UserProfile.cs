using AutoMapper;
using ERPBackend.Entities.Dtos.UserDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Entities.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserInfoDto>();
        }
    }
}