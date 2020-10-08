using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IClientRepository
    {
        IEnumerable<Client> ClientsBySalesman(int id);
    }
}