using System.Collections.Generic;
using System.Linq;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
    }
}