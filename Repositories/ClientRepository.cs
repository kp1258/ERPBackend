using System.Collections.Generic;
using System.Linq;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;

namespace ERPBackend.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(ERPContext erpContext) : base(erpContext)
        {

        }

        public IEnumerable<Client> GetAllClients()
        {
            return FindAll()
                .OrderBy(client => client.CompanyName)
                .ToList();
        }

        public Client GetClientById(int id)
        {
            return FindByCondition(client => client.ClientId.Equals(id)).FirstOrDefault();
        }
        public void CreateClient(Client client)
        {
            Create(client);
        }

        public void UpdateClient(Client client)
        {
            Update(client);
        }

        public void DeleteClient(Client client)
        {
            Delete(client);
        }

        public IEnumerable<Client> ClientsBySalesman(int id)
        {
            return FindByCondition(a => a.SalesmanId.Equals(id)).ToList();
        }
    }
}