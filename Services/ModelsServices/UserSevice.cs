using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repository;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        public async Task CreateUser(User user)
        {
            var plainTextPassword = user.Password;
            user.Password = BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
            user.Status = UserStatus.Active;
            _repository.User.CreateUser(user);
            await _repository.SaveAsync();
        }

        public async Task UpdateUser(User user, string password, UserStatus status)
        {
            user.Password = password;
            user.Status = status;
            _repository.User.UpdateUser(user);
            await _repository.SaveAsync();
        }

    }
}