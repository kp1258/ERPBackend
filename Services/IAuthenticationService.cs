using System.Threading.Tasks;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(UserSignInDto userCredentials);
        // string GenerateToken(User user);
    }
}