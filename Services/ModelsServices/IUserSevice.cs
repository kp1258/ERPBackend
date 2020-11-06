using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public interface IUserService
    {
        Task CreateUser(User user);

        Task UpdateUser(User user, string password, UserStatus status);
    }
}