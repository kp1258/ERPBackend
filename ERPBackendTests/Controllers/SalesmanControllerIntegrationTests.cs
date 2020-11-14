using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERPBackend;
using ERPBackend.Entities.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace ERPBackendTests.Controllers
{
    public class SalesmanControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public SalesmanControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Salesman);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanGetActiveClientsBySalesman()
        {
            var response = await _client.GetAsync("/salesmen/2/clients/active");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<Client>>(stringResponse);
            users.Should().HaveCount(3);
        }
    }
}