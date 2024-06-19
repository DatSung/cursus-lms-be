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

namespace Cursus.LMS.IntegrationTest.ServiceTest
{
    public class AuthServiceEndpointTest(AuthServiceIntegrationTests<Program1> factory) : IClassFixture<AuthServiceIntegrationTests<Program1>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task Registration_Successful()
        {
            // Sắp xếp
            var userRegisterRequest = new RegisterStudentDTO
            {
                Email = "S1@example.com",
                PhoneNumber = "01",
                CardNumber = "01",
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

            var jsonContent = JsonSerializer.Serialize(userRegisterRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Thực hiện
            var response = await _client.PostAsync("/api/Auth/sign-up-student", content);

            // Xác nhận
            response.Should().NotBeNull();
            response.EnsureSuccessStatusCode(); // Đảm bảo mã trạng thái 200-299

            var responseContent = await response.Content.ReadAsStringAsync();
            var registerResponse = JsonSerializer.Deserialize<ResponseDTO>(responseContent);

            registerResponse.Should().NotBeNull();
            registerResponse.IsSuccess.Should().BeTrue();
            registerResponse.StatusCode.Should().Be(200);
            registerResponse.Message.Should().Be("Create new user successfully");
        }
        [Fact]
        public async Task Registration_InvalidInputData()
        {
            // Arrange
            var userRegisterRequest = new RegisterStudentDTO
            {
                Email = "invalid-email",
                PhoneNumber = "01",
                CardNumber = "01",
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

            var jsonContent = JsonSerializer.Serialize(userRegisterRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Auth/sign-up-student", content);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStringAsync();
            var errorResponse = JsonSerializer.Deserialize<ValidationProblemDetails>(responseContent);

            errorResponse.Should().NotBeNull();
            errorResponse.Title.Should().Be("One or more validation errors occurred.");
            errorResponse.Status.Should().Be(400);
            errorResponse.Errors.Should().ContainKey("Email");
            errorResponse.Errors["Email"].Should().Contain("Invalid email address format.");
        }
        [Fact]
        public async Task Registration_EmailAlreadyInUse()
        {
            // Arrange
            var existingEmail = "S2@example.com";

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

            var initialJsonContent = JsonSerializer.Serialize(initialRegisterRequest);
            var initialContent = new StringContent(initialJsonContent, Encoding.UTF8, "application/json");

            var initialResponse = await _client.PostAsync("/api/Auth/sign-up-student", initialContent);
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

            var jsonContent = JsonSerializer.Serialize(userRegisterRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Auth/sign-up-student", content);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStringAsync();
            var registerResponse = JsonSerializer.Deserialize<ResponseDTO>(responseContent);

            registerResponse.Should().NotBeNull();
            registerResponse.IsSuccess.Should().BeFalse();
            registerResponse.StatusCode.Should().Be(400);
            registerResponse.Message.Should().Be("Email is using by another user");
        }

        [Fact]
        public async Task Registration_PhoneNumberAlreadyInUse()
        {
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

            var initialJsonContent = JsonSerializer.Serialize(initialRegisterRequest);
            var initialContent = new StringContent(initialJsonContent, Encoding.UTF8, "application/json");

            var initialResponse = await _client.PostAsync("/api/Auth/sign-up-student", initialContent);
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

            var jsonContent = JsonSerializer.Serialize(userRegisterRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Auth/sign-up-student", content);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStringAsync();
            var registerResponse = JsonSerializer.Deserialize<ResponseDTO>(responseContent);

            registerResponse.Should().NotBeNull();
            registerResponse.IsSuccess.Should().BeFalse();
            registerResponse.StatusCode.Should().Be(400);
            registerResponse.Message.Should().Be("Phone number is using by another user");



        }

        [Fact]
        public async Task Registration_CardNumberAlreadyInUse()
        {
            // Arrange
            var existingCardNumber = "05";

            // Step 1: Ensure the card number exists by registering a user with this card number
            var initialRegisterRequest = new RegisterStudentDTO
            {
                Email = "S5@example.com",
                PhoneNumber = "04",
                CardNumber = existingCardNumber,
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

            var initialJsonContent = JsonSerializer.Serialize(initialRegisterRequest);
            var initialContent = new StringContent(initialJsonContent, Encoding.UTF8, "application/json");

            var initialResponse = await _client.PostAsync("/api/Auth/sign-up-student", initialContent);
            initialResponse.EnsureSuccessStatusCode(); // Ensure the initial registration is successful

            // Step 2: Attempt to register a new user with the same card number
            var userRegisterRequest = new RegisterStudentDTO
            {
                Email = "S6@example.com",
                PhoneNumber = "05",
                CardNumber = existingCardNumber, // This card number is now already in use
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

            var jsonContent = JsonSerializer.Serialize(userRegisterRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Auth/sign-up-student", content);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStringAsync();
            var registerResponse = JsonSerializer.Deserialize<ResponseDTO>(responseContent);

            registerResponse.Should().NotBeNull();
            registerResponse.IsSuccess.Should().BeFalse();
            registerResponse.StatusCode.Should().Be(400);
            registerResponse.Message.Should().Be("Card number is using by another user");
        }

        //Email = "S6@example.com"
        //PhoneNumber = "05"
        //CardNumber = "05"


        [Fact]
        public async Task SignUpInstructor_Successful()
        {
            // Arrange
            var instructorDto = new InstructorDTO
            {
                Email = "I1@example.com",
                PhoneNumber = "07",
                CardNumber = "07",
                Password = "Password123.",
                ConfirmPassword = "Password123.",
                Address = "123 Main St",
                BirthDate = DateTime.Now.AddYears(-30),
                FullName = "Jane Doe",
                Gender = "Female",
                Country = "Country",
                Degree = "Ph.D.",
                Industry = "Education",
                Introduction = "Experienced instructor in mathematics",
                CardName = "Jane Doe",
                CardProvider = "Visa",
                TaxNumber = "1234567890"
            };

            var jsonContent = JsonSerializer.Serialize(instructorDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Auth/sign-up-instructor", content);

            // Assert
            response.Should().NotBeNull();
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var registerResponse = JsonSerializer.Deserialize<ResponseDTO>(responseContent);

            registerResponse.Should().NotBeNull();
            registerResponse.IsSuccess.Should().BeTrue();
            registerResponse.StatusCode.Should().Be(200);
            registerResponse.Message.Should().Be("Create new user successfully");
        }

    }
}
