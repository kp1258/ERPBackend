using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await FindAll()
                            .OrderBy(user => user.LastName)
                            .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await FindByCondition(user => user.UserId.Equals(userId))
                            .FirstOrDefaultAsync();
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

        public async Task ChangeStatusAsync(int userId)
        {
            var user = await FindByCondition(user => user.UserId.Equals(userId)).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.Status == UserStatus.Active)
                {
                    user.Status = UserStatus.Inactive;
                }
                else
                {
                    user.Status = UserStatus.Active;
                }
            }
        }

        public async Task<User> FindUser(string login)
        {
            return await FindByCondition(x => x.Login == login)
                            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAcitveUsersWithoutSpecifiedUser(int userId)
        {
            return await FindByCondition(x => x.Status == UserStatus.Active && x.UserId != userId)
                            .ToListAsync();
        }
    }
}