﻿using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CourseVersionService : ICourseVersionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseService _courseService;
    private IMapper _mapper;

    public CourseVersionService(IUnitOfWork unitOfWork, ICourseService courseService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _courseService = courseService;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetCourseVersions
    (
        ClaimsPrincipal User,
        Guid? courseId,
        Guid? instructorId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    )
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> GetCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetCourseVersionById(courseVersionId);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Result = "",
                    Message = "Course version was not found",
                    IsSuccess = true,
                    StatusCode = 200
                };
            }

            var courseVersionDto = _mapper.Map<GetCourseVersionDTO>(courseVersion);

            return new ResponseDTO()
            {
                Result = courseVersionDto,
                Message = "Get course version successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Result = null,
                Message = e.Message,
                IsSuccess = true,
                StatusCode = 200
            };
        }
    }

    public async Task<ResponseDTO> CreateNewCourseAndCourseVersion
    (
        ClaimsPrincipal User,
        CreateNewCourseAndVersionDTO createNewCourseAndVersionDto
    )
    {
        try
        {
            var response = await _courseService.CreateFrameCourse(User);
            if (response.IsSuccess == false)
            {
                return response;
            }

            var course = (Course)response.Result!;

            var courseVersion = new CourseVersion()
            {
                Id = new Guid(),
                CourseId = course.Id,
                Title = createNewCourseAndVersionDto.Title,
                Code = createNewCourseAndVersionDto.Code,
                Description = createNewCourseAndVersionDto.Description,
                LearningTime = createNewCourseAndVersionDto.LearningTime,
                Price = createNewCourseAndVersionDto.Price,
                OldPrice = 0,
                CourseImgUrl = createNewCourseAndVersionDto.CourseImgUrl,
                InstructorId = course.InstructorId,
                CategoryId = createNewCourseAndVersionDto.CategoryId,
                LevelId = createNewCourseAndVersionDto.LevelId,
                CurrentStatus = 0
            };

            await _unitOfWork.CourseVersionRepository.AddAsync(courseVersion);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Result = courseVersion.Id,
                Message = "Create new course and course version successfully",
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

    public async Task<ResponseDTO> CloneNewCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var courseVersion =
                await _unitOfWork.CourseVersionRepository.GetCourseVersionsAsNoTracking(courseVersionId);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "Course version does not exist",
                    StatusCode = 404,
                };
            }

            await _unitOfWork.CourseVersionRepository.AddAsync(courseVersion);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Result = null,
                IsSuccess = true,
                Message = "Clone new course version successfully",
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