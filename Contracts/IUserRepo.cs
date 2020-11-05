using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task ChangeStatusAsync(int userId);
        Task<User> FindUser(string login);
    }
}