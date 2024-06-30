using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class CourseSectionVersionService : ICourseSectionVersionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISectionDetailsVersionService _sectionDetailsVersionService;

    public CourseSectionVersionService
    (
        IUnitOfWork unitOfWork,
        ISectionDetailsVersionService sectionDetailsVersionService
    )
    {
        _unitOfWork = unitOfWork;
        _sectionDetailsVersionService = sectionDetailsVersionService;
    }

    public async Task<ResponseDTO> CloneCourseSectionVersion
    (
        ClaimsPrincipal User,
        CloneCourseSectionVersionDTO cloneCourseSectionVersionDto
    )
    {
        try
        {
            var courseSectionVersions =
                await _unitOfWork.CourseSectionVersionRepository.GetCourseSectionVersionsOfCourseVersionAsync
                (
                    cloneCourseSectionVersionDto.CourseVersionId,
                    asNoTracking: true
                );

            if (courseSectionVersions.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Section of course version was not found"
                };
            }

            foreach (var courseSectionVersion in courseSectionVersions)
            {
                courseSectionVersion.Id = new Guid();
            }

            await _unitOfWork.CourseSectionVersionRepository.AddRangeAsync(courseSectionVersions);
            await _unitOfWork.SaveAsync();

            // Clone section details version
            foreach (var courseSectionVersion in courseSectionVersions)
            {
                var responseDto =
                    await _sectionDetailsVersionService.CloneSectionsDetailsVersion
                    (
                        User,
                        new CloneSectionsDetailsVersionDTO()
                        {
                            CourseSectionVersionId = courseSectionVersion.Id
                        }
                    );
                if (responseDto.IsSuccess is false)
                {
                    return responseDto;
                }
            }

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Clone course section of course version successfully",
                Result = null
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 500,
                Message = e.Message,
                Result = null
            };
        }
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