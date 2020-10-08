using System.Collections.Generic;
using System.Linq;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;

namespace ERPBackend.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(user => user.LastName)
                .ToList();
        }

        public User GetUserById(int userId)
        {
            return FindByCondition(user => user.UserId.Equals(userId)).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }
    }
}