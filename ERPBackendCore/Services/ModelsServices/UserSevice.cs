using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.AdditionalDtos;
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

        public async Task<bool> ChangePasswordUser(User user, ChangePasswordUserDto dto)
        {
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.OldPassword, user.Password))
            {
                return false;
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            _repository.User.UpdateUser(user);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> ChangePasswordAdmin(User user, ChangePasswordAdminDto dto)
        {
            if (user == null)
            {
                return false;
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            _repository.User.UpdateUser(user);
            await _repository.SaveAsync();
            return true;
        }

    }
}