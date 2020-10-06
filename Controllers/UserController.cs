using System;
using System.Collections.Generic;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        //GET api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repositoryWrapper.User.GetAllUsers();
                _logger.LogInformation($"Returned all users");

                var usersResult = _mapper.Map<IEnumerable<UserReadDto>>(users);
                return Ok(usersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



    }
}