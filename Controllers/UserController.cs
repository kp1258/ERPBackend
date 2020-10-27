using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Dtos.UserDtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public UserController(ILogger<UserController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }


        //GET api/user/signin
        [AllowAnonymous]
        [HttpPost, Route("signin")]
        public IActionResult SignIn([FromBody] UserSignInDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            if (user.Login == "johndoe" && user.Password == "def@123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        //GET /user
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.User.GetAllUsersAsync();
            if (!users.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all users");

            var usersResult = _mapper.Map<IEnumerable<UserReadDto>>(users);
            return Ok(usersResult);
        }

        //GET /user/{id}
        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repository.User.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned user with specified id");
                var userResult = _mapper.Map<UserReadDto>(user);
                return Ok(userResult);
            }
        }

        //POST /user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto user)
        {
            if (user == null)
            {
                _logger.LogError("User object sent from client is null");
                return BadRequest("User object is null");
            }
            var userEntity = _mapper.Map<User>(user);

            _repository.User.CreateUser(userEntity);
            await _repository.SaveAsync();

            var createdUser = _mapper.Map<UserReadDto>(userEntity);
            return CreatedAtRoute("UserById", new { id = createdUser.UserId }, createdUser);
        }

        //PUT /user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto user)
        {
            if (user == null)
            {
                _logger.LogError("User object sent from client is null");
                return BadRequest("User object is null");
            }
            var userEntity = await _repository.User.GetUserByIdAsync(id);
            if (userEntity == null)
            {
                _logger.LogError($"User with id: {id}, does not exist");
                return NotFound();
            }
            _mapper.Map(user, userEntity);

            _repository.User.UpdateUser(userEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        //PATCH /users/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserPatch(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var userModelFromRepo = await _repository.User.GetUserByIdAsync(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromRepo);
            patchDoc.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(userToPatch, userModelFromRepo);
            _repository.User.UpdateUser(userModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }

        //DELETE /user/{id}
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUser(int id)
        // {
        //     var user = await _repository.User.GetUserByIdAsync(id);
        //     if (user == null)
        //     {
        //         _logger.LogError($"User with id: {id} does not exist");
        //         return NotFound();
        //     }
        //     var clients = await _repository.Client.GetClientsBySalesmanAsync(id);
        //     if (clients.Any())
        //     {
        //         _logger.LogError($"Cannot delete user with id: {id}. It has related clients.");
        //         return BadRequest("Cannot delete user. It has related clients. Delete those first");
        //     }
        //     _repository.User.DeleteUser(user);
        //     await _repository.SaveAsync();
        //     return NoContent();
        // }


    }
}