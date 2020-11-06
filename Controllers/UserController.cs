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
using ERPBackend.Services;
using ERPBackend.Services.ModelsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ERPBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IAuthenticationService _authenticationService;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, IAuthenticationService authenticationService, IUserService userService)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _userService = userService;
        }


        //POST /users/sign-in
        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] UserSignInDto userCredentials)
        {
            if (userCredentials == null)
            {
                return BadRequest("Invalid client request");
            }
            var response = await _authenticationService.Authenticate(userCredentials);
            if (response == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(response);
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
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto user)
        {
            if (user == null)
            {
                _logger.LogError("User object sent from client is null");
                return BadRequest("User object is null");
            }
            var userEntity = _mapper.Map<User>(user);

            await _userService.CreateUser(userEntity);

            var createdUser = _mapper.Map<UserReadDto>(userEntity);
            return CreatedAtRoute("UserById", new { id = createdUser.UserId }, createdUser);
        }

        //PUT /user/{id}
        [Authorize(Roles = "Administrator")]
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
            var password = userEntity.Password;
            var status = userEntity.Status;
            _mapper.Map(user, userEntity);

            await _userService.UpdateUser(userEntity, password, status);

            return NoContent();
        }

        //PATCH /users/{id}
        [Authorize(Roles = "Administrator")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserPatch(int id, JsonPatchDocument<UserPatchDto> patchDoc)
        {
            var userModelFromRepo = await _repository.User.GetUserByIdAsync(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserPatchDto>(userModelFromRepo);
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