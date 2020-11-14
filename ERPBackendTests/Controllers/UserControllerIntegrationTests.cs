using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERPBackend;
using ERPBackend.Entities.Dtos.UserDtos;
using ERPBackend.Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Xunit;

namespace ERPBackendTests.Controllers
{
    public class UserControllerIntegrationTests : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public UserControllerIntegrationTests(ApiWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            var token = TokenGenerator.GenerateToken(UserRole.Administrator);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        [Fact]
        public async Task CanGetUsers()
        {
            var response = await _client.GetAsync("/users");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(stringResponse);
            users.Should().HaveCount(6);
        }

        [Fact]
        public async Task CanGetUserById()
        {
            var response = await _client.GetAsync("/users/1");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(stringResponse);
            Assert.Equal("Jan", user.FirstName);
        }

        [Fact]
        public async Task CanSignIn()
        {
            var userCredentials = new
            {
                Login = "jan_k",
                Password = "password"
            };
            var content = new StringContent(JsonConvert.SerializeObject(userCredentials), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/users/sign-in", content);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CanChangePasswordUser()
        {
            var changePasswordObject = new
            {
                OldPassword = "password",
                NewPassword = "password1"
            };
            var content = new StringContent(JsonConvert.SerializeObject(changePasswordObject), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/users/change-password/2", content);
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async Task CanGetUsersWithoutSpecifiedUser()
        {
            var response = await _client.GetAsync("/users/info/2");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(stringResponse);
            users.Should().HaveCount(5);
            users.Should().NotContain(x => x.UserId == 2);
        }

        [Fact]
        public async Task CanCreateUser()
        {
            var user = new User { Login = "eryk_f", Password = "password", FirstName = "Eryk", LastName = "Frankowski", PhoneNumber = "123456789", Email = "eryk_f@mail.com", Role = UserRole.Administrator };
            var content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/users", content);
            response.EnsureSuccessStatusCode();

            var usersResponse = await _client.GetAsync("/users");
            var stringResponse = await usersResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(stringResponse);
            users.Should().HaveCount(7);
        }

        [Fact]
        public async Task CanUpdateUser()
        {
            var user = new User { Login = "andrzej_f", Password = "password", FirstName = "Andrzej", LastName = "Frankowski", PhoneNumber = "123456789", Email = "eryk_f@mail.com", Role = UserRole.Administrator };
            var content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/users/5", content);
            response.EnsureSuccessStatusCode();

            var usersResponse = await _client.GetAsync("/users");
            var stringResponse = await usersResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(stringResponse);
            users.Should().Contain(x => x.UserId == 5 && x.FirstName == "Andrzej");
        }

        [Fact]
        public async Task CanPatchUser()
        {
            var jsonPatch = new JsonPatchDocument<UserPatchDto>();
            jsonPatch.Replace(u => u.Status, "Nieaktywny");
            var content = new StringContent(JsonConvert.SerializeObject(jsonPatch), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("/users/5", content);
            response.EnsureSuccessStatusCode();

            var usersResponse = await _client.GetAsync("/users");
            var stringResponse = await usersResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(stringResponse);
            users.Should().Contain(x => x.UserId == 5 && x.Status == UserStatus.Inactive);
        }
    }
}