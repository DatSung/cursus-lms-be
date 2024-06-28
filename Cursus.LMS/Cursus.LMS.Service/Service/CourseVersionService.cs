using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CourseVersionService : ICourseVersionService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseVersionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ResponseDTO> GetCourseVersions(ClaimsPrincipal User, string? filterOn, string? filterQuery, string? sortBy, bool? isAscending,
        int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetCourseVersion(ClaimsPrincipal User, Guid courseId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateCourseVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RemoveCourseVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> EditCourseVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> AcceptCourseVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RejectCourseVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetCourseVersionsComments(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetCourseVersionComment(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateCourseVersionComment(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> EditCourseVersionComment(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RemoveCourseVersionComment(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }
}