using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using CreateCourseVersionCommentsDTO = Cursus.LMS.Model.DTO.CreateCourseVersionCommentsDTO;

namespace Cursus.LMS.Service.Service;

public class CourseVersionService : ICourseVersionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseService _courseService;
    private readonly ICourseSectionVersionService _courseSectionVersionService;
    private readonly ICourseVersionStatusService _courseVersionStatusService;
    private IMapper _mapper;

    public CourseVersionService
    (
        IUnitOfWork unitOfWork,
        ICourseService courseService,
        IMapper mapper,
        ICourseVersionStatusService courseVersionStatusService,
        ICourseSectionVersionService courseSectionVersionService
    )
    {
        _unitOfWork = unitOfWork;
        _courseService = courseService;
        _mapper = mapper;
        _courseVersionStatusService = courseVersionStatusService;
        _courseSectionVersionService = courseSectionVersionService;
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
        try
        {
            return new ResponseDTO()
            {
                Result = null,
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
                await _unitOfWork.CourseVersionRepository.GetCourseVersionAsync(courseVersionId, asNoTracking: true);

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

    public async Task<ResponseDTO> CreateCourseAndVersion
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
                Id = Guid.NewGuid(),
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
                    Status = 0
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
                    Status = 0
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

    public Task<ResponseDTO> EditCourseVersion(ClaimsPrincipal User, EditCourseVersionDTO editCourseVersionDto)
    {
        throw new NotImplementedException();
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
                case 4:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 5:
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
                    courseVersion.CurrentStatus = 5;
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
                    Status = 5
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
                case 0:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have not been submit",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 2:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been accepted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 4:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 5:
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
                    courseVersion.CurrentStatus = 2;
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
                    Status = 2
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
                case 0:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have not been submit",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 2:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been accepted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 4:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 5:
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
                    courseVersion.CurrentStatus = 3;
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
                    Status = 3
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
                case 1:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been submitted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 2:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been accepted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 4:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 5:
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
                    courseVersion.CurrentStatus = 1;
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
                    Status = 1
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
                case 0:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have not been submit",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 1:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been submitted",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 4:
                {
                    return new ResponseDTO()
                    {
                        Message = "Course version have been merged",
                        StatusCode = 401,
                        IsSuccess = false,
                        Result = null
                    };
                }
                case 5:
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
                    courseVersion.CurrentStatus = 4;
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
                    Status = 4,
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
        Guid? courseVersionCommentId,
        Guid? courseVersionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        int pageNumber,
        int pageSize
    )
    {
        throw new NotImplementedException();
    }


    public Task<ResponseDTO> GetCourseVersionsComments(ClaimsPrincipal User)
    {
        /*try
        {
            return new ResponseDTO()
            {
                Result = null,
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
        }*/
        return null;
    }

    public async Task<ResponseDTO> GetCourseVersionComment(ClaimsPrincipal User, Guid courseVersionCommentId)
    {
        /*try
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

            var courseVersionCommentDto = _mapper.Map<GetCourseCommnetDTO>(courseVersionCommentId);

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
        }*/
        return null;
    }


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
                CreateBy = admin.Email,
                CreateTime = DateTime.Now,
                UpdateTime = null,
                UpdateBy = "",
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

    public async Task<ResponseDTO> EditCourseVersionComment(ClaimsPrincipal User,
        EditCourseVersionCommentsDTO editCourseVersionCommentsDTO)
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseVersionId =
                await _unitOfWork.CourseVersionCommentRepository.GetAsync(c =>
                    c.Id == editCourseVersionCommentsDTO.CourseVersionId);
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
            courseVersionId.UpdateTime = DateTime.UtcNow;
            courseVersionId.UpdateBy = admin.Email;
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

    public async Task<ResponseDTO> RemoveCourseVersionComment(ClaimsPrincipal User,
        RemoveCourseVersionCommentDTO removeCourseVersionCommentDTO)
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseVersionId =
                await _unitOfWork.CourseVersionCommentRepository.GetAsync(c =>
                    c.Id == removeCourseVersionCommentDTO.CourseVersionId);
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

            courseVersionId.UpdateTime = DateTime.UtcNow;
            courseVersionId.UpdateBy = admin.Email;
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
}