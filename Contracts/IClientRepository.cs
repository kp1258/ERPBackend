using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int clietId);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        IEnumerable<Client> ClientsBySalesman(int salesmanId);
    }
}