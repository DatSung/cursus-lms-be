using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CourseSectionVersionService : ICourseSectionVersionService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseSectionVersionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ResponseDTO> GetCourseSections
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetCourseSection(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateCourseSection(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> EditCourseSection(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RemoveCourseSection(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }
}