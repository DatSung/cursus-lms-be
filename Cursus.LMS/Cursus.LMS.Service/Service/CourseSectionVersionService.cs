using System.Security.Claims;
using Azure;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using DocumentFormat.OpenXml.Office2010.Excel;
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
                    cloneCourseSectionVersionDto.OldCourseVersionId,
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

            var cloneSectionsDetailsVersionsDto = new List<CloneSectionsDetailsVersionDTO>();

            foreach (var courseSectionVersion in courseSectionVersions)
            {
                var cloneSectionsDetailsVersionDto = new CloneSectionsDetailsVersionDTO();

                cloneSectionsDetailsVersionDto.OldCourseSectionVersionId = courseSectionVersion.Id;
                courseSectionVersion.Id = Guid.NewGuid();
                cloneSectionsDetailsVersionDto.NewCourseSectionVersionId = courseSectionVersion.Id;

                courseSectionVersion.CourseVersionId = cloneCourseSectionVersionDto.NewCourseVersionId;

                cloneSectionsDetailsVersionsDto.Add(cloneSectionsDetailsVersionDto);
            }

            await _unitOfWork.CourseSectionVersionRepository.AddRangeAsync(courseSectionVersions);
            await _unitOfWork.SaveAsync();

            // Clone section details version
            foreach (var cloneSectionsDetailsVersionDto in cloneSectionsDetailsVersionsDto)
            {
                var responseDto =
                    await _sectionDetailsVersionService.CloneSectionsDetailsVersion
                    (
                        User,
                        new CloneSectionsDetailsVersionDTO()
                        {
                            OldCourseSectionVersionId = cloneSectionsDetailsVersionDto.OldCourseSectionVersionId,
                            NewCourseSectionVersionId = cloneSectionsDetailsVersionDto.NewCourseSectionVersionId,
                        }
                    );
                if (responseDto.StatusCode == 500)
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

    public async Task<ResponseDTO> GetCourseSections
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

    public async Task<ResponseDTO> GetCourseSection
    (
        ClaimsPrincipal User,
        Guid CourseVersionId
    )
    {
        //try
        //{
        //    var courseVersionId =
        //        await _unitOfWork.CourseVersionRepository.GetAsync(c =>
        //            c.Id == CourseVersionId);
        //    if (courseVersionId == null)
        //    {
        //        return new ResponseDTO()
        //        {
        //            Message = "CourseVersionId Invalid",
        //            Result = null,
        //            IsSuccess = false,
        //            StatusCode = 400
        //        };
        //    }

        //    var courseVersionDto = _mapper.Map<GetCourseVersionDTO>(courseVersion);

        //    return new ResponseDTO()
        //    {
        //        Result = courseVersionDto,
        //        Message = "Get course version successfully",
        //        IsSuccess = true,
        //        StatusCode = 200
        //    };
        //}
        //catch (Exception e)
        //{
        //    return new ResponseDTO()
        //    {
        //        Result = null,
        //        Message = e.Message,
        //        IsSuccess = true,
        //        StatusCode = 200
        //    };
        //}
        return null;
    }

    public async Task<ResponseDTO> CreateCourseSection
    (
        ClaimsPrincipal User, 
        CreateCourseSectionVersionDTO createCourseSectionVersionDTO
    )
    {
        try
        {
            var courseVersionId =
                await _unitOfWork.CourseVersionRepository.GetAsync(c =>
                    c.Id == createCourseSectionVersionDTO.CourseVersionId);
            if (courseVersionId == null)
            {
                return new ResponseDTO()
                {
                    Message = "CourseVersionId Invalid",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }


            var courseSectionVersion = new CourseSectionVersion()
            {
                
                Id = Guid.NewGuid(),
                CourseVersionId = createCourseSectionVersionDTO.CourseVersionId,
                Title = createCourseSectionVersionDTO.Title,
                Description = createCourseSectionVersionDTO.Description,
                CurrentStatus = 0

            };

            // Thêm courseSectionVersion vào cơ sở dữ liệu
            await _unitOfWork.CourseSectionVersionRepository.AddAsync(courseSectionVersion);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Result = null,
                Message = "Create new course section version successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e) 
        {
            return new ResponseDTO()
            {
                Result = null,
                IsSuccess = false,
                Message = e.Message,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> EditCourseSection
    (
        ClaimsPrincipal User,
        EditCourseSectionVersionDTO editCourseSectionVersionDTO
    )
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseSectionVersionId =
                await _unitOfWork.CourseSectionVersionRepository.GetAsync(c =>
                    c.Id == editCourseSectionVersionDTO.CourseSectionVersionId);
            if (courseSectionVersionId == null)
            {
                return new ResponseDTO()
                {
                    Message = "courseSectionVersionId Invalid",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            //var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            //var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            //update comment
            courseSectionVersionId.Title = editCourseSectionVersionDTO.Title;
            courseSectionVersionId.Description = editCourseSectionVersionDTO.Description;
            courseSectionVersionId.CurrentStatus = 1;

            _unitOfWork.CourseSectionVersionRepository.Update(courseSectionVersionId);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "CourseSectionVersion Edited successfully",
                Result = null,
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
        }
    }

    public async Task<ResponseDTO> RemoveCourseSection
    (
        ClaimsPrincipal User,
        RemoveCourseSectionVersionDTO removeCourseSectionVersionDTO
    )
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseSectionVersionId =
                await _unitOfWork.CourseSectionVersionRepository.GetAsync(c =>
                    c.Id == removeCourseSectionVersionDTO.CourseSectionVersionId);
            if (courseSectionVersionId == null)
            {
                return new ResponseDTO()
                {
                    Message = "courseSectionVersionId Invalid",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            //var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            //var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            
            courseSectionVersionId.CurrentStatus = 2;

            _unitOfWork.CourseSectionVersionRepository.Update(courseSectionVersionId);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "CourseSectionVersion Removed successfully",
                Result = null,
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
        }
    }
}