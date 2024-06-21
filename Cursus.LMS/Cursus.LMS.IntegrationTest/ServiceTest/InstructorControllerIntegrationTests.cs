using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cursus.LMS.API.csproj;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Model.DTO;
using FluentAssertions;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Cursus.LMS.IntegrationTest.ServiceTest
{
    public class InstructorControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program1>>
    {
        private readonly WebApplicationFactory<Program1> _factory;

        public InstructorControllerIntegrationTests(WebApplicationFactory<Program1> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    // Remove existing ApplicationDbContext registration
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Add ApplicationDbContext with In-Memory Database
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDb");
                    });

                    // Register Firebase services
                    services.AddFirebaseServices();

                    // Replace or mock other dependencies as needed
                    services.AddSingleton<StorageClient>(provider =>
                    {
                        var credentialPath = Path.Combine(Directory.GetCurrentDirectory(),
                            "cursus-lms-storage-firebase-adminsdk-51r7b-102f4637ef.json");
                        return StorageClient.Create(GoogleCredential.FromFile(credentialPath));
                    });
                });
            });
        }
        [Fact]
        public async Task GetAllInstructor_ReturnsInstructors()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/Instructor");
            
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDTO>(responseString);
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.StatusCode.Should().Be(200);
            result.Message.Should().Be("Get all category successfully");
        }

    }
}
