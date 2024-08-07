using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace Cursus.LMS.Test.UnitTesting
{
    public class LevelServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly LevelService _service;
        private readonly Mock<UserManager<IdentityUser>> _mockUserManager;

        public LevelServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(
            new Mock<IUserStore<IdentityUser>>().Object,
            null, null, null, null, null, null, null, null
        );
            _service = new LevelService(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        private ClaimsPrincipal GetUserPrincipal(string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role)
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            return new ClaimsPrincipal(identity);
        }

        [Fact]
        public async Task GetLevels_AdminRole_ReturnsAllLevels()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Admin);
            var levels = new List<Level>
            {
                new Level { Id = Guid.NewGuid(), Name = "Level 1", Status = 1, CreatedTime = DateTime.Now.AddDays(-1) },
                new Level { Id = Guid.NewGuid(), Name = "Level 2", Status = 2, CreatedTime = DateTime.Now }
            };

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetAllAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(levels);

            // Act
            var result = await _service.GetLevels(user, null, null, null, null, 0, 0);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var levelsDto = Assert.IsType<List<GetLevelDTO>>(result.Result);
            Assert.Equal(2, levelsDto.Count);
        }


        [Fact]
        public async Task GetLevels_NoLevels_ReturnsNoLevels()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Admin);
            var levels = new List<Level>();

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetAllAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(levels);

            // Act
            var result = await _service.GetLevels(user, null, null, null, null, 0, 0);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("There are no levels", result.Message);
        }


        [Fact]
        public async Task GetLevels_WithSorting_ReturnsSortedLevels()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Admin);
            var levels = new List<Level>
            {
                new Level { Id = Guid.NewGuid(), Name = "Level B", Status = 1, CreatedTime = DateTime.Now.AddDays(-1) },
                new Level { Id = Guid.NewGuid(), Name = "Level A", Status = 2, CreatedTime = DateTime.Now }
            };

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetAllAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(levels);

            // Act
            var result = await _service.GetLevels(user, null, null, "name", true, 0, 0);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var levelsDto = Assert.IsType<List<GetLevelDTO>>(result.Result);
            Assert.Equal(2, levelsDto.Count);
            Assert.Equal("Level A", levelsDto.First().Name);
        }

        [Fact]
        public async Task GetLevels_WithPagination_ReturnsPaginatedLevels()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Admin);
            var levels = new List<Level>
            {
                new Level { Id = Guid.NewGuid(), Name = "Level 1", Status = 1, CreatedTime = DateTime.Now.AddDays(-3) },
                new Level { Id = Guid.NewGuid(), Name = "Level 2", Status = 1, CreatedTime = DateTime.Now.AddDays(-2) },
                new Level { Id = Guid.NewGuid(), Name = "Level 3", Status = 1, CreatedTime = DateTime.Now.AddDays(-1) },
            };

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetAllAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(levels);

            // Act
            var result = await _service.GetLevels(user, null, null, null, null, 2, 1);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var levelsDto = Assert.IsType<List<GetLevelDTO>>(result.Result);
            Assert.Single(levelsDto);
            Assert.Equal("Level 2", levelsDto.First().Name);
        }

        [Fact]
        public async Task GetLevel_LevelNotFound_ReturnsNotFound()
        {
            // Arrange
            var user = GetUserPrincipal("Admin");
            var levelId = Guid.NewGuid();

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetLevelById(levelId))
                .ReturnsAsync((Level)null);

            // Act
            var result = await _service.GetLevel(user, levelId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Level was not found", result.Message);
            Assert.Equal("", result.Result);
        }

        [Fact]
        public async Task GetLevel_LevelFound_ReturnsLevel()
        {
            // Arrange
            var user = GetUserPrincipal("Admin");
            var levelId = Guid.NewGuid();
            var level = new Level { Id = levelId, Name = "Test Level" };
            var levelDto = new GetLevelDTO { Id = levelId, Name = "Test Level" };

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetLevelById(levelId))
                .ReturnsAsync(level);

            _mapperMock.Setup(m => m.Map<GetLevelDTO>(level))
                .Returns(levelDto);

            // Act
            var result = await _service.GetLevel(user, levelId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get level successfully", result.Message);
            Assert.Equal(levelDto, result.Result);
        }

        [Fact]
        public async Task GetLevel_MappingError_ReturnsMappingError()
        {
            // Arrange
            var user = GetUserPrincipal("Admin");
            var levelId = Guid.NewGuid();
            var level = new Level { Id = levelId, Name = "Test Level" };

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetLevelById(levelId))
                .ReturnsAsync(level);

            _mapperMock.Setup(m => m.Map<GetLevelDTO>(level))
                .Throws(new AutoMapperMappingException("Mapping error"));

            // Act
            var result = await _service.GetLevel(user, levelId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Failed to map Level to GetLevelDTO", result.Message);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task GetLevel_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var user = GetUserPrincipal("Admin");
            var levelId = Guid.NewGuid();

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetLevelById(levelId))
                .Throws(new Exception("Database error"));

            // Act
            var result = await _service.GetLevel(user, levelId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task GetLevel_LevelFound_ReturnsCorrectLevel()
        {
            // Arrange
            var user = GetUserPrincipal("Admin");
            var levelId = Guid.NewGuid();
            var level = new Level { Id = levelId, Name = "Test Level" };
            var levelDto = new GetLevelDTO { Id = levelId, Name = "Test Level" };

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetLevelById(levelId))
                .ReturnsAsync(level);

            _mapperMock.Setup(m => m.Map<GetLevelDTO>(level))
                .Returns(levelDto);

            // Act
            var result = await _service.GetLevel(user, levelId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(levelDto, result.Result);
        }

        [Fact]
        public async Task GetLevel_ValidUser_ReturnsValidResponse()
        {
            // Arrange
            var user = GetUserPrincipal("Admin");
            var levelId = Guid.NewGuid();
            var level = new Level { Id = levelId, Name = "Test Level" };
            var levelDto = new GetLevelDTO { Id = levelId, Name = "Test Level" };

            _unitOfWorkMock.Setup(u => u.LevelRepository.GetLevelById(levelId))
                .ReturnsAsync(level);

            _mapperMock.Setup(m => m.Map<GetLevelDTO>(level))
                .Returns(levelDto);

            // Act
            var result = await _service.GetLevel(user, levelId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get level successfully", result.Message);
            Assert.Equal(levelDto, result.Result);
        }
        [Fact]
        public async Task CreateLevel_Success_ReturnsSuccess()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var createLevelDto = new CreateLevelDTO
            {
                Name = "New Level"
            };
            var admin = new IdentityUser
            {
                Email = "admin@example.com"
            };
            var level = new Level
            {
                Id = Guid.NewGuid(),
                Name = createLevelDto.Name,
                CreatedBy = admin.Email,
                CreatedTime = DateTime.Now,
                Status = 0
            };

            _mockUserManager.Setup(um => um.FindByIdAsync(userId))
                .ReturnsAsync(admin);

            _unitOfWorkMock.Setup(u => u.LevelRepository.AddAsync(It.IsAny<Level>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(u => u.SaveAsync())
                .ReturnsAsync(1);

            var user = GetUserPrincipal("Admin");

            // Act
            var response = await _service.CreateLevel(user, createLevelDto);

            // Assert
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response.StatusCode);
            Assert.Equal("Level created successfully", response.Message);
            Assert.NotNull(response.Result);
            Assert.IsType<Level>(response.Result);
        }








        [Fact]
        public async Task CreateLevel_SaveFailed_ReturnsServerError()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var createLevelDto = new CreateLevelDTO
            {
                Name = "New Level"
            };
            var admin = new IdentityUser
            {
                Email = "admin@example.com"
            };
            var level = new Level
            {
                Id = Guid.NewGuid(),
                Name = createLevelDto.Name,
                CreatedBy = admin.Email,
                CreatedTime = DateTime.Now,
                Status = 0
            };

            _mockUserManager.Setup(um => um.FindByIdAsync(userId))
                .ReturnsAsync(admin);

            _unitOfWorkMock.Setup(u => u.LevelRepository.AddAsync(It.IsAny<Level>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(u => u.SaveAsync())
                .ThrowsAsync(new Exception("Save failed"));

            var user = GetUserPrincipal("Admin");

            // Act
            var response = await _service.CreateLevel(user, createLevelDto);

            // Assert
            Assert.False(response.IsSuccess);
            Assert.Equal(500, response.StatusCode);
            Assert.Equal("Save failed", response.Message);
        }

        [Fact]
        public async Task GetLevels_AdminRole_ReturnsLevels()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Admin);
            var levels = new List<Level>
            {
                new Level { Id = Guid.NewGuid(), Name = "Level 1", Status = 1, CreatedTime = DateTime.Now },
                new Level { Id = Guid.NewGuid(), Name = "Level 2", Status = 0, CreatedTime = DateTime.Now }
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAllAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(levels);

            _mapperMock.Setup(m => m.Map<List<GetLevelDTO>>(It.IsAny<IEnumerable<Level>>()))
                .Returns(new List<GetLevelDTO> { new GetLevelDTO { Id = levels[0].Id, Name = levels[0].Name }, new GetLevelDTO { Id = levels[1].Id, Name = levels[1].Name } });

            // Act
            var result = await _service.GetLevels(user, null, null, null, null, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var levelsResult = result.Result as List<GetLevelDTO>;
            Assert.Equal(2, levelsResult.Count);
        }

        [Fact]
        public async Task GetLevel_LevelExists_ReturnsLevel()
        {
            // Arrange
            var levelId = Guid.NewGuid();
            var level = new Level
            {
                Id = levelId,
                Name = "Level 1",
                CreatedTime = DateTime.Now,
                CreatedBy = "Admin",
                Status = 0
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetLevelById(levelId))
                .ReturnsAsync(level);

            _mapperMock.Setup(m => m.Map<GetLevelDTO>(It.IsAny<Level>()))
                .Returns(new GetLevelDTO { Id = level.Id, Name = level.Name });

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.GetLevel(user, levelId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var levelResult = result.Result as GetLevelDTO;
            Assert.Equal(levelId, levelResult.Id);
            Assert.Equal("Level 1", levelResult.Name);
        }

        [Fact]
        public async Task CreateLevel_ValidData_ReturnsSuccess()
        {
            // Arrange
            var createLevelDto = new CreateLevelDTO { Name = "New Level" };
            var user = GetUserPrincipal(StaticUserRoles.Admin);

            var admin = new IdentityUser { Email = "admin@example.com" };
            _mockUserManager.Setup(um => um.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(admin);

            _unitOfWorkMock.Setup(x => x.LevelRepository.AddAsync(It.IsAny<Level>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _service.CreateLevel(user, createLevelDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var levelResult = result.Result as Level;
            Assert.Equal("New Level", levelResult.Name);
            Assert.Equal(admin.Email, levelResult.CreatedBy);
        }
        private ClaimsPrincipal GetUserPrincipal(string role, string userName = "admin@example.com")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Name, userName)
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            return new ClaimsPrincipal(identity);
        }

        [Fact]
        public async Task UpdateLevel_LevelExists_ReturnsSuccess()
        {
            // Arrange
            var levelId = Guid.NewGuid();
            var existingLevel = new Level
            {
                Id = levelId,
                Name = "Old Level Name",
                Status = 0,
                CreatedTime = DateTime.Now
            };

            var updateDto = new UpdateLevelDTO
            {
                LevelId = levelId,
                Name = "Updated Level Name"
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(existingLevel);

            _unitOfWorkMock.Setup(x => x.LevelRepository.Update(It.IsAny<Level>()));

            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(1);

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.UpdateLevel(user, updateDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var updatedLevel = result.Result as Level;
            Assert.Equal("Updated Level Name", updatedLevel.Name);
            Assert.Equal(1, updatedLevel.Status);
        }

        [Fact]
        public async Task UpdateLevel_LevelNotFound_ReturnsNotFound()
        {
            // Arrange
            var updateDto = new UpdateLevelDTO
            {
                LevelId = Guid.NewGuid(),
                Name = "Updated Level Name"
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Level)null);

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.UpdateLevel(user, updateDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Level not found", result.Message);
        }

        [Fact]
        public async Task UpdateLevel_SaveChangesFails_ReturnsBadRequest()
        {
            // Arrange
            var levelId = Guid.NewGuid();
            var existingLevel = new Level
            {
                Id = levelId,
                Name = "Old Level Name",
                Status = 0,
                CreatedTime = DateTime.Now
            };

            var updateDto = new UpdateLevelDTO
            {
                LevelId = levelId,
                Name = "Updated Level Name"
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(existingLevel);

            _unitOfWorkMock.Setup(x => x.LevelRepository.Update(It.IsAny<Level>()));

            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(0);

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.UpdateLevel(user, updateDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Failed to update level", result.Message);
        }

        [Fact]
        public async Task UpdateLevel_ExceptionThrown_ReturnsServerError()
        {
            // Arrange
            var levelId = Guid.NewGuid();
            var updateDto = new UpdateLevelDTO
            {
                LevelId = levelId,
                Name = "Updated Level Name"
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.UpdateLevel(user, updateDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Database error", result.Message);
        }

        [Fact]
        public async Task UpdateLevel_UserNotAdmin_ReturnsForbidden()
        {
            // Arrange
            var levelId = Guid.NewGuid();
            var existingLevel = new Level
            {
                Id = levelId,
                Name = "Old Level Name",
                Status = 0,
                CreatedTime = DateTime.Now
            };

            var updateDto = new UpdateLevelDTO
            {
                LevelId = levelId,
                Name = "Updated Level Name"
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(existingLevel);

            _unitOfWorkMock.Setup(x => x.LevelRepository.Update(It.IsAny<Level>()));
            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(1);

            var user = GetUserPrincipal("UserRole");

            // Act
            var result = await _service.UpdateLevel(user, updateDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(403, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Forbidden", result.Message);
        }

        [Fact]
        public async Task UpdateLevel_InvalidLevelId_ReturnsBadRequest()
        {
            // Arrange
            var updateDto = new UpdateLevelDTO
            {
                LevelId = Guid.NewGuid(), // Assuming this ID is invalid
                Name = "Updated Level Name"
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid level ID"));

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.UpdateLevel(user, updateDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Invalid level ID", result.Message);
        }

        [Fact]
        public async Task DeleteLevel_LevelExists_ReturnsSuccess()
        {
            // Arrange
            var levelId = Guid.NewGuid();
            var existingLevel = new Level
            {
                Id = levelId,
                Name = "Level to Delete",
                Status = 0,
                CreatedTime = DateTime.Now
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(existingLevel);

            _unitOfWorkMock.Setup(x => x.LevelRepository.Update(It.IsAny<Level>()));
            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(1);

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.DeleteLevel(user, levelId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var deletedLevel = result.Result as Level;
            Assert.Equal(2, deletedLevel.Status); // Status should be updated to 2
            Assert.Equal(user.Identity.Name, deletedLevel.UpdatedBy);
        }

        [Fact]
        public async Task DeleteLevel_LevelNotFound_ReturnsBadRequest()
        {
            // Arrange
            var levelId = Guid.NewGuid();

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Level)null);

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.DeleteLevel(user, levelId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Delete level successfully", result.Message);
        }

        [Fact]
        public async Task DeleteLevel_ExceptionThrown_ReturnsServerError()
        {
            // Arrange
            var levelId = Guid.NewGuid();

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            var user = GetUserPrincipal(StaticUserRoles.Admin);

            // Act
            var result = await _service.DeleteLevel(user, levelId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Database error", result.Message);
        }

        [Fact]
        public async Task DeleteLevel_UserNotAdmin_ReturnsForbidden()
        {
            // Arrange
            var levelId = Guid.NewGuid();
            var existingLevel = new Level
            {
                Id = levelId,
                Name = "Level to Delete",
                Status = 0,
                CreatedTime = DateTime.Now
            };

            _unitOfWorkMock.Setup(x => x.LevelRepository.GetAsync(It.IsAny<Expression<Func<Level, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(existingLevel);

            _unitOfWorkMock.Setup(x => x.LevelRepository.Update(It.IsAny<Level>()));
            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(1);

            var user = GetUserPrincipal("UserRole");

            // Act
            var result = await _service.DeleteLevel(user, levelId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(403, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Forbidden", result.Message);
        }
    }
}
