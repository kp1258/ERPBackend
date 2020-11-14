using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERPBackend;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace ERPBackendTests.Controllers
{
    public class StandardPrdouctControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public StandardPrdouctControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Administrator);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanGetProducedStandardProducts()
        {
            var response = await _client.GetAsync("/standard-products/produced");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<StandardProduct>>(stringResponse);
            users.Should().HaveCount(1);
        }

        [Fact]
        public async Task CanCreateStandardProduct()
        {
            var formDictionary = new Dictionary<string, string>();
            formDictionary.Add("Name", "Produkt standardowy 3");
            formDictionary.Add("Dimensions", "100x100");
            formDictionary.Add("StandardProductCategoryId", "1");
            var formContent = new FormUrlEncodedContent(formDictionary);

            var response = await _client.PostAsync("/standard-products", formContent);
            response.EnsureSuccessStatusCode();

            var productsResponse = await _client.GetAsync("/standard-products");
            var stringResponse = await productsResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<StandardProduct>>(stringResponse);
            products.Should().HaveCount(3);

        }

        [Fact]
        public async Task CanUpdateStandardProduct()
        {
            var formDictionary = new Dictionary<string, string>();
            formDictionary.Add("Name", "Nowa nazwa");
            formDictionary.Add("Dimensions", "100x100");
            formDictionary.Add("StandardProductCategoryId", "1");
            var formContent = new FormUrlEncodedContent(formDictionary);

            var response = await _client.PutAsync("/standard-products/3", formContent);
            response.EnsureSuccessStatusCode();

            var productsResponse = await _client.GetAsync("/standard-products");
            var stringResponse = await productsResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<StandardProduct>>(stringResponse);
            products.Should().Contain(x => x.StandardProductId == 3 && x.Name == "Nowa nazwa");
        }

    }
}