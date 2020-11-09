using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public class ClientService : IClientService
    {
        private IRepositoryWrapper _repository;

        public ClientService(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        public async Task CreateClient(Client client)
        {
            client.Status = ClientStatus.Active;
            _repository.Client.CreateClient(client);
            await _repository.SaveAsync();
        }

        public async Task UpdateClient(Client client, ClientStatus status)
        {
            client.Status = status;
            _repository.Client.UpdateClient(client);
            await _repository.SaveAsync();
        }
    }
}