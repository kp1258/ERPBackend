using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ERPBackend;
using ERPBackend.Entities.Models;
using System.Threading.Tasks;
using ERPBackend.Helpers;
using System;
using ERPBackend.Entities.Models.Additional;

namespace ERPBackend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly AppSettings _appsettings;

        public AuthenticationService(IOptions<AppSettings> appSettings, IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
            _appsettings = appSettings.Value;
        }

        public async Task<AuthenticationResponse> Authenticate(UserSignInDto userCredentials)
        {
            var user = await _repository.User.FindUser(userCredentials.Login);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userCredentials.Password, user.Password))
            {
                return null;
            }
            var token = GenerateToken(user);
            var response = new AuthenticationResponse
            {
                UserId = user.UserId,
                Token = token
            };
            return response;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
