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
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class SectionDetailsVersionService : ISectionDetailsVersionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public SectionDetailsVersionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

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
                    StatusCode = 204,
                    Result = null
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
                name =  section.Name,
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
                i.Id == createSectionDetailsVersionDto.courseSectionIVersionId);
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
                CourseSectionVersionId = createSectionDetailsVersionDto?.courseSectionIVersionId,
                Name = createSectionDetailsVersionDto?.name,
            };

            await _unitOfWork.SectionDetailsVersionRepository.AddAsync(sectionDetail);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Create Section Detail Successfully",
                Result = sectionDetail,
                IsSuccess = false,
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
            var id = await _unitOfWork.SectionDetailsVersionRepository.GetAsync(i => i.Id == editSectionDetailsVersionDto.sectionDetailId);

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
                IsSuccess = false,
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

    public Task<ResponseDTO> UploadSectionDetailsVersionContent
    (
        ClaimsPrincipal User,
        UploadSectionDetailsVersionContentDTO uploadSectionDetailsVersionContentDto
    )
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> DisplaySectionDetailsVersionContent
    (
        ClaimsPrincipal User,
        string filePath
    )
    {
        throw new NotImplementedException();
    }
}