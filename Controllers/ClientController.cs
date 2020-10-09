using System.Collections.Generic;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ClientDtos;
using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ClientController(ILogger<ClientController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        //GET api/client
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = _repository.Client.GetAllClients();
            if (clients == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all clients");

            var clientsResult = _mapper.Map<IEnumerable<ClientReadDto>>(clients);
            return Ok(clientsResult);
        }
        [HttpGet("{id}", Name = "ClientById")]
        public IActionResult GetClientById(int id)
        {
            var client = _repository.Client.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Returned client with specified id");
                var clientResult = _mapper.Map<ClientReadDto>(client);
                return Ok(clientResult);
            }
        }
        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientCreateDto client)
        {
            if (client == null)
            {
                _logger.LogError("Client object sent from client is null");
                return BadRequest("Client object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid client object sent from client");
                return BadRequest("Invalid client object");
            }
            var clientEntity = _mapper.Map<Client>(client);
            _repository.Client.CreateClient(clientEntity);
            _repository.Save();

            var createdClient = _mapper.Map<ClientReadDto>(clientEntity);
            return CreatedAtRoute("ClientById", new { id = createdClient.ClientId }, createdClient);
        }
    }
}