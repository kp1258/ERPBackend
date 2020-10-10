using AutoMapper;
using ERPBackend.Entities.Dtos.ClientDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientReadDto>();
            CreateMap<ClientCreateDto, Client>();
            CreateMap<ClientUpdateDto, Client>();
        }
    }
}