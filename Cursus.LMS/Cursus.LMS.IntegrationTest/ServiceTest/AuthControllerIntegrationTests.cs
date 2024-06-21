using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cursus.LMS.API;
using Cursus.LMS.API.csproj;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using FluentAssertions;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Xunit;

namespace Cursus.LMS.IntegrationTest.ServiceTest
{
    public class AuthControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program1>>
    {
        private readonly WebApplicationFactory<Program1> _factory;

        public AuthControllerIntegrationTests(WebApplicationFactory<Program1> factory)
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

                    // Other services can be added or mocked as required for testing
                });
            });
        }

        [Fact]
        public async Task SignUpStudent_ValidInput_ReturnsSuccess()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "/api/auth/sign-up-student";
            var registerDto = new RegisterStudentDTO
            {
                Email = "S14@example.com",
                PhoneNumber = "12340",
                CardNumber = "12340",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                Address = "123 Main St",
                BirthDate = DateTime.Now.AddYears(-20),
                FullName = "John Doe",
                Gender = "Male",
                Country = "Country",
                University = "University",
                CardName = "John Doe",
                CardProvider = "Visa"
            };

            // Act
            var jsonContent = JsonConvert.SerializeObject(registerDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDTO>(responseContent);

            // Assert
            Assert.NotNull(responseDto);
            Assert.True(responseDto.IsSuccess);
            Assert.Equal(200, responseDto.StatusCode);
            Assert.Equal("Create new user successfully", responseDto.Message);
        }

        [Fact]
        public async Task SignUpStudent_InValidInput_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "/api/auth/sign-up-student";
            var registerDto = new RegisterStudentDTO
            {
                // Populate with invalid data (missing required fields, invalid format, etc.)
                // For example, here we are not providing FullName and Password fields
                Email = "invalid-email",
                PhoneNumber = "11",
                CardNumber = "11",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                Address = "123 Main St",
                BirthDate = DateTime.Now.AddYears(-20),
                FullName = "John Doe",
                Gender = "Male",
                Country = "Country",
                University = "University",
                CardName = "John Doe",
                CardProvider = "Visa"
            };

            // Act
            var jsonContent = JsonConvert.SerializeObject(registerDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStringAsync();
            var errorResponse = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);

            errorResponse.Should().NotBeNull();
            errorResponse.Title.Should().Be("One or more validation errors occurred.");
            errorResponse.Status.Should().Be(400);
            errorResponse.Errors.Should().ContainKey("Email");
            errorResponse.Errors["Email"].Should().Contain("Invalid email address format.");
        }
        [Fact]
        public async Task SignUpStudent_EmailAlreadyExists_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "/api/auth/sign-up-student";
            var existingEmail = "s2@example.com";

            // Step 1: Ensure the email exists by registering a user with this email
            var initialRegisterRequest = new RegisterStudentDTO
            {
                Email = existingEmail,
                PhoneNumber = "02",
                CardNumber = "02",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                Address = "123 Main St",
                BirthDate = DateTime.Now.AddYears(-20),
                FullName = "John Doe",
                Gender = "Male",
                Country = "Country",
                University = "University",
                CardName = "John Doe",
                CardProvider = "Visa"
            };

            var initialJsonContent = JsonConvert.SerializeObject(initialRegisterRequest);
            var initialContent = new StringContent(initialJsonContent, Encoding.UTF8, "application/json");

            var initialResponse = await client.PostAsync(url, initialContent);
            initialResponse.EnsureSuccessStatusCode(); // Ensure the initial registration is successful

            // Step 2: Attempt to register a new user with the same email
            var userRegisterRequest = new RegisterStudentDTO
            {
                Email = existingEmail, // This email is now already in use
                PhoneNumber = "02",
                CardNumber = "02",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                Address = "123 Main St",
                BirthDate = DateTime.Now.AddYears(-20),
                FullName = "John Doe",
                Gender = "Male",
                Country = "Country",
                University = "University",
                CardName = "John Doe",
                CardProvider = "Visa"
            };

            var jsonContent = JsonConvert.SerializeObject(userRegisterRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStringAsync();
            var registerResponse = JsonConvert.DeserializeObject<ResponseDTO>(responseContent);

            registerResponse.Should().NotBeNull();
            registerResponse.IsSuccess.Should().BeFalse();
            registerResponse.StatusCode.Should().Be(400);
            registerResponse.Message.Should().Be("Email is using by another user");
        
        }
        [Fact]
        public async Task SignUpStudent_PhoneNumberAlreadyExists_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "/api/auth/sign-up-student";
            var existingPhoneNumber = "03";

            // Step 1: Ensure the phone number exists by registering a user with this phone number
            var initialRegisterRequest = new RegisterStudentDTO
            {
                Email = "S3@example.com",
                PhoneNumber = existingPhoneNumber,
                CardNumber = "03",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                Address = "123 Main St",
                BirthDate = DateTime.Now.AddYears(-20),
                FullName = "John Doe",
                Gender = "Male",
                Country = "Country",
                University = "University",
                CardName = "John Doe",
                CardProvider = "Visa"
            };

            var initialJsonContent = JsonConvert.SerializeObject(initialRegisterRequest);
            var initialContent = new StringContent(initialJsonContent, Encoding.UTF8, "application/json");

            var initialResponse = await client.PostAsync(url, initialContent);
            initialResponse.EnsureSuccessStatusCode(); // Ensure the initial registration is successful

            // Step 2: Attempt to register a new user with the same phone number
            var userRegisterRequest = new RegisterStudentDTO
            {
                Email = "S4@example.com",
                PhoneNumber = existingPhoneNumber, // This phone number is now already in use
                CardNumber = "03",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                Address = "123 Main St",
                BirthDate = DateTime.Now.AddYears(-20),
                FullName = "John Doe",
                Gender = "Male",
                Country = "Country",
                University = "University",
                CardName = "John Doe",
                CardProvider = "Visa"
            };

            var jsonContent = JsonConvert.SerializeObject(userRegisterRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStringAsync();
            var registerResponse = JsonConvert.DeserializeObject<ResponseDTO>(responseContent);

            registerResponse.Should().NotBeNull();
            registerResponse.IsSuccess.Should().BeFalse();
            registerResponse.StatusCode.Should().Be(400);
            registerResponse.Message.Should().Be("Phone number is using by another user");
        }

        [Fact]
        public async Task SignUpSignInAndVerifyEmail_ValidCredentials_ReturnsSuccessResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Obtain UserManager instance from service provider
            using (var scope = _factory.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                // 1. Sign Up
                var signUpUrl = "/api/auth/sign-up-student";
                var registerDto = new RegisterStudentDTO
                {
                    Email = "S20@example.com",
                    PhoneNumber = "123450",
                    CardNumber = "123450",
                    Password = "Password123!",
                    ConfirmPassword = "Password123!",
                    Address = "123 Main St",
                    BirthDate = DateTime.Now.AddYears(-20),
                    FullName = "John Doe",
                    Gender = "Male",
                    Country = "Country",
                    University = "University",
                    CardName = "John Doe",
                    CardProvider = "Visa"
                };

                var jsonContentSignUp = JsonConvert.SerializeObject(registerDto);
                var contentSignUp = new StringContent(jsonContentSignUp, Encoding.UTF8, "application/json");

                var responseSignUp = await client.PostAsync(signUpUrl, contentSignUp);
                responseSignUp.EnsureSuccessStatusCode();

                // 2. Simulate Email Verification
                var user = await userManager.FindByEmailAsync(registerDto.Email);
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var verifyEmailUrl = $"/api/auth/verify-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

                var responseVerifyEmail = await client.PostAsync(verifyEmailUrl, null);
                responseVerifyEmail.EnsureSuccessStatusCode();

                // 3. Sign In
                var signInUrl = "/api/auth/sign-in";
                var signDto = new SignDTO
                {
                    Email = registerDto.Email,
                    Password = registerDto.Password
                };

                var jsonContentSignIn = JsonConvert.SerializeObject(signDto);
                var contentSignIn = new StringContent(jsonContentSignIn, Encoding.UTF8, "application/json");

                var responseSignIn = await client.PostAsync(signInUrl, contentSignIn);
                responseSignIn.EnsureSuccessStatusCode();

                // Assert Sign In
                var responseContentSignIn = await responseSignIn.Content.ReadAsStringAsync();
                var responseDtoSignIn = JsonConvert.DeserializeObject<ResponseDTO>(responseContentSignIn);
                Assert.NotNull(responseDtoSignIn);
                Assert.True(responseDtoSignIn.IsSuccess);
                Assert.Equal(200, responseDtoSignIn.StatusCode);
                Assert.Equal("Sign in successfully", responseDtoSignIn.Message);

                // Ensure the Result property is of type SignResponseDTO and access properties
                
                Assert.NotNull(responseDtoSignIn.Result);
                //Assert.NotNull(signResponse.AccessToken);
                //Assert.NotNull(signResponse.RefreshToken);
            }
        }

        [Fact]
        public async Task SignIn_IncorrectPassword_ReturnsBadResponse()
        {
            var client = _factory.CreateClient();

            // Obtain UserManager instance from service provider
            using (var scope = _factory.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                // 1. Sign Up
                var signUpUrl = "/api/auth/sign-up-student";
                var registerDto = new RegisterStudentDTO
                {
                    Email = "S21@example.com",
                    PhoneNumber = "1234560",
                    CardNumber = "1234560",
                    Password = "Password123!",
                    ConfirmPassword = "Password123!",
                    Address = "123 Main St",
                    BirthDate = DateTime.Now.AddYears(-20),
                    FullName = "John Doe",
                    Gender = "Male",
                    Country = "Country",
                    University = "University",
                    CardName = "John Doe",
                    CardProvider = "Visa"
                };

                var jsonContentSignUp = JsonConvert.SerializeObject(registerDto);
                var contentSignUp = new StringContent(jsonContentSignUp, Encoding.UTF8, "application/json");

                var responseSignUp = await client.PostAsync(signUpUrl, contentSignUp);
                responseSignUp.EnsureSuccessStatusCode();

                // 2. Simulate Email Verification
                var user = await userManager.FindByEmailAsync(registerDto.Email);
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var verifyEmailUrl = $"/api/auth/verify-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

                var responseVerifyEmail = await client.PostAsync(verifyEmailUrl, null);
                responseVerifyEmail.EnsureSuccessStatusCode();

                // 3. Sign In
                var signInUrl = "/api/auth/sign-in";
                var signDto = new SignDTO
                {
                    Email = registerDto.Email,
                    Password = "WrongPass123!"
                };

                var jsonContentSignIn = JsonConvert.SerializeObject(signDto);
                var contentSignIn = new StringContent(jsonContentSignIn, Encoding.UTF8, "application/json");

                var responseSignIn = await client.PostAsync(signInUrl, contentSignIn);
                responseSignIn.EnsureSuccessStatusCode();

                // Assert Sign In
                var responseContentSignIn = await responseSignIn.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO>(responseContentSignIn);
                Assert.NotNull(responseDto);
                Assert.False(responseDto.IsSuccess);
                Assert.Equal(400, responseDto.StatusCode);
                Assert.Equal("Incorrect email or password", responseDto.Message);
            }
        }

        [Fact]
        public async Task SignIn_InvalidEmail_ReturnsNotFoundResponse()
        {
            var client = _factory.CreateClient();

            var signInUrl = "/api/auth/sign-in";
            var signDto = new SignDTO
            {
                Email = "nonexistent@example.com",
                Password = "Password123!"
            };

            var jsonContentSignIn = JsonConvert.SerializeObject(signDto);
            var contentSignIn = new StringContent(jsonContentSignIn, Encoding.UTF8, "application/json");

            var responseSignIn = await client.PostAsync(signInUrl, contentSignIn);

            var responseContentSignIn = await responseSignIn.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDTO>(responseContentSignIn);
            Assert.NotNull(responseDto);
            Assert.False(responseDto.IsSuccess);
            Assert.Equal(404, responseDto.StatusCode);
            Assert.Equal("User does not exist!", responseDto.Message);
        }
        [Fact]
        public async Task SignIn_EmailNotConfirmed_ReturnsUnauthorizedResponse()
        {
            var client = _factory.CreateClient();

            // Obtain UserManager instance from service provider
            using (var scope = _factory.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                // Sign Up
                var signUpUrl = "/api/auth/sign-up-student";
                var registerDto = new RegisterStudentDTO
                {
                    Email = "S22@example.com",
                    PhoneNumber = "1234567",
                    CardNumber = "1234567",
                    Password = "Password123!",
                    ConfirmPassword = "Password123!",
                    Address = "123 Main St",
                    BirthDate = DateTime.Now.AddYears(-20),
                    FullName = "John Doe",
                    Gender = "Male",
                    Country = "Country",
                    University = "University",
                    CardName = "John Doe",
                    CardProvider = "Visa"
                };

                var jsonContentSignUp = JsonConvert.SerializeObject(registerDto);
                var contentSignUp = new StringContent(jsonContentSignUp, Encoding.UTF8, "application/json");

                var responseSignUp = await client.PostAsync(signUpUrl, contentSignUp);
                responseSignUp.EnsureSuccessStatusCode();
            }

            // Attempt to Sign In without confirming email
            var signInUrl = "/api/auth/sign-in";
            var signDto = new SignDTO
            {
                Email = "S22@example.com",
                Password = "Password123!"
            };

            var jsonContentSignIn = JsonConvert.SerializeObject(signDto);
            var contentSignIn = new StringContent(jsonContentSignIn, Encoding.UTF8, "application/json");

            var responseSignIn = await client.PostAsync(signInUrl, contentSignIn);


            var responseContentSignIn = await responseSignIn.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDTO>(responseContentSignIn);
            Assert.NotNull(responseDto);
            Assert.False(responseDto.IsSuccess);
            Assert.Equal(401, responseDto.StatusCode);
            Assert.Equal("You need to confirm email!", responseDto.Message);
        }
      

    }
    
}
