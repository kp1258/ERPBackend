using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.ClientDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.QueryParameters;
using ERPBackend.Services.ModelsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IClientService _service;

        public ClientController(ILogger<ClientController> logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, IClientService service)
        {
            _logger = logger;
            _repository = repositoryWrapper;
            _mapper = mapper;
            _service = service;
        }

        //GET /client
        [HttpGet]
        public async Task<IActionResult> GetAllClients([FromQuery] ClientParameters parameters = null)
        {
            var clients = await _repository.Client.GetAllClientsAsync(parameters);
            if (!clients.Any())
            {
                return NoContent();
            }
            _logger.LogInformation($"Returned all clients");

            var clientsResult = _mapper.Map<IEnumerable<ClientReadDto>>(clients);
            return Ok(clientsResult);
        }

        //GET /client/{id}
        [HttpGet("{id}", Name = "ClientById")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _repository.Client.GetClientByIdAsync(id);
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

        //POST /client
        [Authorize(Roles = "Salesman")]
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientCreateDto client)
        {
            if (client == null)
            {
                _logger.LogError("Client object sent from client is null");
                return BadRequest("Client object is null");
            }
            var clientEntity = _mapper.Map<Client>(client);

            await _service.CreateClient(clientEntity);

            var createdClient = _mapper.Map<ClientReadDto>(clientEntity);
            return CreatedAtRoute("ClientById", new { id = clientEntity.ClientId }, clientEntity);
        }

        //PUT /client/{id}
        [Authorize(Roles = "Salesman")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientUpdateDto client)
        {
            if (client == null)
            {
                _logger.LogError("Client object sent from client is null");
                return BadRequest("Client object is null");
            }
            var clientEntity = await _repository.Client.GetClientByIdAsync(id);
            if (clientEntity == null)
            {
                _logger.LogError($"Client with id {id} does not exist");
                return NotFound();
            }
            var status = clientEntity.Status;
            _mapper.Map(client, clientEntity);

            await _service.UpdateClient(clientEntity, status);

            return NoContent();
        }

        //PATCH /clients/{id}
        [Authorize(Roles = "Salesman")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserPatch(int id, JsonPatchDocument<ClientPatchDto> patchDoc)
        {
            var clientModelFromRepo = await _repository.Client.GetClientByIdAsync(id);
            if (clientModelFromRepo == null)
            {
                return NotFound();
            }
            var clientToPatch = _mapper.Map<ClientPatchDto>(clientModelFromRepo);
            patchDoc.ApplyTo(clientToPatch, ModelState);
            if (!TryValidateModel(clientToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(clientToPatch, clientModelFromRepo);
            _repository.Client.UpdateClient(clientModelFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}