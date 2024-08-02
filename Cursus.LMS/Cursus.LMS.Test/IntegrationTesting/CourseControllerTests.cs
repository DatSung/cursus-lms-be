//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;
//using Xunit;
//using Cursus.LMS.Model.DTO;
//using Cursus.LMS.Test;
//using Microsoft.AspNetCore.Mvc.Testing;

//namespace Cursus.LMS.IntegrationTests
//{
//    public class CourseControllerIntegrationTests : IClassFixture<WebApplicationFactory<TestStartup>>
//    {
//        private readonly HttpClient _client;

//        public CourseControllerIntegrationTests(WebApplicationFactory<TestStartup> factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Fact]
//        public async Task GetCourses_ReturnsSuccessStatusCode()
//        {
//            // Arrange
//            var requestUri = "/api/course?pageNumber=1&pageSize=5";

//            // Act
//            var response = await _client.GetAsync(requestUri);

//            // Assert
//            response.EnsureSuccessStatusCode();
//            var responseDto = await response.Content.ReadFromJsonAsync<ResponseDTO>();
//            Assert.NotNull(responseDto);
//            Assert.True(responseDto.IsSuccess);
//            Assert.Equal(200, responseDto.StatusCode);
//        }

//        [Fact]
//        public async Task GetCourses_WithFilters_ReturnsFilteredResults()
//        {
//            // Arrange
//            var requestUri = "/api/course?filterOn=title&filterQuery=TestTitle&pageNumber=1&pageSize=5";

//            // Act
//            var response = await _client.GetAsync(requestUri);

//            // Assert
//            response.EnsureSuccessStatusCode();
//            var responseDto = await response.Content.ReadFromJsonAsync<ResponseDTO>();
//            Assert.NotNull(responseDto);
//            Assert.True(responseDto.IsSuccess);
//            Assert.Equal(200, responseDto.StatusCode);

//            // Check if the result contains courses that match the filter
//            Assert.All(((List<GetCourseVersionDTO>)responseDto.Result), course =>
//                Assert.Contains("TestTitle", course.Title, StringComparison.OrdinalIgnoreCase));
//        }

//        [Fact]
//        public async Task GetCourses_WithPagination_ReturnsCorrectPage()
//        {
//            // Arrange
//            var requestUri = "/api/course?pageNumber=2&pageSize=5";

//            // Act
//            var response = await _client.GetAsync(requestUri);

//            // Assert
//            response.EnsureSuccessStatusCode();
//            var responseDto = await response.Content.ReadFromJsonAsync<ResponseDTO>();
//            Assert.NotNull(responseDto);
//            Assert.True(responseDto.IsSuccess);
//            Assert.Equal(200, responseDto.StatusCode);

//            // Check that the response contains a subset of courses based on pagination
//            Assert.True(((List<GetCourseVersionDTO>)responseDto.Result).Count <= 5);
//        }
//    }
//}
