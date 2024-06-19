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
                    await _unitOfWork.CategoryRepository.GetAllAsync(includeProperties:"ParentCategory");
            }
            else
            {
                categories =
                    await _unitOfWork.CategoryRepository.GetAllAsync(x =>
                        x.Status <= StaticStatus.Category.Activated, includeProperties:"ParentCategory");
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
    public async Task<ResponseDTO> Get(Guid id)
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

            var categoryDto = _mapper.Map<CategoryDTO>(category);

            return new ResponseDTO()
            {
                Message = "Get all category successfully",
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

    /// <summary>
    /// Create Category
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    public async Task<ResponseDTO> AddAsync(CreateCategoryDTO createCategoryDto)
    {
        /*try
        {
            var category = _mapper.Map<Category>(createCategoryDto);
        
            // Kiểm tra xem ParentId có tồn tại trong cơ sở dữ liệu không
            if (category.ParentId.HasValue)
            {
                category.ParentId = createCategoryDto.ParentId;
                category.Status = 1;
                    
                //category.ParentId = null;
            }

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Category added successfully",
                Result = category,
                IsSuccess = true,
                StatusCode = 200,   
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
        }*/
        try
        {
            // Map DTO sang entity Category
            var category = _mapper.Map<Category>(createCategoryDto);

            // Kiểm tra xem đây có phải là danh mục đầu tiên không
            var existingCategories = await _unitOfWork.CategoryRepository.GetAllAsync();
            if (existingCategories == null || !existingCategories.Any())
            {
                category.ParentId = null;
                category.Status = 1;

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

            // Kiểm tra xem ParentId là null hoặc tồn tại trong cơ sở dữ liệu
            else if (category.ParentId != null)
            {
                var parentCategory = await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(category.ParentId.Value);
                if (parentCategory == null)
                {
                    return new ResponseDTO
                    {
                        Message = "ParentId Invalid",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 400
                    };
                }
                category.Status = 1;

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
            }
            return new ResponseDTO
            {
                Message = "Category created successfully",
                Result = null,
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
    public async Task<ResponseDTO> Update(UpdateCategoryDTO updateCategoryDTO)
    {
        /*try
        {
            // Tìm kiếm danh mục hiện có ID giống ID mình vừa nhập không
            var update =
                await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(updateCategoryDTO.Id);

            if (update == null)
            {

                return new ResponseDTO
                {
                    Message = "Category not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            // Cập nhật các thuộc tính của danh mục
            _mapper.Map(updateCategoryDTO, update);

            // Lưu thay đổi vào cơ sở dữ liệu
            _unitOfWork.CategoryRepository.Update(update);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Category updated successfully",
                Result = update,
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
        }*/

        try
        {
            // Step 1: Retrieve the existing category by ID
            var categoryToUpdate = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == updateCategoryDTO.Id);

            // Step 2: Check if the category exists
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

            // Step 3 & 4: Map updated values and update in database context
            _mapper.Map(updateCategoryDTO, categoryToUpdate);
            _unitOfWork.CategoryRepository.Update(categoryToUpdate);

            // Step 5: Save changes to the database
            await _unitOfWork.SaveAsync();

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

    public async Task<ResponseDTO> Delete(Guid id)
    {
        var category =
                await _unitOfWork.CategoryRepository.GetAsync(filter: x => x.Id == id);
        if (category == null)
        {
            return new ResponseDTO()
            {
                Message = "Category was not found",
                IsSuccess = false,
                StatusCode = 404,
                Result = null,
            };
        }

        //chuyển status về 0 chứ không xóa dữ liệu
        category.Status = 2;
        _unitOfWork.CategoryRepository.Update(category);

        //tìm danh sách con của category bị chuyển đổi status về 0
        /*var childCategories = await _unitOfWork.CategoryRepository.GetAsync(filter: x => x.ParentId == id);
        if (childCategories != null)
        {
            foreach (var childCategory in childCategories)
            {
                childCategory.ParentId = null;
                _unitOfWork.CategoryRepository.Update(childCategory);
            }
        }*/

        await _unitOfWork.SaveAsync();

        return new ResponseDTO()
        {
            Message = "Category deleted successfully",
            IsSuccess = true,
            StatusCode = 200,
            Result = category.Id,
        };
    }

}