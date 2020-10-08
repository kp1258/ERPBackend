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
            throw new System.NotImplementedException();
        }

        public void UpdateClient(Client client)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteClient(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Client> ClientsBySalesman(int id)
        {
            return FindByCondition(a => a.SalesmanId.Equals(id)).ToList();
        }
    }
}