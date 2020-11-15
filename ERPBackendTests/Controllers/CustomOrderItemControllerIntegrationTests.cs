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
    public class CustomOrderItemControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CustomOrderItemControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Administrator);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanGetActiveCustomOrderItems()
        {
            var response = await _client.GetAsync("/custom-order-items/active");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var orderItems = JsonConvert.DeserializeObject<IEnumerable<CustomOrderItem>>(stringResponse);
            orderItems.Should().HaveCount(1);
        }

        [Fact]
        public async Task CanGetCustomOrderItemsHistory()
        {
            var response = await _client.GetAsync("/custom-order-items/history");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var orderItems = JsonConvert.DeserializeObject<IEnumerable<CustomOrderItem>>(stringResponse);
            orderItems.Should().HaveCount(3);
        }

        [Fact]
        public async Task CanGetCustomOrderItemsFromActiveOrders()
        {
            var response = await _client.GetAsync("/custom-order-items/active-orders");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var orderItems = JsonConvert.DeserializeObject<IEnumerable<CustomOrderItem>>(stringResponse);
            orderItems.Should().HaveCount(6);
        }

        [Fact]
        public async Task CanGetCustomOrderItemsFromOrdersHistory()
        {
            var response = await _client.GetAsync("/custom-order-items/orders-history");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var orderItems = JsonConvert.DeserializeObject<IEnumerable<CustomOrderItem>>(stringResponse);
            orderItems.Should().HaveCount(3);
        }

        [Fact]
        public async Task CanGetPreparedCustomOrderItems()
        {
            var response = await _client.GetAsync("/custom-order-items/prepared");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var orderItems = JsonConvert.DeserializeObject<IEnumerable<CustomOrderItem>>(stringResponse);
            orderItems.Should().HaveCount(1);
        }
    }
}