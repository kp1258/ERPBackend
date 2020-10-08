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
        public IEnumerable<Client> ClientsBySalesman(int id)
        {
            return FindByCondition(a => a.SalesmanId.Equals(id)).ToList();
        }
    }
}