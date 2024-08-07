//using System.Net;
//using System.Net.Http.Headers;
//using System.Text;
//using Cursus.LMS.Model.DTO;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using Newtonsoft.Json;
//using Xunit;

//namespace Cursus.LMS.Test
//{
//    public class AuthServiceIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
//    {
//        private readonly WebApplicationFactory<Program> _factory;

//        public AuthServiceIntegrationTests(WebApplicationFactory<Program> factory)
//        {
//            _factory = factory;
//        }

//        [Fact]
//        public async Task SignUpInstructor_ValidInput_ReturnsSuccess()
//        {
//            // Arrange
//            var client = _factory.CreateClient();

//            var signUpDto = new SignUpInstructorDTO
//            {
//                FullName = "Test User",
//                Email = $"test{Guid.NewGuid()}@example.com", // Ensure unique email
//                Password = "Password123!",
//                PhoneNumber = "1234567890",
//                Address = "Test Address",
//                BirthDate = DateTime.Now.AddYears(-20),
//                Country = "Test Country",
//                Degree = "Test Degree",
//                Gender = "Male",
//                Industry = "Test Industry",
//                Introduction = "Test Introduction",
//                TaxNumber = "1234567890"
//            };

//            var content = new StringContent(JsonConvert.SerializeObject(signUpDto), Encoding.UTF8, "application/json");

//            // Act
//            var response = await client.PostAsync("/api/Auth/instructor/sign-up", content);

//            // Assert
//            response.EnsureSuccessStatusCode();
//            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var responseDto = JsonConvert.DeserializeObject<ResponseDTO>(responseContent);

//            Assert.NotNull(responseDto);
//            Assert.True(responseDto.IsSuccess);
//            Assert.Equal("Create new user successfully", responseDto.Message);
//        }

//        // Add more tests for other scenarios:
//        // - SignUpInstructor_ExistingEmail_ReturnsError
//        // - SignUpInstructor_ExistingPhoneNumber_ReturnsError 
//        // - Other AuthService methods...
//    }
//}