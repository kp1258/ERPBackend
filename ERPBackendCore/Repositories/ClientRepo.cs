using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using System.Threading.Tasks;
using ERPBackend.Entities.QueryParameters;

namespace ERPBackend.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(ERPContext erpContext) : base(erpContext)
        {

        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync(ClientParameters parameters)
        {
            if (parameters.SalesmanId == 0)
            {
                return await FindAll()
                .Include(c => c.Address)
                            .OrderBy(client => client.CompanyName)
                            .ToListAsync();

            }
            else
            {
                return await FindByCondition(c => c.SalesmanId.Equals(parameters.SalesmanId))
                                            .Include(c => c.Address)
                                            .OrderBy(client => client.CompanyName)
                                            .ToListAsync();
            }

        }

        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            return await FindByCondition(client => client.ClientId.Equals(clientId))
                            .Include(c => c.Address)
                            .FirstOrDefaultAsync();
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

        public async Task<IEnumerable<Client>> GetClientsBySalesmanAsync(int salesmanId)
        {
            return await FindByCondition(a => a.SalesmanId.Equals(salesmanId))
                            .Include(c => c.Address)
                            .OrderBy(client => client.CompanyName)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetActiveClientsBySalesmanAsync(int salesmanId)
        {
            return await FindByCondition(c => c.SalesmanId.Equals(salesmanId) && c.Status == ClientStatus.Active)
                            .Include(c => c.Address)
                            .OrderBy(client => client.CompanyName)
                            .ToListAsync();
        }
    }
}