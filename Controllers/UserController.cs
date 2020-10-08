using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Dtos.UserDtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        public UserController(ILogger<UserController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
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
        //GET api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _repositoryWrapper.User.GetAllUsers();
            _logger.LogInformation($"Returned all users");

            var usersResult = _mapper.Map<IEnumerable<UserReadDto>>(users);
            return Ok(usersResult);
        }

        [HttpGet("{id}", Name = "UserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _repositoryWrapper.User.GetUserById(id);
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

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDto user)
        {
            if (user == null)
            {
                _logger.LogError("User object sent from client is null");
                return BadRequest("User object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid user object sent from client");
                return BadRequest("Invalid model object");
            }
            var userEntity = _mapper.Map<User>(user);

            _repositoryWrapper.User.CreateUser(userEntity);
            _repositoryWrapper.Save();

            var createdUser = _mapper.Map<UserReadDto>(userEntity);
            return CreatedAtRoute("UserById", new { id = createdUser.UserId }, createdUser);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserUpdateDto user)
        {
            if (user == null)
            {
                _logger.LogError("User object sent from client is null");
                return BadRequest("User object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid user object sent from client");
                return BadRequest("Invalid model object");
            }
            var userEntity = _repositoryWrapper.User.GetUserById(id);
            if (userEntity == null)
            {
                _logger.LogError($"User with id: {id}, does not exist");
                return NotFound();
            }
            _mapper.Map(user, userEntity);

            _repositoryWrapper.User.UpdateUser(userEntity);
            _repositoryWrapper.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id)
        {
            var user = _repositoryWrapper.User.GetUserById(id);
            if (user == null)
            {
                _logger.LogError($"User with id: {id} does not exist");
                return NotFound();
            }
            if (_repositoryWrapper.Client.ClientsBySalesman(id).Any())
            {
                _logger.LogError($"Cannot delete user with id: {id}. It has related clients.");
                return BadRequest("Cannot delete user. It has related clients. Delete those first");
            }
            _repositoryWrapper.User.DeleteUser(user);
            _repositoryWrapper.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult BlockUser()
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UnblockUser()
        {
            return NoContent();
        }

    }
}