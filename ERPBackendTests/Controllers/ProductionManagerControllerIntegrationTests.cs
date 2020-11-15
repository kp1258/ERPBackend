using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERPBackend;
using ERPBackend.Entities.Dtos;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Xunit;

namespace ERPBackendTests.Controllers
{
    public class ProductionManagerControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductionManagerControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.ProductionManager);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanAcceptCustomOrderItemToProduction()
        {
            var jsonPatch = new JsonPatchDocument<CustomOrderItemPatchDto>();
            jsonPatch.Replace(u => u.Status, "W produkcji");
            var content = new StringContent(JsonConvert.SerializeObject(jsonPatch), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("/production-managers/3/custom-order-items/9", content);
            response.EnsureSuccessStatusCode();

            var itemsResponse = await _client.GetAsync("/custom-order-items");
            var stringResponse = await itemsResponse.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<IEnumerable<CustomOrderItem>>(stringResponse);

            var date = DateTime.Now.ToShortDateString();
            items.Should().Contain(x => x.CustomOrderItemId == 9 && x.Status == CustomOrderItemStatus.InProduction && x.ProductionStartDate.ToShortDateString() == date);
        }

        [Fact]
        public async Task CanCompleteCustomOrderItem()
        {
            var jsonPatch = new JsonPatchDocument<CustomOrderItemPatchDto>();
            jsonPatch.Replace(u => u.Status, "Zrealizowany");
            var content = new StringContent(JsonConvert.SerializeObject(jsonPatch), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("/production-managers/3/custom-order-items/8/complete", content);
            response.EnsureSuccessStatusCode();

            var itemsResponse = await _client.GetAsync("/custom-order-items");
            var stringResponse = await itemsResponse.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<IEnumerable<CustomOrderItem>>(stringResponse);

            var date = DateTime.Now.ToShortDateString();
            items.Should().Contain(x => x.CustomOrderItemId == 8 && x.Status == CustomOrderItemStatus.Completed && x.CompletionDate.ToShortDateString() == date);
        }

        [Fact]
        public async Task CanGetMissingProducts()
        {
            var response = await _client.GetAsync("/production-managers/3/standard-products");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<MissingProductDto>>(stringResponse);
            products.Should().HaveCount(2);
            products.Should().Contain(x => x.StandardProduct.StandardProductId == 1 && x.Quantity == 30);
            products.Should().Contain(x => x.StandardProduct.StandardProductId == 2 && x.Quantity == 20);
        }

    }
}