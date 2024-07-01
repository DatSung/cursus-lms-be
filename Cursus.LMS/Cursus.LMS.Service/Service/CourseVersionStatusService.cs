using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CourseVersionStatusService : ICourseVersionStatusService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseVersionStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ResponseDTO> GetCourseVersionsStatus
    (
        ClaimsPrincipal User,
        Guid? courseVersionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> GetCourseVersionStatus
    (
        ClaimsPrincipal User,
        Guid courseVersionStatusId
    )
    {
        try
        {
            var courseVersion =
                await _unitOfWork.CourseVersionStatusRepository.GetCourseVersionStatusByIdAsync(courseVersionStatusId);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course version status was not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404,
                };
            }

            var getCourseVersionStatusDto = _mapper.Map<GetCourseVersionStatusDTO>(courseVersion);

            return new ResponseDTO()
            {
                Message = "Get course version status successfully",
                Result = getCourseVersionStatusDto,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }

    public async Task<ResponseDTO> CreateCourseVersionStatus
    (
        ClaimsPrincipal User,
        CreateCourseVersionStatusDTO createCourseVersionStatusDto
    )
    {
        try
        {
            var courseVersionStatus = new CourseVersionStatus()
            {
                Id = new Guid(),
                CreateTime = DateTime.UtcNow,
                Status = createCourseVersionStatusDto.Status,
                CourseVersionId = createCourseVersionStatusDto.CourseVersionId
            };

            await _unitOfWork.CourseVersionStatusRepository.AddAsync(courseVersionStatus);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Create course version status successfully",
                Result = courseVersionStatus.Id,
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
                IsSuccess = true,
                StatusCode = 500
            };
        }
    }
}