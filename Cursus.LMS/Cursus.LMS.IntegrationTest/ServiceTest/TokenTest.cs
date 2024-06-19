using Cursus.LMS.API.csproj;
using Cursus.LMS.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using FluentAssertions;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cursus.LMS.IntegrationTest.ServiceTest
{
    public class TokenTest(AuthServiceIntegrationTests<Program1> factory) : IClassFixture<AuthServiceIntegrationTests<Program1>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task GenerateAccessToken_ValidUser_ReturnsToken()
        {
            // Arrange
            var userLoginRequest = new SignDTO
            {
                Email = "S2@example.com",
                Password = "Password123!"
            };

            var jsonContent = JsonSerializer.Serialize(userLoginRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Auth/sign-in", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var signInResponse = JsonSerializer.Deserialize<ResponseDTO>(responseContent);

            // Assert
            signInResponse.Should().NotBeNull();
            signInResponse.IsSuccess.Should().BeTrue();
            signInResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);
            signInResponse.Result.Should().NotBeNull();
           // signInResponse.Result.AccessToken.Should().NotBeNullOrEmpty();
           // signInResponse.Result.RefreshToken.Should().NotBeNullOrEmpty();
        }
    }
}
