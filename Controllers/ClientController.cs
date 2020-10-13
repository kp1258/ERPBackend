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
    [Route("client")]
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

        //GET api/client/{id}
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

        //POST api/client
        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientCreateDto client)
        {
            if (client == null)
            {
                _logger.LogError("Client object sent from client is null");
                return BadRequest("Client object is null");
            }
            var clientEntity = _mapper.Map<Client>(client);
            _repository.Client.CreateClient(clientEntity);
            _repository.Save();

            var createdClient = _mapper.Map<ClientReadDto>(clientEntity);
            return CreatedAtRoute("ClientById", new { id = createdClient.ClientId }, createdClient);
        }

        //PUT api/client/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientUpdateDto client)
        {
            if (client == null)
            {
                _logger.LogError("Client object sent from client is null");
                return BadRequest("Client object is null");
            }
            var clientEntity = _repository.Client.GetClientById(id);
            if (clientEntity == null)
            {
                _logger.LogError($"Client with id {id} does not exist");
                return NotFound();
            }
            _mapper.Map(client, clientEntity);

            _repository.Client.UpdateClient(clientEntity);
            _repository.Save();
            return NoContent();
        }
    }
}