using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERPBackend;
using ERPBackend.Entities.Dtos.ClientDtos;
using ERPBackend.Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Xunit;

namespace ERPBackendTests.Controllers
{
    public class ClientControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ClientControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Salesman);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanGetClients()
        {
            var response = await _client.GetAsync("/clients");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<Client>>(stringResponse);
            users.Should().HaveCount(3);
        }

        [Fact]
        public async Task CanGetClientById()
        {
            var response = await _client.GetAsync("/clients/2");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var client = JsonConvert.DeserializeObject<Client>(stringResponse);
            Assert.Equal("Edward", client.FirstName);

        }

        [Fact]
        public async Task CanCreateClient()
        {
            var client = new Client
            {
                CompanyName = "Nazwa firmy",
                FirstName = "Eryk",
                LastName = "Frankowski",
                PhoneNumber = "123456789",
                Email = "eryk_f@mail.com",
                Address = new Address { Street = "Nazwa ulicy", PostalCode = "68-200", City = "Miasto" },
                SalesmanId = 2
            };
            var content = new StringContent(JsonConvert.SerializeObject(client), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/clients", content);
            response.EnsureSuccessStatusCode();

            var clientsResponse = await _client.GetAsync("/clients");
            var stringResponse = await clientsResponse.Content.ReadAsStringAsync();
            var clients = JsonConvert.DeserializeObject<IEnumerable<Client>>(stringResponse);
            clients.Should().HaveCount(4);
        }

        [Fact]
        public async Task CanUpdateClient()
        {
            var client = new Client
            {
                CompanyName = "Nowa nazwa firmy",
                FirstName = "Eryk",
                LastName = "Frankowski",
                PhoneNumber = "123456789",
                Email = "eryk_f@mail.com",
                Address = new Address { Street = "Nazwa ulicy", PostalCode = "68-200", City = "Miasto" },
                SalesmanId = 2
            };
            var content = new StringContent(JsonConvert.SerializeObject(client), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/clients/4", content);
            response.EnsureSuccessStatusCode();

            var clientsResponse = await _client.GetAsync("/clients");
            var stringResponse = await clientsResponse.Content.ReadAsStringAsync();
            var clients = JsonConvert.DeserializeObject<IEnumerable<Client>>(stringResponse);
            clients.Should().Contain(x => x.ClientId == 4 && x.CompanyName == "Nowa nazwa firmy");
        }

        [Fact]
        public async Task CanPatchClient()
        {
            var jsonPatch = new JsonPatchDocument<ClientPatchDto>();
            jsonPatch.Replace(u => u.Status, "Nieaktywny");
            var content = new StringContent(JsonConvert.SerializeObject(jsonPatch), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("/clients/3", content);
            response.EnsureSuccessStatusCode();

            var clientsResponse = await _client.GetAsync("/clients");
            var stringResponse = await clientsResponse.Content.ReadAsStringAsync();
            var clients = JsonConvert.DeserializeObject<IEnumerable<Client>>(stringResponse);
            clients.Should().Contain(x => x.ClientId == 3 && x.Status == ClientStatus.Inactive);
        }

    }
}