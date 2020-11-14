using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Services.ModelsServices
{
    public interface IClientService
    {
        Task CreateClient(Client client);
        Task UpdateClient(Client client, ClientStatus status);
    }
}