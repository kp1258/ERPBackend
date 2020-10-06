using System;
using ERPBackend.Contracts;
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

        public UserController(ILogger<UserController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        //GET api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repositoryWrapper.User.GetAllUsers();
                _logger.LogInformation($"Returned all users");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _repositoryWrapper.User.GetUserById(userId);
                _logger.LogInformation($"Returned user with specified id");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



    }
}