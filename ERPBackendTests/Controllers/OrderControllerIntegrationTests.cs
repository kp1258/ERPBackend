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
    public class OrderControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public OrderControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Salesman);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanGetPlacedOrders()
        {
            var response = await _client.GetAsync("/orders/placed");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<Order>>(stringResponse);
            users.Should().HaveCount(2);
        }

        [Fact]
        public async Task CanGetActiveOrders()
        {
            var response = await _client.GetAsync("/orders/active");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<Order>>(stringResponse);
            users.Should().HaveCount(4);
        }

        [Fact]
        public async Task CanGetOrdersHistory()
        {
            var response = await _client.GetAsync("/orders/history");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<Order>>(stringResponse);
            users.Should().HaveCount(2);
        }
    }
}