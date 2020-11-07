using System.Threading.Tasks;
using ERPBackend.Entities.Dtos.AdditionalDtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public interface IUserService
    {
        Task CreateUser(User user);

        Task UpdateUser(User user, string password, UserStatus status);
        Task<bool> ChangePasswordUser(User user, ChangePasswordUserDto dto);
        Task<bool> ChangePasswordAdmin(User user, ChangePasswordAdminDto dto);
    }
}