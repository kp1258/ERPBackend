using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.QueryParameters;

namespace ERPBackend.Contracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync(ClientParameters parameters);
        Task<Client> GetClientByIdAsync(int clietId);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        Task<IEnumerable<Client>> GetClientsBySalesmanAsync(int salesmanId);
        Task<IEnumerable<Client>> GetActiveClientsBySalesmanAsync(int salesmanId);
    }
}