using System.Security.Claims;
using AutoMapper;
using Azure;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class CourseSectionVersionService : ICourseSectionVersionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISectionDetailsVersionService _sectionDetailsVersionService;
    private IMapper _mapper;

    public CourseSectionVersionService
    (
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ISectionDetailsVersionService sectionDetailsVersionService
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

            IEnumerable<CourseSectionVersion> sectionVersions;

            if (userRole == StaticUserRoles.Admin)
            {
                // Lấy tất cả các bình luận của phiên bản khóa học theo courseVersionId
                sectionVersions = await _unitOfWork.CourseSectionVersionRepository.GetAllAsync(x =>
                    x.CourseVersionId == courseVersionId);
            }
            else
            {
                // Lấy các bình luận với trạng thái Activated hoặc thấp hơn
                sectionVersions = await _unitOfWork.CourseSectionVersionRepository.GetAllAsync(x =>
                    x.CourseVersionId == courseVersionId && x.CurrentStatus <= StaticStatus.Category.Activated);
            }

            // Kiểm tra nếu danh sách bình luận là null hoặc rỗng
            if (!sectionVersions.Any())
            {
                return new ResponseDTO()
                {
                    Message = "There are no sectionVersions",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = sectionVersions
                };
            }

            var listSections = sectionVersions.ToList();

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "title":
                        listSections = listSections.Where(x =>
                            x.Title.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    case "description":
                        listSections = listSections.Where(x =>
                            x.Description.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    case "currentstatus":
                        if (int.TryParse(filterQuery, out var status))
                        {
                            listSections = listSections.Where(x => x.CurrentStatus == status).ToList();
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
                    case "title":
                        listSections = listSections.OrderBy(x => x.Title).ToList();
                        break;
                    case "description":
                        listSections = listSections.OrderBy(x => x.Description).ToList();
                        break;
                    case "currentstatus":
                        listSections = listSections.OrderBy(x => x.CurrentStatus).ToList();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // Sắp xếp Sections theo Title tạo giảm dần nếu không có sortBy được chỉ định
                listSections = listSections.OrderBy(x => x.Title).ToList();
            }

            // Phân trang
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                listSections = listSections.Skip(skipResult).Take(pageSize).ToList();
            }

            // Chuyển đổi danh sách bình luận thành DTO
            var sectionsDto = listSections.Select(section => new GetAllSectionsDTO
            {
                Id = section.Id,
                Title = section.Title,
                Description = section.Description,
                CurrentStatus = (int)section.CurrentStatus
            }).ToList();

            return new ResponseDTO()
            {
                Message = "Get course sections version successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = sectionsDto
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

    public async Task<ResponseDTO> GetCourseSection
    (
        ClaimsPrincipal User,
        Guid courseSectionVersionId
    )
    {
        try
        {
            var courseSectionVersion =
                await _unitOfWork.CourseSectionVersionRepository.GetAsync(c =>
                    c.Id == courseSectionVersionId);

            if (courseSectionVersion is null)
            {
                return new ResponseDTO()
                {
                    Result = "",
                    Message = "Course section version was not found",
                    IsSuccess = true,
                    StatusCode = 404
                };
            }

            var courseSectionVersionDto = _mapper.Map<GetCourseSectionDTO>(courseSectionVersion);

            return new ResponseDTO()
            {
                Result = courseSectionVersionDto,
                Message = "Get course section version successfully",
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
                    Message = "Course version was not found",
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
                Result = courseSectionVersion.Id,
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

            //update 
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
        Guid sectionVersionId
    )
    {
        try
        {
            //Tìm xem có đúng ID CourseVersion hay không
            var courseSectionVersion =
                await _unitOfWork.CourseSectionVersionRepository.GetAsync(c =>
                    c.Id == sectionVersionId);
            if (courseSectionVersion == null)
            {
                return new ResponseDTO()
                {
                    Message = "Course section version was not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            //var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            //var admin = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            var sectionDetailVersion =
                await _unitOfWork.SectionDetailsVersionRepository.GetAllAsync(x =>
                    x.CourseSectionVersionId == courseSectionVersion.Id);

            _unitOfWork.SectionDetailsVersionRepository.RemoveRange(sectionDetailVersion);
            _unitOfWork.CourseSectionVersionRepository.Remove(courseSectionVersion);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Course section version removed successfully",
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