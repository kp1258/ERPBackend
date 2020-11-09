using System.Threading.Tasks;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(UserSignInDto userCredentials);
        string GenerateToken(User user);
    }
}