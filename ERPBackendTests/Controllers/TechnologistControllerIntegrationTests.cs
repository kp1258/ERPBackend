using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERPBackend;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Xunit;

namespace ERPBackendTests.Controllers
{
    public class TechnologistControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public TechnologistControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Technologist);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanAcceptProductToPreparation()
        {
            var jsonPatch = new JsonPatchDocument<CustomProductPatchDto>();
            jsonPatch.Replace(u => u.Status, "W przygotowaniu");
            var content = new StringContent(JsonConvert.SerializeObject(jsonPatch), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("/technologists/4/custom-products/6", content);
            response.EnsureSuccessStatusCode();

            var productsResponse = await _client.GetAsync("/custom-products");
            var stringResponse = await productsResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<CustomProduct>>(stringResponse);

            var date = DateTime.Now.ToShortDateString();
            products.Should().Contain(x => x.CustomProductId == 6 && x.Status == CustomProductStatus.InPreparation && x.PreparationStartDate.ToShortDateString() == date);
        }

        [Fact]
        public async Task CanGetPreparedCustomProductsByTechnologist()
        {
            var response = await _client.GetAsync("/technologists/4/custom-products/prepared");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<CustomProduct>>(stringResponse);
            products.Should().HaveCount(5);
        }

        [Fact]
        public async Task CanAddSolutionToProduct()
        {
            var formDictionary = new Dictionary<string, string>();
            formDictionary.Add("SolutionDescription", "Opis rozwiązania");
            var formContent = new FormUrlEncodedContent(formDictionary);

            var response = await _client.PostAsync("/technologists/4/custom-products/7/solution", formContent);
            response.EnsureSuccessStatusCode();

            var productsResponse = await _client.GetAsync("/technologists/4/custom-products/prepared");
            var stringResponse = await productsResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<CustomProduct>>(stringResponse);
            products.Should().HaveCount(6);

            var date = DateTime.Now.ToShortDateString();
            products.Should().Contain(x => x.CustomProductId == 7 && x.Status == CustomProductStatus.Prepared && x.PreparationCompletionDate.ToShortDateString() == date);
        }
    }
}