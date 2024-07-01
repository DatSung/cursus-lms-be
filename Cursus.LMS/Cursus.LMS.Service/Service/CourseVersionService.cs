using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.IdentityModel.Tokens;

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
                CurrentStatus = 0,
                Version = 1,
                CreatedTime = DateTime.UtcNow,
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
    //GetAllComment
    public async Task<ResponseDTO> GetCourseVersionsComments
(
    ClaimsPrincipal User,
    Guid courseVersionId,
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
                comments = await _unitOfWork.CourseVersionCommentRepository.GetAllAsync(x => x.CourseVersionId == courseVersionId);
            }
            else
            {
                // Lấy các bình luận với trạng thái Activated hoặc thấp hơn
                comments = await _unitOfWork.CourseVersionCommentRepository.GetAllAsync(x => x.CourseVersionId == courseVersionId && x.Status <= StaticStatus.Category.Activated);
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
                        listComments = listComments.Where(x => x.Comment.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    case "createby":
                        listComments = listComments.Where(x => x.CreateBy.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    case "updateby":
                        listComments = listComments.Where(x => x.UpdateBy.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    case "createtime":
                        listComments = listComments.Where(x => x.CreateTime.HasValue && x.CreateTime.Value.Date == DateTime.Parse(filterQuery).Date).ToList();
                        break;
                    case "updatetime":
                        listComments = listComments.Where(x => x.UpdateTime.HasValue && x.UpdateTime.Value.Date == DateTime.Parse(filterQuery).Date).ToList();
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
                        listComments = listComments.OrderBy(x => x.CreateBy).ToList();
                        break;
                    case "updateby":
                        listComments = listComments.OrderBy(x => x.UpdateBy).ToList();
                        break;
                    case "createtime":
                        listComments = listComments.OrderBy(x => x.CreateTime).ToList();
                        break;
                    case "updatetime":
                        listComments = listComments.OrderBy(x => x.UpdateTime).ToList();
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
                listComments = listComments.OrderByDescending(x => x.CreateTime).ToList();
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
                CreateTime = comment.CreateTime,
                CreateBy = comment.CreateBy,
                UpdateTime = comment.UpdateTime,
                UpdateBy = comment.UpdateBy,
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

    //Delete đã hoàn thành
    public async Task<ResponseDTO> RemoveCourseVersionComment(ClaimsPrincipal User,
        RemoveCourseVersionCommentDTO removeCourseVersionCommentDTO)
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseVersionId =
                await _unitOfWork.CourseVersionCommentRepository.GetAsync(c =>
                    c.Id == removeCourseVersionCommentDTO.Id);
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