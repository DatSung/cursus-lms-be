using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Hangfire;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class CourseVersionService : ICourseVersionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseService _courseService;
    private readonly ICourseSectionVersionService _courseSectionVersionService;
    private readonly ICourseVersionStatusService _courseVersionStatusService;
    private readonly IFirebaseService _firebaseService;
    private IMapper _mapper;

    public CourseVersionService
    (
        IUnitOfWork unitOfWork,
        ICourseService courseService,
        IMapper mapper,
        ICourseVersionStatusService courseVersionStatusService,
        ICourseSectionVersionService courseSectionVersionService, IFirebaseService firebaseService)
    {
        _unitOfWork = unitOfWork;
        _courseService = courseService;
        _mapper = mapper;
        _courseVersionStatusService = courseVersionStatusService;
        _courseSectionVersionService = courseSectionVersionService;
        _firebaseService = firebaseService;
    }

    public async Task<ResponseDTO> GetCourseVersions
    (
        ClaimsPrincipal User,
        Guid? courseId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    )
    {
        try
        {
            if (string.IsNullOrEmpty(courseId.ToString()))
            {
                return new ResponseDTO()
                {
                    Message = "Course id is require",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var courseVersions = _unitOfWork.CourseVersionRepository
                .GetAllAsync(
                    filter: x => x.CourseId == courseId,
                    includeProperties: "Category,Level"
                )
                .GetAwaiter().GetResult().ToList();

            if (courseVersions.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "There are no course versions",
                    Result = courseVersions,
                    IsSuccess = false,
                    StatusCode = 404
                };
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

            if (courseVersions.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "There are no course version",
                    Result = courseVersions,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var courseVersionDto = _mapper.Map<List<GetCourseVersionDTO>>(courseVersions);

            return new ResponseDTO()
            {
                Result = courseVersionDto,
                Message = "Get course versions successfully",
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
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> GetCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var courseVersion =
                await _unitOfWork.CourseVersionRepository.GetAsync
                (
                    filter: x => x.Id == courseVersionId,
                    includeProperties: "Category,Level"
                );

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
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> CreateCourseAndVersion
    (
        ClaimsPrincipal User,
        CreateNewCourseAndVersionDTO createNewCourseAndVersionDto
    )
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == userId);

            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (instructor.IsAccepted is false or null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor was not allow to create course",
                    IsSuccess = false,
                    StatusCode = 403,
                    Result = null
                };
            }

            if (instructor.StripeAccountId.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "Instructor need to create stripe account",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            var courseVersionId = Guid.NewGuid();
            var response = await _courseService.CreateFrameCourse(User, courseVersionId);
            if (response.IsSuccess == false)
            {
                return response;
            }

            var course = (Course)response.Result!;

            var courseVersion = new CourseVersion()
            {
                Id = courseVersionId,
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
                CurrentStatus = 0,
                Version = 1,
                CreatedTime = DateTime.UtcNow,
            };

            await _unitOfWork.CourseVersionRepository.AddAsync(courseVersion);
            await _unitOfWork.SaveAsync();

            // Save status history of version
            var responseDto = await _courseVersionStatusService.CreateCourseVersionStatus
            (
                User,
                new CreateCourseVersionStatusDTO()
                {
                    CourseVersionId = courseVersion.Id,
                    Status = StaticCourseVersionStatus.New
                }
            );

            if (responseDto.IsSuccess is false)
            {
                return responseDto;
            }

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

    public async Task<ResponseDTO> CloneCourseVersion
    (
        ClaimsPrincipal User,
        CloneCourseVersionDTO cloneCourseVersionDto
    )
    {
        try
        {
            // Clone course version
            var courseVersion =
                await _unitOfWork.CourseVersionRepository.GetCourseVersionAsync
                (
                    cloneCourseVersionDto.CourseVersionId,
                    asNoTracking: true
                );

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

            // Create newCourseVersionId and save OldCourseVersionId to create and clone
            var cloneCourseSectionVersionDto = new CloneCourseSectionVersionDTO()
            {
                NewCourseVersionId = Guid.NewGuid(),
                OldCourseVersionId = courseVersion.Id
            };

            courseVersion.Id = cloneCourseSectionVersionDto.NewCourseVersionId;
            courseVersion.CurrentStatus = StaticCourseVersionStatus.New;
            courseVersion.Version =
                await _unitOfWork.CourseVersionRepository.GetTotalCourseVersionsAsync(courseVersion.CourseId) + 1;

            await _unitOfWork.CourseVersionRepository.AddAsync(courseVersion);
            await _unitOfWork.SaveAsync();

            // Clone course section versions
            var responseDto =
                await _courseSectionVersionService.CloneCourseSectionVersion
                (
                    User,
                    cloneCourseSectionVersionDto
                );
            if (responseDto.StatusCode == 500)
            {
                return responseDto;
            }

            // Save status history of version
            responseDto = await _courseVersionStatusService.CreateCourseVersionStatus
            (
                User,
                new CreateCourseVersionStatusDTO()
                {
                    CourseVersionId = courseVersion.Id,
                    Status = StaticCourseVersionStatus.New
                }
            );

            if (responseDto.IsSuccess is false)
            {
                return responseDto;
            }

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

    public async Task<ResponseDTO> EditCourseVersion(ClaimsPrincipal User, EditCourseVersionDTO editCourseVersionDto)
    {
        try
        {
            var courseVersion =
                await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == editCourseVersionDto.Id);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course version was not found",
                    StatusCode = 404,
                    IsSuccess = false,
                    Result = null
                };
            }

            switch (courseVersion.CurrentStatus)
            {
                case StaticCourseVersionStatus.New:
                {
                    break;
                }
                case StaticCourseVersionStatus.Submitted:
                {
                    return new ResponseDTO()
                    {
                        Message = "This course version was submitted",
                        IsSuccess = false,
                        StatusCode = 401,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Accepted:
                {
                    break;
                }
                case StaticCourseVersionStatus.Rejected:
                {
                    break;
                }
                case StaticCourseVersionStatus.Merged:
                {
                    return new ResponseDTO()
                    {
                        Message = "This course version was merged",
                        IsSuccess = false,
                        StatusCode = 401,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Removed:
                {
                    return new ResponseDTO()
                    {
                        Message = "This course version was removed",
                        IsSuccess = false,
                        StatusCode = 401,
                        Result = null
                    };
                }
            }

            courseVersion.CategoryId = editCourseVersionDto.CategoryId;
            courseVersion.LevelId = editCourseVersionDto.LevelId;
            courseVersion.Title = editCourseVersionDto.Title;
            courseVersion.Code = editCourseVersionDto.Code;
            courseVersion.Description = editCourseVersionDto.Description;
            courseVersion.LearningTime = editCourseVersionDto.LearningTime;
            courseVersion.Price = editCourseVersionDto.Price;
            courseVersion.CourseImgUrl = editCourseVersionDto.CourseImgUrl;

            _unitOfWork.CourseVersionRepository.Update(courseVersion);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Update course version successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
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

    public async Task<ResponseDTO> RemoveCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "Course version was not found",
                    StatusCode = 404
                };
            }

            switch (courseVersion.CurrentStatus)
            {
                case StaticCourseVersionStatus.Submitted:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been submitted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Merged:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Removed:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been removed",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                default:
                {
                    courseVersion.CurrentStatus = StaticCourseVersionStatus.Removed;
                    break;
                }
            }

            _unitOfWork.CourseVersionRepository.Update(courseVersion);

            var responseDto = await _courseVersionStatusService.CreateCourseVersionStatus
            (
                User,
                new CreateCourseVersionStatusDTO()
                {
                    CourseVersionId = courseVersion.Id,
                    Status = StaticCourseVersionStatus.Removed
                }
            );

            if (responseDto.StatusCode == 500)
            {
                return responseDto;
            }

            return new ResponseDTO()
            {
                Result = null,
                IsSuccess = true,
                Message = "Remove course version successfully",
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

    public async Task<ResponseDTO> AcceptCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "Course version was not found",
                    StatusCode = 404
                };
            }

            switch (courseVersion.CurrentStatus)
            {
                case StaticCourseVersionStatus.New:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have not been submit",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Accepted:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been accepted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Merged:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Removed:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been removed",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                default:
                {
                    courseVersion.CurrentStatus = StaticCourseVersionStatus.Accepted;
                    break;
                }
            }

            _unitOfWork.CourseVersionRepository.Update(courseVersion);

            var responseDto = await _courseVersionStatusService.CreateCourseVersionStatus
            (
                User,
                new CreateCourseVersionStatusDTO()
                {
                    CourseVersionId = courseVersion.Id,
                    Status = StaticCourseVersionStatus.Accepted
                }
            );

            if (responseDto.StatusCode == 500)
            {
                return responseDto;
            }

            BackgroundJob.Enqueue<IEmailSender>(job => job.SendAcceptedCourseEmailForInstructor(courseVersionId));

            return new ResponseDTO()
            {
                Result = null,
                IsSuccess = true,
                Message = "Accept course version successfully",
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

    public async Task<ResponseDTO> RejectCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "Course version was not found",
                    StatusCode = 404
                };
            }

            switch (courseVersion.CurrentStatus)
            {
                case StaticCourseVersionStatus.New:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have not been submit",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Accepted:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been accepted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Merged:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Removed:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been removed",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                default:
                {
                    courseVersion.CurrentStatus = StaticCourseVersionStatus.Rejected;
                    break;
                }
            }

            _unitOfWork.CourseVersionRepository.Update(courseVersion);

            var responseDto = await _courseVersionStatusService.CreateCourseVersionStatus
            (
                User,
                new CreateCourseVersionStatusDTO()
                {
                    CourseVersionId = courseVersion.Id,
                    Status = StaticCourseVersionStatus.Rejected
                }
            );

            if (responseDto.StatusCode == 500)
            {
                return responseDto;
            }

            BackgroundJob.Enqueue<IEmailSender>(job => job.SendRejectedCourseEmailForInstructor(courseVersionId));

            return new ResponseDTO()
            {
                Result = null,
                IsSuccess = true,
                Message = "Reject course version successfully",
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

    public async Task<ResponseDTO> SubmitCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "Course version was not found",
                    StatusCode = 404
                };
            }

            switch (courseVersion.CurrentStatus)
            {
                case StaticCourseVersionStatus.Submitted:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been submitted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Accepted:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been accepted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Merged:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Removed:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been removed",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                default:
                {
                    courseVersion.CurrentStatus = StaticCourseVersionStatus.Submitted;
                    break;
                }
            }

            _unitOfWork.CourseVersionRepository.Update(courseVersion);

            var responseDto = await _courseVersionStatusService.CreateCourseVersionStatus
            (
                User,
                new CreateCourseVersionStatusDTO()
                {
                    CourseVersionId = courseVersion.Id,
                    Status = StaticCourseVersionStatus.Submitted
                }
            );

            if (responseDto.StatusCode == 500)
            {
                return responseDto;
            }

            BackgroundJob.Enqueue<IEmailSender>(job => job.SendSubmittedCourseEmailForAdmins());

            return new ResponseDTO()
            {
                Result = null,
                IsSuccess = true,
                Message = "Submit course version successfully",
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

    public async Task<ResponseDTO> MergeCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);
            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "Course version was not found",
                    StatusCode = 404
                };
            }

            switch (courseVersion.CurrentStatus)
            {
                case StaticCourseVersionStatus.New:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have not been submit",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Rejected:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been rejected",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Submitted:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been submitted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Merged:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case StaticCourseVersionStatus.Removed:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been removed",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                default:
                {
                    courseVersion.CurrentStatus = StaticCourseVersionStatus.Merged;
                    break;
                }
            }

            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseVersion.CourseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course was not found",
                    StatusCode = 404,
                    IsSuccess = false,
                    Result = null
                };
            }

            course.CourseVersionId = courseVersion.Id;

            _unitOfWork.CourseVersionRepository.Update(courseVersion);
            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveAsync();

            var responseDto = await _courseVersionStatusService.CreateCourseVersionStatus
            (
                User,
                new CreateCourseVersionStatusDTO()
                {
                    CourseVersionId = courseVersion.Id,
                    Status = StaticCourseVersionStatus.Merged,
                }
            );

            if (responseDto.StatusCode == 500)
            {
                return responseDto;
            }

            return new ResponseDTO()
            {
                Result = null,
                IsSuccess = true,
                Message = "Submit course version successfully",
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

    public async Task<ResponseDTO> GetCourseVersionsComments
    (
        ClaimsPrincipal User,
        Guid? courseVersionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        int pageNumber,
        int pageSize
    )
    {
        try
        {
            // Lấy role xem có phải admin không
            var userRole = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            IEnumerable<CourseVersionComment> comments;

            if (userRole == StaticUserRoles.Admin)
            {
                // Lấy tất cả các bình luận của phiên bản khóa học theo courseVersionId
                comments = await _unitOfWork.CourseVersionCommentRepository.GetAllAsync(x =>
                    x.CourseVersionId == courseVersionId);
            }
            else
            {
                // Lấy các bình luận với trạng thái Activated hoặc thấp hơn
                comments = await _unitOfWork.CourseVersionCommentRepository.GetAllAsync(x =>
                    x.CourseVersionId == courseVersionId && x.Status <= StaticStatus.Category.Activated);
            }

            // Kiểm tra nếu danh sách bình luận là null hoặc rỗng
            if (!comments.Any())
            {
                return new ResponseDTO()
                {
                    Message = "There are no comments",
                    IsSuccess = true,
                    StatusCode = 204,
                    Result = null
                };
            }

            var listComments = comments.ToList();

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "comment":
                        listComments = listComments.Where(x =>
                            x.Comment.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    case "createby":
                        listComments = listComments.Where(x =>
                            x.CreatedBy.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    case "updateby":
                        listComments = listComments.Where(x =>
                            x.UpdatedBy.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    case "createtime":
                        listComments = listComments.Where(x =>
                                x.CreatedTime.HasValue && x.CreatedTime.Value.Date == DateTime.Parse(filterQuery).Date)
                            .ToList();
                        break;
                    case "updatetime":
                        listComments = listComments.Where(x =>
                                x.UpdatedTime.HasValue && x.UpdatedTime.Value.Date == DateTime.Parse(filterQuery).Date)
                            .ToList();
                        break;
                    case "status":
                        if (int.TryParse(filterQuery, out var status))
                        {
                            listComments = listComments.Where(x => x.Status == status).ToList();
                        }

                        break;
                    default:
                        break;
                }
            }

            // Sort Query
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "comment":
                        listComments = listComments.OrderBy(x => x.Comment).ToList();
                        break;
                    case "createby":
                        listComments = listComments.OrderBy(x => x.CreatedBy).ToList();
                        break;
                    case "updateby":
                        listComments = listComments.OrderBy(x => x.UpdatedBy).ToList();
                        break;
                    case "createtime":
                        listComments = listComments.OrderBy(x => x.CreatedTime).ToList();
                        break;
                    case "updatetime":
                        listComments = listComments.OrderBy(x => x.UpdatedTime).ToList();
                        break;
                    case "status":
                        listComments = listComments.OrderBy(x => x.Status).ToList();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // Sắp xếp bình luận theo thời gian tạo giảm dần nếu không có sortBy được chỉ định
                listComments = listComments.OrderByDescending(x => x.CreatedTime).ToList();
            }

            // Phân trang
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                listComments = listComments.Skip(skipResult).Take(pageSize).ToList();
            }

            // Chuyển đổi danh sách bình luận thành DTO
            var commentsDto = listComments.Select(comment => new GetAllCommentsDTO
            {
                Id = comment.Id,
                Comment = comment.Comment,
                CreateTime = comment.CreatedTime,
                CreateBy = comment.CreatedBy,
                UpdateTime = comment.UpdatedTime,
                UpdateBy = comment.UpdatedBy,
                Status = comment.Status
            }).ToList();

            return new ResponseDTO()
            {
                Message = "Get course version comments successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = commentsDto
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


    //Lấy comment bằng id đã hoàn thành
    public async Task<ResponseDTO> GetCourseVersionComment(ClaimsPrincipal User, Guid courseVersionCommentId)
    {
        try
        {
            var courseVersionComment =
                await _unitOfWork.CourseVersionCommentRepository.GetCourseVersionCommentById(courseVersionCommentId);

            if (courseVersionComment is null)
            {
                return new ResponseDTO()
                {
                    Result = "",
                    Message = "Course version was not found",
                    IsSuccess = true,
                    StatusCode = 404
                };
            }

            var courseVersionCommentDto = _mapper.Map<GetCourseCommnetDTO>(courseVersionComment);

            return new ResponseDTO()
            {
                Result = courseVersionCommentDto,
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
                StatusCode = 500
            };
        }
    }

    //Create đã hoàn thành
    public async Task<ResponseDTO> CreateCourseVersionComment(ClaimsPrincipal User,
        CreateCourseVersionCommentsDTO createCourseVersionCommentsDTO)
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseVersionId =
                await _unitOfWork.CourseVersionRepository.GetAsync(c =>
                    c.Id == createCourseVersionCommentsDTO.CourseVersionId);
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

            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            //Map DTO qua entity CourseVersionComment
            CourseVersionComment comment = new CourseVersionComment()
            {
                Comment = createCourseVersionCommentsDTO.Comment,
                CourseVersionId = createCourseVersionCommentsDTO.CourseVersionId,
                CreatedBy = admin.Email,
                CreatedTime = DateTime.Now,
                UpdatedTime = null,
                UpdatedBy = "",
                Status = 0
            };

            //thêm commetn vào cho CourseVersion
            await _unitOfWork.CourseVersionCommentRepository.AddAsync(comment);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Comment created successfully",
                Result = comment,
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

    //Edit đã hoàn thành
    public async Task<ResponseDTO> EditCourseVersionComment(ClaimsPrincipal User,
        EditCourseVersionCommentsDTO editCourseVersionCommentsDTO)
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseVersionId =
                await _unitOfWork.CourseVersionCommentRepository.GetAsync(c =>
                    c.Id == editCourseVersionCommentsDTO.Id);
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

            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            //update comment
            courseVersionId.UpdatedTime = DateTime.UtcNow;
            courseVersionId.UpdatedBy = admin.Email;
            courseVersionId.Comment = editCourseVersionCommentsDTO.Comment;
            courseVersionId.Status = 1;

            _unitOfWork.CourseVersionCommentRepository.Update(courseVersionId);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Comment Edited successfully",
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

    //Delete đã hoàn thành
    public async Task<ResponseDTO> RemoveCourseVersionComment(ClaimsPrincipal User,
        Guid commentId)
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseVersionId =
                await _unitOfWork.CourseVersionCommentRepository.GetAsync(c =>
                    c.Id == commentId);
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

            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            courseVersionId.UpdatedTime = DateTime.UtcNow;
            courseVersionId.UpdatedBy = admin.Email;
            courseVersionId.Status = 2;

            _unitOfWork.CourseVersionCommentRepository.Update(courseVersionId);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Comment Removed successfully",
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

    public async Task<ResponseDTO> UploadCourseVersionBackgroundImg
    (
        ClaimsPrincipal User,
        Guid courseVersionId,
        UploadCourseVersionBackgroundImg uploadCourseVersionBackgroundImg)
    {
        try
        {
            // Kiểm tra nếu File không null và đúng định dạng
            if (uploadCourseVersionBackgroundImg.File == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "No file uploaded."
                };
            }

            var courseVersion =
                await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);
            if (courseVersion == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Course version not found."
                };
            }

            var filePath = $"Course/{courseVersion.CourseId}/Background";
            // Xử lý tệp tin dựa trên định dạng
            var responseDto = await _firebaseService.UploadImage(uploadCourseVersionBackgroundImg.File, filePath);

            if (!responseDto.IsSuccess)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = "File upload failed."
                };
            }

            //Save
            courseVersion.CourseImgUrl = responseDto.Result?.ToString();
            _unitOfWork.CourseVersionRepository.Update(courseVersion);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = responseDto.Result,
                Message = "Upload file successfully"
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

    public async Task<MemoryStream> DisplayCourseVersionBackgroundImg(ClaimsPrincipal User, Guid courseVersionId)
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);

            if (courseVersion != null && courseVersion.CourseImgUrl.IsNullOrEmpty())
            {
                return null;
            }

            var stream = await _firebaseService.GetImage(courseVersion.CourseImgUrl);
            return stream;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}