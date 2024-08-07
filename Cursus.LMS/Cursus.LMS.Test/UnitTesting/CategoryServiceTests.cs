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
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class CategoryServiceTests
{
    private readonly CategoryService _categoryService;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;

    public CategoryServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _categoryService = new CategoryService(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnCategories_WhenUserIsAdmin()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, StaticUserRoles.Admin)
        }));

        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "Category 1", Status = StaticStatus.Category.Activated },
            new Category { Id = Guid.NewGuid(), Name = "Category 2", Status = StaticStatus.Category.Activated }
        };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
            .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<AdminCategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(new List<AdminCategoryDTO>());

        // Act
        var result = await _categoryService.GetAll(user, null, null, null, null, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
        Assert.IsType<List<AdminCategoryDTO>>(result.Result);
    }

    [Fact]
    public async Task GetAll_ShouldReturnActivatedCategories_WhenUserIsNotAdmin()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "Category 1", Status = StaticStatus.Category.Deactivated },
            new Category { Id = Guid.NewGuid(), Name = "Category 2", Status = StaticStatus.Category.Activated }
        };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories.Where(c => c.Status <= StaticStatus.Category.Activated).ToList());
        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(new List<CategoryDTO>());

        // Act
        var result = await _categoryService.GetAll(user, null, null, null, null, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
        Assert.IsType<List<CategoryDTO>>(result.Result);
    }

    [Fact]
    public async Task GetAll_ShouldReturnNoCategoriesMessage_WhenNoCategoriesAvailable()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<Category>());

        // Act
        var result = await _categoryService.GetAll(user, null, null, null, null, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("There are no category", result.Message);
    }

    [Fact]
    public async Task GetAll_ShouldFilterCategoriesBasedOnQuery()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Role, "User")
        }));

        var categories = new List<Category>
    {
        new Category { Id = Guid.NewGuid(), Name = "Category A", Description = "Desc A", Status = StaticStatus.Category.Activated },
        new Category { Id = Guid.NewGuid(), Name = "Category B", Description = "Desc B", Status = StaticStatus.Category.Activated }
    };

        var categoryDtos = new List<CategoryDTO>
    {
        new CategoryDTO { Name = "Category A", Description = "Desc A" } // Only the filtered item
    };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);

        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(categoryDtos);

        // Act
        var result = await _categoryService.GetAll(user, "name", "Category A", null, null, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.Single(resultCategories);
        Assert.Equal("Category A", resultCategories.First().Name);
    }


    [Fact]
    public async Task GetAll_ShouldSortCategoriesByName()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Role, "User")
        }));

        var categories = new List<Category>
    {
        new Category { Id = Guid.NewGuid(), Name = "Category B", Status = StaticStatus.Category.Activated },
        new Category { Id = Guid.NewGuid(), Name = "Category A", Status = StaticStatus.Category.Activated }
    };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), null))
                       .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(new List<CategoryDTO>
                   {
                   new CategoryDTO { Name = "Category A" },
                   new CategoryDTO { Name = "Category B" }
                   });

        // Act
        var result = await _categoryService.GetAll(user, null, null, "name", true, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);

        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.NotNull(resultCategories);
        Assert.NotEmpty(resultCategories); // Ensure the result is not empty
        Assert.Equal("Category A", resultCategories.First().Name); // Check the first item is sorted correctly
    }


    [Fact]
    public async Task GetAll_ShouldPaginateCategories()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Role, "User")
        }));

        var categories = Enumerable.Range(1, 10).Select(i => new Category
        {
            Id = Guid.NewGuid(),
            Name = $"Category {i}",
            Status = StaticStatus.Category.Activated
        }).ToList();

        // Map to CategoryDTO for expected result
        var categoryDtos = categories.Select(c => new CategoryDTO { Name = c.Name }).ToList();

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);

        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(categoryDtos);

        // Act
        var result = await _categoryService.GetAll(user, null, null, null, null, 2, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.Equal(10, resultCategories.Count);
        Assert.Equal("Category 1", resultCategories.First().Name);
    }


    [Fact]
    public async Task GetAll_ShouldHandleException()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _categoryService.GetAll(user, null, null, null, null, 1, 10);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Test exception", result.Message);
    }
    [Fact]
    public async Task Search_ShouldReturnCategories_WhenUserIsAdmin()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, StaticUserRoles.Admin)
        }));

        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "Category 1", Status = StaticStatus.Category.Activated },
            new Category { Id = Guid.NewGuid(), Name = "Category 2", Status = StaticStatus.Category.Activated }
        };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<AdminCategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(new List<AdminCategoryDTO>());

        // Act
        var result = await _categoryService.Search(user, null, null, null, null, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
        Assert.IsType<List<AdminCategoryDTO>>(result.Result);
    }

    [Fact]
    public async Task Search_ShouldFilterCategoriesBasedOnQuery()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "Category A", Description = "Desc A", Status = StaticStatus.Category.Activated },
            new Category { Id = Guid.NewGuid(), Name = "Category B", Description = "Desc B", Status = StaticStatus.Category.Activated }
        };

        var filteredCategories = categories.Where(c => c.Name.Contains("Category A")).ToList();
        var categoryDtos = filteredCategories.Select(c => new CategoryDTO { Name = c.Name }).ToList();

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(categoryDtos);

        // Act
        var result = await _categoryService.Search(user, "name", "Category A", null, null, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.Single(resultCategories);
        Assert.Equal("Category A", resultCategories.First().Name);
    }

    [Fact]
    public async Task Search_ShouldSortCategoriesByName()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "Category B", Status = StaticStatus.Category.Activated },
            new Category { Id = Guid.NewGuid(), Name = "Category A", Status = StaticStatus.Category.Activated }
        };

        var sortedCategories = categories.OrderBy(c => c.Name).ToList();
        var categoryDtos = sortedCategories.Select(c => new CategoryDTO { Name = c.Name }).ToList();

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(categoryDtos);

        // Act
        var result = await _categoryService.Search(user, null, null, "name", true, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.Equal("Category A", resultCategories.First().Name);
    }

    [Fact]
    public async Task Search_ShouldPaginateCategories()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        var categories = Enumerable.Range(1, 20).Select(i => new Category
        {
            Id = Guid.NewGuid(),
            Name = $"Category {i}",
            Status = StaticStatus.Category.Activated
        }).ToList();

        var paginatedCategories = categories.Skip(10).Take(10).ToList();
        var categoryDtos = paginatedCategories.Select(c => new CategoryDTO { Name = c.Name }).ToList();

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(categoryDtos);

        // Act
        var result = await _categoryService.Search(user, null, null, null, null, 2, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.Equal(10, resultCategories.Count);
        Assert.Equal("Category 11", resultCategories.First().Name);
    }

    [Fact]
    public async Task Search_ShouldReturnEmpty_WhenNoCategoriesFound()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<Category>());

        // Act
        var result = await _categoryService.Search(user, null, null, null, null, 1, 10);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task Search_ShouldHandleException()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _categoryService.Search(user, null, null, null, null, 1, 10);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Test exception", result.Message);
    }
    [Fact]
    public async Task GetSubCategory_ShouldReturnSubCategories_WhenFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "SubCategory 1", ParentId = id },
            new Category { Id = Guid.NewGuid(), Name = "SubCategory 2", ParentId = id }
        };

        var categoryDtos = categories.Select(c => new CategoryDTO { Name = c.Name }).ToList();

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(categoryDtos);

        // Act
        var result = await _categoryService.GetSubCategory(id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.NotNull(resultCategories);
        Assert.Equal(2, resultCategories.Count);
        Assert.Equal("SubCategory 1", resultCategories.First().Name);
    }

    [Fact]
    public async Task GetSubCategory_ShouldReturnNotFound_WhenNoSubCategories()
    {
        // Arrange
        var id = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<Category>());

        // Act
        var result = await _categoryService.GetSubCategory(id);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task GetSubCategory_ShouldHandleException()
    {
        // Arrange
        var id = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _categoryService.GetSubCategory(id);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Test exception", result.Message);
    }

    [Fact]
    public async Task GetSubCategory_ShouldReturnEmptyList_WhenCategoriesIsNull()
    {
        // Arrange
        var id = Guid.NewGuid();
        List<Category> categories = null;

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);

        // Act
        var result = await _categoryService.GetSubCategory(id);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task GetSubCategory_ShouldMapCategoriesToDTO()
    {
        // Arrange
        var id = Guid.NewGuid();
        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "SubCategory 1", ParentId = id }
        };

        var categoryDto = new List<CategoryDTO> { new CategoryDTO { Name = "SubCategory 1" } };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(categoryDto);

        // Act
        var result = await _categoryService.GetSubCategory(id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.Single(resultCategories);
        Assert.Equal("SubCategory 1", resultCategories.First().Name);
    }

    [Fact]
    public async Task GetSubCategory_ShouldReturnEmptyResult_WhenMapperReturnsEmpty()
    {
        // Arrange
        var id = Guid.NewGuid();
        var categories = new List<Category> { new Category { Id = Guid.NewGuid(), Name = "SubCategory 1", ParentId = id } };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<CategoryDTO>>(It.IsAny<List<Category>>()))
                   .Returns(new List<CategoryDTO>());

        // Act
        var result = await _categoryService.GetSubCategory(id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategories = result.Result as List<CategoryDTO>;
        Assert.Empty(resultCategories);
    }




    [Fact]
    public async Task Get_ShouldReturnCategory_WhenFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        var category = new Category { Id = id, Name = "Category Name" };
        var categoryDto = new CategoryDTO { Name = "Category Name" };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), "ParentCategory"))
                       .ReturnsAsync(category);
        _mockMapper.Setup(m => m.Map<CategoryDTO>(It.IsAny<Category>()))
                   .Returns(categoryDto);

        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _categoryService.Get(user, id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategoryDto = result.Result as CategoryDTO;
        Assert.NotNull(resultCategoryDto);
        Assert.Equal("Category Name", resultCategoryDto.Name);
    }

    [Fact]
    public async Task Get_ShouldReturnNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var id = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), "ParentCategory"))
                       .ReturnsAsync((Category)null);

        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _categoryService.Get(user, id);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task Get_ShouldReturnAdminCategoryDto_WhenAdmin()
    {
        // Arrange
        var id = Guid.NewGuid();
        var category = new Category { Id = id, Name = "Admin Category" };
        var adminCategoryDto = new AdminCategoryDTO { Name = "Admin Category" };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), "ParentCategory"))
                       .ReturnsAsync(category);
        _mockMapper.Setup(m => m.Map<AdminCategoryDTO>(It.IsAny<Category>()))
                   .Returns(adminCategoryDto);

        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, StaticUserRoles.Admin)
        }));

        // Act
        var result = await _categoryService.Get(user, id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultAdminCategoryDto = result.Result as AdminCategoryDTO;
        Assert.NotNull(resultAdminCategoryDto);
        Assert.Equal("Admin Category", resultAdminCategoryDto.Name);
    }

    [Fact]
    public async Task Get_ShouldReturnCategoryDto_WhenUser()
    {
        // Arrange
        var id = Guid.NewGuid();
        var category = new Category { Id = id, Name = "User Category" };
        var categoryDto = new CategoryDTO { Name = "User Category" };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), "ParentCategory"))
                       .ReturnsAsync(category);
        _mockMapper.Setup(m => m.Map<CategoryDTO>(It.IsAny<Category>()))
                   .Returns(categoryDto);

        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _categoryService.Get(user, id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultCategoryDto = result.Result as CategoryDTO;
        Assert.NotNull(resultCategoryDto);
        Assert.Equal("User Category", resultCategoryDto.Name);
    }

    [Fact]
    public async Task Get_ShouldHandleException()
    {
        // Arrange
        var id = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), "ParentCategory"))
                       .ThrowsAsync(new Exception("Test exception"));

        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _categoryService.Get(user, id);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Test exception", result.Message);
    }

    [Fact]
    public async Task Get_ShouldReturnNullResult_WhenCategoryMapperReturnsNull()
    {
        // Arrange
        var id = Guid.NewGuid();
        var category = new Category { Id = id };
        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), "ParentCategory"))
                       .ReturnsAsync(category);
        _mockMapper.Setup(m => m.Map<CategoryDTO>(It.IsAny<Category>()))
                   .Returns((CategoryDTO)null);

        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _categoryService.Get(user, id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Null(result.Result);
    }
    [Fact]
    public async Task CreateCategory_ShouldCreateSuccessfully_WhenValidDataIsProvided()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var createCategoryDto = new CreateCategoryDTO
        {
            Name = "New Category",
            Description = "Category Description",
            ParentId = null
        };

        // Mock the behavior of the CategoryRepository
        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<Category>());

        _mockUnitOfWork.Setup(u => u.CategoryRepository.AddAsync(It.Is<Category>(c => c.Name == createCategoryDto.Name &&
                                                                                     c.Description == createCategoryDto.Description &&
                                                                                     c.ParentId == null)))
                       .Returns(Task.CompletedTask);

        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _categoryService.CreateCategory(user, createCategoryDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
    }
    [Fact]
    public async Task CreateCategory_ShouldReturnNotFound_WhenParentCategoryDoesNotExist()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var createCategoryDto = new CreateCategoryDTO
        {
            Name = "Child Category",
            Description = "Category Description",
            ParentId = Guid.NewGuid().ToString()
        };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((Category)null);
        _mockUnitOfWork.Setup(u => u.CategoryRepository.AddAsync(It.IsAny<Category>()))
                       .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _categoryService.CreateCategory(user, createCategoryDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
    }
    [Fact]
    public async Task CreateCategory_ShouldReturnBadRequest_WhenSaveFails()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var createCategoryDto = new CreateCategoryDTO
        {
            Name = "New Category",
            Description = "Category Description",
            ParentId = null
        };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<Category>());
        _mockUnitOfWork.Setup(u => u.CategoryRepository.AddAsync(It.IsAny<Category>()))
                       .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(0);

        // Act
        var result = await _categoryService.CreateCategory(user, createCategoryDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Null(result.Result);
    }
    [Fact]
    public async Task CreateCategory_ShouldCreateCategoryWithParent_WhenValidDataIsProvided()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var createCategoryDto = new CreateCategoryDTO
        {
            Name = "Child Category",
            Description = "Category Description",
            ParentId = Guid.NewGuid().ToString()
        };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new Category { Id = Guid.Parse(createCategoryDto.ParentId) });
        _mockUnitOfWork.Setup(u => u.CategoryRepository.AddAsync(It.IsAny<Category>()))
                       .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _categoryService.CreateCategory(user, createCategoryDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
    }

    [Fact]
    public async Task Update_ShouldReturnSuccess_WhenValidDataIsProvided()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var categoryId = Guid.NewGuid();
        var updateCategoryDTO = new UpdateCategoryDTO
        {
            Id = categoryId,
            Name = "Updated Category",
            Description = "Updated Description",
            ParentId = null,
            Status = 1
        };

        var existingCategory = new Category { Id = categoryId };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(existingCategory);
        _mockUnitOfWork.Setup(u => u.CategoryRepository.Update(It.IsAny<Category>()))
                       .Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _categoryService.Update(user, updateCategoryDTO);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(updateCategoryDTO.Name, ((Category)result.Result).Name);
    }

    [Fact]
    public async Task Update_ShouldReturnNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var updateCategoryDTO = new UpdateCategoryDTO
        {
            Id = Guid.NewGuid(),
            Name = "Updated Category",
            Description = "Updated Description",
            ParentId = null,
            Status = 1
        };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((Category)null);

        // Act
        var result = await _categoryService.Update(user, updateCategoryDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public async Task Update_ShouldReturnFailure_WhenSaveFails()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var categoryId = Guid.NewGuid();
        var updateCategoryDTO = new UpdateCategoryDTO
        {
            Id = categoryId,
            Name = "Updated Category",
            Description = "Updated Description",
            ParentId = null,
            Status = 1
        };

        var existingCategory = new Category { Id = categoryId };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(existingCategory);
        _mockUnitOfWork.Setup(u => u.CategoryRepository.Update(It.IsAny<Category>()))
                       .Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(0);

        // Act
        var result = await _categoryService.Update(user, updateCategoryDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task Update_ShouldReturnServerError_WhenExceptionIsThrown()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var updateCategoryDTO = new UpdateCategoryDTO
        {
            Id = Guid.NewGuid(),
            Name = "Updated Category",
            Description = "Updated Description",
            ParentId = null,
            Status = 1
        };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Test Exception"));

        // Act
        var result = await _categoryService.Update(user, updateCategoryDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
    }
    [Fact]
    public async Task Delete_ShouldReturnSuccess_WhenCategoryIsDeletedSuccessfully()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var categoryId = Guid.NewGuid();
        var category = new Category { Id = categoryId, Status = 0 };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(category);
        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<Category>());
        _mockUnitOfWork.Setup(u => u.CategoryRepository.Update(It.IsAny<Category>()))
                       .Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _categoryService.Delete(user, categoryId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(categoryId, result.Result);
    }

    [Fact]
    public async Task Delete_ShouldReturnNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var categoryId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((Category)null);

        // Act
        var result = await _categoryService.Delete(user, categoryId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public async Task Delete_ShouldReturnError_WhenCategoryHasSubcategories()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var categoryId = Guid.NewGuid();
        var category = new Category { Id = categoryId, Status = 0 };
        var subCategories = new List<Category>
    {
        new Category { Id = Guid.NewGuid(), ParentId = categoryId, Name = "Subcategory" }
    };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(category);
        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(subCategories);

        // Act
        var result = await _categoryService.Delete(user, categoryId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Contains(subCategories, sc => sc.Id == ((dynamic)result.Result).First().Id);
    }

    [Fact]
    public async Task Delete_ShouldReturnFailure_WhenSaveFails()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var categoryId = Guid.NewGuid();
        var category = new Category { Id = categoryId, Status = 0 };

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(category);
        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<Category>());
        _mockUnitOfWork.Setup(u => u.CategoryRepository.Update(It.IsAny<Category>()))
                       .Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(0);

        // Act
        var result = await _categoryService.Delete(user, categoryId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task Delete_ShouldReturnServerError_WhenExceptionIsThrown()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, "testuser")
        }));

        var categoryId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.CategoryRepository.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Test Exception"));

        // Act
        var result = await _categoryService.Delete(user, categoryId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
    }

}
