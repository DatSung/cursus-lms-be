using System.Security.Claims;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICategoryService
{
    Task<ResponseDTO> GetAll
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> Search
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetSubCategory(Guid id);
    Task<ResponseDTO> GetParentCategory(Guid id);

    Task<ResponseDTO> Get(Guid id);
    Task<ResponseDTO> AddAsync(ClaimsPrincipal User, CreateCategoryDTO createCategoryDto);
    Task<ResponseDTO> Update(ClaimsPrincipal User, UpdateCategoryDTO updateCategoryDto);
    Task<ResponseDTO> Delete(ClaimsPrincipal User, Guid id);
}