using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<ResponseDTO> GetAll
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize)
    {
        try
        {
            var userRole = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            IEnumerable<Category> categories;

            // Get categories base on user role
            if (userRole == StaticUserRoles.Admin)
            {
                categories =
                    await _unitOfWork.CategoryRepository.GetAllAsync();
            }
            else
            {
                categories =
                    await _unitOfWork.CategoryRepository.GetAllAsync(x =>
                        x.Status <= StaticStatus.Category.Activated);
            }

            if (categories.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "There are no category",
                    Result = null,
                    IsSuccess = true,
                    StatusCode = 200
                };
            }

            var listCategory = categories.ToList();

            #region Refactor List of Category

            // Step 1: Create a dictionary for quick lookup by Id
            var categoriesDictionary = listCategory.ToDictionary(x => x.Id, x => x);
            // Step 2: Initialize the list for root categories
            var rootCategories = new List<Category>();
            // Step 3: Iterate over each category in the enumerable
            foreach (var category in listCategory)
            {
                // Step 4: Check if the category has a parent
                if (category.ParentId.HasValue)
                {
                    // Step 5: Try to find the parent category in the dictionary
                    if (categoriesDictionary.TryGetValue(category.ParentId.Value, out var parentCategory))
                    {
                        // Add the current category to the parent's subcategories list
                        parentCategory.SubCategories.Add(category);
                    }
                }
                else
                {
                    // Step 6: If no parent, add to the root categories list
                    rootCategories.Add(category);
                }
            }

            #endregion Refactor List of Category


            #region Query Parameters

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "name":
                    {
                        rootCategories = rootCategories.Where(x =>
                            x.Name.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "description":
                    {
                        rootCategories = rootCategories.Where(x =>
                            x.Name.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            // Sort Query
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "name":
                    {
                        rootCategories = isAscending == true
                            ? [.. rootCategories.OrderBy(x => x.Name)]
                            : [.. rootCategories.OrderByDescending(x => x.Name)];
                        break;
                    }
                    case "description":
                    {
                        rootCategories = isAscending == true
                            ? [.. rootCategories.OrderBy(x => x.Description)]
                            : [.. rootCategories.OrderByDescending(x => x.Description)];
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            // Pagination
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                rootCategories = rootCategories.Skip(skipResult).Take(pageSize).ToList();
            }

            #endregion Query Parameters

            // Map to DTO
            object rootCategoriesDto;
            if (userRole == StaticUserRoles.Admin)
            {
                rootCategoriesDto = _mapper.Map<List<AdminCategoryDTO>>(rootCategories);
            }
            else
            {
                rootCategoriesDto = _mapper.Map<List<CategoryDTO>>(rootCategories);
            }

            return new ResponseDTO()
            {
                Message = "Get all category successfully",
                Result = rootCategoriesDto,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> Search
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize)
    {
        try
        {
            var userRole = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            IEnumerable<Category> categories;

            // Get categories base on user role
            if (userRole == StaticUserRoles.Admin)
            {
                categories =
                    await _unitOfWork.CategoryRepository.GetAllAsync(includeProperties: "ParentCategory");
            }
            else
            {
                categories =
                    await _unitOfWork.CategoryRepository.GetAllAsync(x =>
                        x.Status <= StaticStatus.Category.Activated, includeProperties: "ParentCategory");
            }

            if (categories.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "There are no category",
                    Result = null,
                    IsSuccess = true,
                    StatusCode = 200
                };
            }

            var listCategory = categories.ToList();

            #region Query Parameters

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "name":
                    {
                        listCategory = listCategory.Where(x =>
                            x.Name.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "description":
                    {
                        listCategory = listCategory.Where(x =>
                            x.Name.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            // Sort Query
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "name":
                    {
                        listCategory = isAscending == true
                            ? [.. listCategory.OrderBy(x => x.Name)]
                            : [.. listCategory.OrderByDescending(x => x.Name)];
                        break;
                    }
                    case "description":
                    {
                        listCategory = isAscending == true
                            ? [.. listCategory.OrderBy(x => x.Description)]
                            : [.. listCategory.OrderByDescending(x => x.Description)];
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            // Pagination
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                listCategory = listCategory.Skip(skipResult).Take(pageSize).ToList();
            }

            #endregion Query Parameters

            object listCategoryDto;
            if (userRole == StaticUserRoles.Admin)
            {
                listCategoryDto = _mapper.Map<List<AdminCategoryDTO>>(listCategory);
            }
            else
            {
                listCategoryDto = _mapper.Map<List<CategoryDTO>>(listCategory);
            }


            return new ResponseDTO()
            {
                Message = "Get all category successfully",
                Result = listCategoryDto,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> GetSubCategory(Guid id)
    {
        try
        {
            var categories =
                await _unitOfWork.CategoryRepository.GetAllAsync(filter: x => x.ParentId == id);

            if (categories is null)
            {
                return new ResponseDTO()
                {
                    Message = "Category was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                };
            }

            var categoryDto = _mapper.Map<List<CategoryDTO>>(categories);

            return new ResponseDTO()
            {
                Message = "Get sub category successfully",
                Result = categoryDto,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> GetParentCategory(Guid id)
    {
        try
        {
            var category =
                await _unitOfWork.CategoryRepository.GetAsync(filter: x => x.Id == id);

            if (category is null)
            {
                return new ResponseDTO()
                {
                    Message = "Category was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                };
            }

            var parentCategory = await _unitOfWork.CategoryRepository.GetAsync(filter: x => x.Id == category.ParentId);

            if (parentCategory is null)
            {
                return new ResponseDTO()
                {
                    Message = "Parent of the category was not exist",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                };
            }

            var parentCategoryDto = _mapper.Map<CategoryDTO>(parentCategory);

            return new ResponseDTO()
            {
                Message = "Get parent category successfully",
                Result = parentCategoryDto,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> Get(ClaimsPrincipal User, Guid id)
    {
        try
        {
            var category =
                await _unitOfWork.CategoryRepository.GetAsync(filter: x => x.Id == id,
                    includeProperties: "ParentCategory");

            if (category is null)
            {
                return new ResponseDTO()
                {
                    Message = "Category was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                };
            }

            var userRole = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            // Map to DTO
            object rootCategoryDto;
            if (userRole == StaticUserRoles.Admin)
            {
                rootCategoryDto = _mapper.Map<AdminCategoryDTO>(category);
            }
            else
            {
                rootCategoryDto = _mapper.Map<CategoryDTO>(category);
            }

            return new ResponseDTO()
            {
                Message = "Get all category successfully",
                Result = rootCategoryDto,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// Create Category
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    public async Task<ResponseDTO> CreateCategory(ClaimsPrincipal User, CreateCategoryDTO createCategoryDto)
    {
        try
        {
            Guid guidOutput;
            var isGuid = Guid.TryParse(createCategoryDto.ParentId, out guidOutput);
            // Map DTO sang entity Category
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
                ParentId = isGuid ? guidOutput : null,
                CreatedTime = DateTime.Now,
                UpdatedTime = null,
                CreatedBy = User.Identity.Name,
                UpdatedBy = "",
                Status = 0,
            };

            // Kiểm tra xem đây có phải là danh mục đầu tiên không
            var existingCategories = await _unitOfWork.CategoryRepository.GetAllAsync();
            if (existingCategories == null || !existingCategories.Any())
            {
                // Thêm danh mục vào cơ sở dữ liệu
                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.SaveAsync();
                return new ResponseDTO
                {
                    Message = "Category created successfully",
                    Result = category,
                    IsSuccess = true,
                    StatusCode = 200,
                };
            }

            // 
            else if (category.ParentId == null)
            {
                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO
                {
                    Message = "Category created successfully",
                    Result = category,
                    IsSuccess = true,
                    StatusCode = 200,
                };
            }

            // Thêm danh mục vào cơ sở dữ liệu
            await _unitOfWork.CategoryRepository.AddAsync(category);
            var save = await _unitOfWork.SaveAsync();
            if (save <= 0)
            {
                return new ResponseDTO
                {
                    Message = "",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            return new ResponseDTO
            {
                Message = "Category created successfully",
                Result = category,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// Update Category
    /// </summary>
    /// <param name="updateCategoryDTO"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> Update(ClaimsPrincipal User, UpdateCategoryDTO updateCategoryDTO)
    {
        try
        {
            // kiểm tra xem có ID trong database không
            var categoryToUpdate = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == updateCategoryDTO.Id);

            // kiểm tra xem có null không
            if (categoryToUpdate == null)
            {
                return new ResponseDTO
                {
                    Message = "Category not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            // cập nhật thông tin danh mục
            categoryToUpdate.Name = updateCategoryDTO.Name;
            categoryToUpdate.Description = updateCategoryDTO.Description;
            categoryToUpdate.ParentId = !string.IsNullOrEmpty(updateCategoryDTO.ParentId)
                ? Guid.Parse(updateCategoryDTO.ParentId)
                : (Guid?)null;
            categoryToUpdate.UpdatedTime = DateTime.Now;
            categoryToUpdate.UpdatedBy = User.Identity.Name;
            categoryToUpdate.Status = updateCategoryDTO.Status;


            // thay đổi dữ liệu
            _unitOfWork.CategoryRepository.Update(categoryToUpdate);

            // lưu thay đổi vào cơ sở dữ liệu
            var save = await _unitOfWork.SaveAsync();
            if (save <= 0)
            {
                return new ResponseDTO
                {
                    Message = "Failed to update category",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            return new ResponseDTO
            {
                Message = "Category updated successfully",
                Result = categoryToUpdate,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// Delete Category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> Delete(ClaimsPrincipal User, Guid id)
    {
        try
        {
            // Lấy danh mục từ cơ sở dữ liệu dựa trên Id
            var category = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == id);

            // kiểm tra xem danh mục có tồn tại không
            if (category == null)
            {
                return new ResponseDTO
                {
                    Message = "Category not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            // kiểm tra các danh mục con có ParentId là danh mục đang bị xóa
            var subCategories = await _unitOfWork.CategoryRepository.GetAllAsync(c => c.ParentId == id);

            // Nếu có danh mục con, không cho phép xóa và trả về danh sách các danh mục con
            if (subCategories.Any())
            {
                return new ResponseDTO
                {
                    Message = "Category cannot be deleted because it has subcategories.",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = subCategories.Select(x => new { x.Id, x.Name }).ToList()
                };
            }

            // chuyển status về 2 chứ không xóa dữ liệu
            category.Status = 2;
            category.UpdatedTime = DateTime.Now;
            category.UpdatedBy = User.Identity.Name;

            // cập nhật và lưu thay đổi trong cơ sở dữ liệu
            _unitOfWork.CategoryRepository.Update(category);
            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult <= 0)
            {
                return new ResponseDTO
                {
                    Message = "Failed to delete category",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            return new ResponseDTO
            {
                Message = "Category deleted successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = category.Id
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }
}