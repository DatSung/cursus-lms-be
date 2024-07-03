using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> CreateFrameCourse(ClaimsPrincipal User)
    {
        try
        {
            // Get instructorId by userId
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var instructor = await _unitOfWork.InstructorRepository.GetAsync
            (
                filter: x => x.UserId == userId,
                includeProperties: "ApplicationUser"
            );

            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor does not exist",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (instructor.IsAccepted == false)
            {
                return new ResponseDTO()
                {
                    Message = "Permission to create course was not found",
                    IsSuccess = true,
                    StatusCode = 403,
                    Result = null
                };
            }

            // Create an empty course
            var course = new Course()
            {
                Id = Guid.NewGuid(),
                Code = null,
                InstructorId = instructor?.InstructorId,
                Status = 0,
                Version = 1,
                StudentSlots = 0,
                TotalRate = 0,
                ActivatedBy = null,
                DeactivatedBy = null,
                ActivatedTime = null,
                DeactivatedTime = null,
                MergedTime = null,
                MergedBy = null,
                CreatedBy = instructor?.ApplicationUser.Email,
                CreatedTime = DateTime.UtcNow
            };

            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Create empty course successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = course
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = true
            };
        }
    }

    public async Task<ResponseDTO> GetCourses
    (
        ClaimsPrincipal User,
        Guid? instructorId,
        string? filterOn,
        string? filterQuery,
        double? fromPrice,
        double? toPrice,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 1,
        int pageSize = 5
    )
    {
        try
        {
            var courses = new List<Course>();
            if (string.IsNullOrEmpty(instructorId.ToString()))
            {
                courses = _unitOfWork.CourseRepository
                    .GetAllAsync()
                    .GetAwaiter()
                    .GetResult()
                    .ToList();
            }
            else
            {
                courses = _unitOfWork.CourseRepository
                    .GetAllAsync(x => x.Id == instructorId)
                    .GetAwaiter()
                    .GetResult()
                    .ToList();
            }

            var courseVersions = new List<CourseVersion>();

            foreach (var course in courses)
            {
                var courseVersion = await _unitOfWork.CourseVersionRepository
                    .GetAsync(x => x.Id == course.CourseVersionId);
                if (courseVersion is not null)
                {
                    courseVersions.Add(courseVersion);
                }
            }


            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "title":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.Title.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "code":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.Code.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "description":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.Description.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    case "status":
                    {
                        courseVersions = courseVersions.Where(x =>
                            x.CurrentStatus == int.Parse(filterQuery.Trim())).ToList();
                        break;
                    }
                }
            }

            // Price range
            if (toPrice is not null && fromPrice is not null)
            {
                if (toPrice >= 0)
                {
                    courseVersions = fromPrice >= toPrice
                        ? courseVersions.Where(x => x.Price >= toPrice && x.Price <= fromPrice).ToList()
                        : courseVersions.Where(x => x.Price >= toPrice).ToList();
                }
            }

            // Sort Query
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "title":
                    {
                        courseVersions = isAscending == true
                            ? [.. courseVersions.OrderBy(x => x.Title)]
                            : [.. courseVersions.OrderByDescending(x => x.Title)];
                        break;
                    }
                    case "code":
                    {
                        courseVersions = isAscending == true
                            ? [.. courseVersions.OrderBy(x => x.Code)]
                            : [.. courseVersions.OrderByDescending(x => x.Code)];
                        break;
                    }
                    case "description":
                    {
                        courseVersions = isAscending == true
                            ? [.. courseVersions.OrderBy(x => x.Description)]
                            : [.. courseVersions.OrderByDescending(x => x.Description)];
                        break;
                    }
                    case "price":
                    {
                        courseVersions = isAscending == true
                            ? [.. courseVersions.OrderBy(x => x.Price)]
                            : [.. courseVersions.OrderByDescending(x => x.Price)];
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
                courseVersions = courseVersions.Skip(skipResult).Take(pageSize).ToList();
            }

            var courseVersionDto = _mapper.Map<List<GetCourseVersionDTO>>(courseVersions);

            return new ResponseDTO()
            {
                Result = courseVersionDto,
                Message = "Get courses successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> GetCourse(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course was not found"
                };
            }

            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == course.CourseVersionId);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course have no content"
                };
            }

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = null,
                Message = "Get course successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 500,
                Result = null,
                Message = e.Message
            };
        }
    }

    public async Task<ResponseDTO> GetCourseInfo(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course was not found"
                };
            }

            var getCourseInfoDto = _mapper.Map<GetCourseInfoDTO>(course);

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = getCourseInfoDto,
                Message = "Get course information successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> ActivateCourse(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course was not found"
                };
            }

            course.Status = StaticCourseStatus.Activated;

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = null,
                Message = "Activated course successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> DeactivateCourse(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Course was not found"
                };
            }

            course.Status = StaticCourseStatus.Deactivated;

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = null,
                Message = "Deactivated course successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }
}