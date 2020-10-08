using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        IEnumerable<Client> ClientsBySalesman(int id);
    }
}