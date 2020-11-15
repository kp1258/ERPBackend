using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERPBackend;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Xunit;

namespace ERPBackendTests.Controllers
{
    public class WarehousemanControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public WarehousemanControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Warehouseman);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanAcceptOrderToRealization()
        {
            var jsonPatch = new JsonPatchDocument<OrderPatchDto>();
            jsonPatch.Replace(u => u.Status, "W realizacji");
            var content = new StringContent(JsonConvert.SerializeObject(jsonPatch), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("/warehousemen/5/orders/2", content);
            response.EnsureSuccessStatusCode();

            var ordersResponse = await _client.GetAsync("/orders");
            var stringResponse = await ordersResponse.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(stringResponse);

            var date = DateTime.Now.ToShortDateString();
            orders.Should().Contain(x => x.OrderId == 2 && x.Status == OrderStatus.InRealization && x.RealizationStartDate.ToShortDateString() == date);
        }

        [Fact]
        public async Task CanCompleteOrder()
        {
            var jsonPatch = new JsonPatchDocument<OrderPatchDto>();
            jsonPatch.Replace(u => u.Status, "Zrealizowane");
            var content = new StringContent(JsonConvert.SerializeObject(jsonPatch), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("/warehousemen/5/orders/2/complete", content);
            response.EnsureSuccessStatusCode();

            var ordersResponse = await _client.GetAsync("/orders");
            var stringResponse = await ordersResponse.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(stringResponse);

            var date = DateTime.Now.ToShortDateString();
            orders.Should().Contain(x => x.OrderId == 2 && x.Status == OrderStatus.Completed && x.CompletionDate.ToShortDateString() == date);

            var warehouseResponse = await _client.GetAsync("/product-warehouse");
            var stringWarehouseResponse = await warehouseResponse.Content.ReadAsStringAsync();
            var warehouseItems = JsonConvert.DeserializeObject<IEnumerable<ProductWarehouseItem>>(stringWarehouseResponse);
            warehouseItems.Should().Contain(x => x.ProductWarehouseItemId == 3 && x.Quantity == 0);
            warehouseItems.Should().Contain(x => x.ProductWarehouseItemId == 4 && x.Quantity == 15);
        }
    }
}