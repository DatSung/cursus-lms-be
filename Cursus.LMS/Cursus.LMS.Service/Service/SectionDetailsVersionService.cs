using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.DataAccess.Repository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class SectionDetailsVersionService : ISectionDetailsVersionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFirebaseService _firebaseService;
    private readonly UserManager<ApplicationUser> _userManager;

    public SectionDetailsVersionService(IUnitOfWork unitOfWork, IMapper mapper, IFirebaseService firebaseService,
        UserManager<ApplicationUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _firebaseService = firebaseService;
        _userManager = userManager;
    }

    public async Task<ResponseDTO> CloneSectionsDetailsVersion
    (
        ClaimsPrincipal User,
        CloneSectionsDetailsVersionDTO cloneSectionsDetailsVersionDto
    )
    {
        try
        {
            var sectionDetailsVersions =
                await _unitOfWork.SectionDetailsVersionRepository
                    .GetSectionDetailsVersionsOfCourseSectionVersionAsync
                    (
                        cloneSectionsDetailsVersionDto.OldCourseSectionVersionId,
                        asNoTracking: true
                    );

            if (sectionDetailsVersions.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Section details of course section version was not found"
                };
            }

            foreach (var sectionDetailsVersion in sectionDetailsVersions)
            {
                sectionDetailsVersion.Id = Guid.NewGuid();
                sectionDetailsVersion.CourseSectionVersionId = cloneSectionsDetailsVersionDto.NewCourseSectionVersionId;
            }

            await _unitOfWork.SectionDetailsVersionRepository.AddRangeAsync(sectionDetailsVersions);
            await _unitOfWork.SaveAsync();

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

    public async Task<ResponseDTO> GetSectionsDetailsVersions
    (
        ClaimsPrincipal User,
        Guid? courseSectionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize)
    {
        try
        {
            IEnumerable<SectionDetailsVersion> sections;

            // Lấy tất cả các section của phiên bản khóa học theo CourseSectionVersionId
            sections = await _unitOfWork.SectionDetailsVersionRepository.GetAllAsync(x =>
                x.CourseSectionVersionId == courseSectionId);

            // Kiểm tra nếu danh sách bình luận là null hoặc rỗng
            if (!sections.Any())
            {
                return new ResponseDTO()
                {
                    Message = "There are no section",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = sections
                };
            }

            var listSection = sections.ToList();

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "name":
                        listSection = listSection.Where(x =>
                            x.Name.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
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
                    case "name":
                        listSection = listSection.OrderBy(x => x.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            // Phân trang
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                listSection = listSection.Skip(skipResult).Take(pageSize).ToList();
            }

            // Chuyển đổi danh sách bình luận thành DTO
            var sectionDto = listSection.Select(section => new GetAllSectionDetailDTO
            {
                Id = section.Id,
                courseSectionDetail = section.CourseSectionVersionId,
                name = section.Name,
                videoUrl = section.VideoUrl,
                slideUrl = section.SlideUrl,
                docsUrl = section.DocsUrl,
                type = section.Type,
                currentStatus = section.CurrentStatus,
            }).ToList();

            return new ResponseDTO()
            {
                Message = "Get course version comments successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = sectionDto
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

    public async Task<ResponseDTO> GetSectionDetailsVersion(ClaimsPrincipal User, Guid detailsId)
    {
        try
        {
            var detail =
                await _unitOfWork.SectionDetailsVersionRepository.GetSectionDetailsVersionById(detailsId);

            if (detail is null)
            {
                return new ResponseDTO()
                {
                    Result = "",
                    Message = "Course Section Detail version was not found",
                    IsSuccess = true,
                    StatusCode = 404
                };
            }

            var sectionDetail = new SectionDetailsVersion
            {
                Id = detailsId,
                CourseSectionVersionId = detail.CourseSectionVersionId,
                Name = detail.Name,
                VideoUrl = detail.VideoUrl,
                SlideUrl = detail.SlideUrl,
                DocsUrl = detail.DocsUrl,
                Type = detail.Type,
                CurrentStatus = detail.CurrentStatus,
            };

            return new ResponseDTO()
            {
                Result = sectionDetail,
                Message = "Get Course Section Detail Successfully",
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

    public async Task<ResponseDTO> CreateSectionDetailsVersion
    (
        ClaimsPrincipal User,
        CreateSectionDetailsVersionDTO createSectionDetailsVersionDto
    )
    {
        try
        {
            var Id =
                await _unitOfWork.CourseSectionVersionRepository.GetAsync(i =>
                    i.Id == createSectionDetailsVersionDto.courseSectionVersionId);
            if (Id == null)
            {
                return new ResponseDTO()
                {
                    Message = "CourseSectionVersionId Invalid",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            var sectionDetail = new SectionDetailsVersion
            {
                CourseSectionVersionId = createSectionDetailsVersionDto.courseSectionVersionId,
                Name = createSectionDetailsVersionDto?.name,
            };

            await _unitOfWork.SectionDetailsVersionRepository.AddAsync(sectionDetail);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Create section detail successfully",
                Result = sectionDetail,
                IsSuccess = true,
                StatusCode = 200
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

    public async Task<ResponseDTO> EditSectionDetailsVersion
    (
        ClaimsPrincipal User,
        EditSectionDetailsVersionDTO editSectionDetailsVersionDto
    )
    {
        try
        {
            var id = await _unitOfWork.SectionDetailsVersionRepository.GetAsync(i =>
                i.Id == editSectionDetailsVersionDto.sectionDetailId);

            if (id == null)
            {
                return new ResponseDTO()
                {
                    Message = "SectionDetailVersionId Invalid",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            id.CourseSectionVersionId = editSectionDetailsVersionDto.courseSectionId;
            id.Name = editSectionDetailsVersionDto?.name;


            _unitOfWork.SectionDetailsVersionRepository.Update(id);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Edit Section Detail Successfully",
                Result = id,
                IsSuccess = true,
                StatusCode = 200
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

    public async Task<ResponseDTO> RemoveSectionDetailsVersion
    (
        ClaimsPrincipal User,
        Guid detailsId
    )
    {
        try
        {
            var Id = await _unitOfWork.SectionDetailsVersionRepository.GetAsync(i => i.Id == detailsId);
            if (Id == null)
            {
                return new ResponseDTO()
                {
                    Message = "SectionDetailVersionId Invalid",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }


            _unitOfWork.SectionDetailsVersionRepository.Remove(Id);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "SectionDetailVersion removed successfully",
                Result = null,
                IsSuccess = true,
                StatusCode = 200
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

    public async Task<ResponseDTO> UploadSectionDetailsVersionContent
    (
        ClaimsPrincipal User,
        Guid detailsId,
        UploadSectionDetailsVersionContentDTO uploadSectionDetailsVersionContentDto
    )
    {
        try
        {
            // Kiểm tra nếu File không null và đúng định dạng
            if (uploadSectionDetailsVersionContentDto.File == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "No file uploaded."
                };
            }

            var fileExtension = Path.GetExtension(uploadSectionDetailsVersionContentDto.File.FileName).ToLower();
            string[] allowedExtensions = { ".docx", ".pdf", ".mp4", ".mov" };

            if (!allowedExtensions.Contains(fileExtension))
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "Invalid file format. Allowed formats are: .docx, .pdf, .mp4, .mov"
                };
            }

            // Lấy userId từ ClaimsPrincipal
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 401,
                    Message = "User is not authenticated."
                };
            }

            // Kiểm tra instructor
            var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == userId);
            if (instructor == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Instructor does not exist."
                };
            }


            // Lấy thông tin về Course và CourseVersion và CourseDetail
            var courseDetail = await _unitOfWork.SectionDetailsVersionRepository.GetAsync(x =>
                x.Id == detailsId);
            if (courseDetail == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Course section details version not found."
                };
            }

            var courseSection =
                await _unitOfWork.CourseSectionVersionRepository.GetAsync(x =>
                    x.Id == courseDetail.CourseSectionVersionId);
            if (courseSection == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Course section version not found."
                };
            }

            var courseVersion =
                await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseSection.CourseVersionId);
            if (courseVersion == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Course version not found."
                };
            }

            //Get CourseId
            var courseId = courseVersion.CourseId;

            // Xử lý tệp tin dựa trên định dạng
            ResponseDTO responseDto;
            if (fileExtension == ".mp4" || fileExtension == ".mov")
            {
                responseDto = await _firebaseService.UploadVideo(uploadSectionDetailsVersionContentDto.File, courseId);

                courseDetail.VideoUrl = responseDto.Result?.ToString();
            }
            else if (fileExtension == ".pdf")
            {
                responseDto = await _firebaseService.UploadSlide(uploadSectionDetailsVersionContentDto.File, courseId);

                courseDetail.SlideUrl = responseDto.Result?.ToString();
            }
            else
            {
                responseDto = await _firebaseService.UploadDoc(uploadSectionDetailsVersionContentDto.File, courseId);

                courseDetail.DocsUrl = responseDto.Result?.ToString();
            }

            if (!responseDto.IsSuccess)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = "File upload failed."
                };
            }

            // Cập nhật Type và TypeDescription
            courseDetail.UpdateTypeDescription();
            //Save
            _unitOfWork.SectionDetailsVersionRepository.Update(courseDetail);
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

    public async Task<ContentResponseDTO> DisplaySectionDetailsVersionContent
    (
        Guid sectionDetailsVersionId,
        string userId,
        string type
    )
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new Exception("User was not found");
            }

            if (sectionDetailsVersionId.ToString().IsNullOrEmpty())
            {
                throw new Exception("Section details was not found!");
            }

            if (type.IsNullOrEmpty())
            {
                throw new Exception("Content was not found");
            }

            var sectionDetailVersion = await _unitOfWork.SectionDetailsVersionRepository
                .GetAsync(x => x.Id == sectionDetailsVersionId);

            if (sectionDetailVersion is null)
            {
                throw new Exception("Section details was not found!");
            }

            var courseVersionId = _unitOfWork.CourseSectionVersionRepository
                .GetAsync(x => x.Id == sectionDetailVersion.CourseSectionVersionId)
                .GetAwaiter()
                .GetResult()!
                .CourseVersionId;

            var courseId = _unitOfWork.CourseVersionRepository
                .GetAsync(x => x.Id == courseVersionId)
                .GetAwaiter()
                .GetResult()!
                .CourseId;

            var role = await _userManager.GetRolesAsync(user);
            if (role.Contains(StaticUserRoles.Student))
            {
                var student = await _unitOfWork.StudentRepository.GetAsync(x => x.UserId == userId);
                var studentCourse = await _unitOfWork.StudentCourseRepository
                    .GetAsync(x => x.CourseId == courseId && x.StudentId == student.StudentId);
                if (studentCourse is null)
                {
                    throw new Exception("Student does not own this course");
                }
            }

            if (role.Contains(StaticUserRoles.Instructor))
            {
                var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == userId);
                var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

                if (course?.InstructorId != instructor?.InstructorId)
                {
                    throw new Exception("Instructor does not own this course");
                }
            }

            var stream = new MemoryStream();
            var contentType = "Unsupported extensions!";
            string? filePath = null;

            switch (type.ToLower())
            {
                case "video":
                {
                    filePath = sectionDetailVersion.VideoUrl;

                    if (filePath == null)
                    {
                        throw new Exception("Content was not found");
                    }

                    stream = await _firebaseService.GetContent(filePath);

                    if (filePath.EndsWith(".mp4"))
                    {
                        contentType = StaticFileExtensions.Mp4;
                    }

                    if (filePath.EndsWith(".mov"))
                    {
                        contentType = StaticFileExtensions.Mov;
                    }

                    break;
                }
                case "slide":
                {
                    filePath = sectionDetailVersion.SlideUrl;

                    if (filePath == null)
                    {
                        throw new Exception("Content was not found");
                    }

                    stream = await _firebaseService.GetContent(filePath);
                    contentType = StaticFileExtensions.Pdf;
                    break;
                }
                case "docx":
                {
                    filePath = sectionDetailVersion.DocsUrl;

                    if (filePath == null)
                    {
                        throw new Exception("Content was not found");
                    }

                    stream = await _firebaseService.GetContent(filePath);
                    contentType = StaticFileExtensions.Doc;

                    break;
                }
                default:
                {
                    throw new Exception("Content type was not correct");
                }
                    ;
            }

            if (stream is null)
            {
                throw new Exception("Instructor did not upload degree");
            }


            return new ContentResponseDTO()
            {
                Message = "Get file successfully",
                Stream = stream,
                ContentType = contentType,
                FileName = Path.GetFileName(filePath)
            };
        }
        catch (Exception e)
        {
            return new ContentResponseDTO()
            {
                ContentType = null,
                Message = e.Message,
                Stream = null
            };
        }
    }
}