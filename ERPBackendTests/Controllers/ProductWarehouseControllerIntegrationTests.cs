using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERPBackend;
using ERPBackend.Entities.Dtos.WarehouseDtos;
using ERPBackend.Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Xunit;

namespace ERPBackendTests.Controllers
{
    public class ProductWarehouseControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductWarehouseControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Warehouseman);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanGetProductWarehouseItems()
        {
            var response = await _client.GetAsync("/product-warehouse");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var warehouseItems = JsonConvert.DeserializeObject<IEnumerable<ProductWarehouseItem>>(stringResponse);
            warehouseItems.Should().HaveCount(4);
        }

        [Fact]
        public async Task CanPatchProductWarehouseItems()
        {
            var jsonPatch = new JsonPatchDocument<ProductWarehouseItemUpdateDto>();
            jsonPatch.Replace(u => u.Quantity, 80);
            var content = new StringContent(JsonConvert.SerializeObject(jsonPatch), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("/product-warehouse/1", content);
            response.EnsureSuccessStatusCode();

            var productWarehouseResponse = await _client.GetAsync("/product-warehouse");
            var stringResponse = await productWarehouseResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<ProductWarehouseItem>>(stringResponse);
            users.Should().Contain(x => x.ProductWarehouseItemId == 1 && x.Quantity == 80);
        }
    }
}