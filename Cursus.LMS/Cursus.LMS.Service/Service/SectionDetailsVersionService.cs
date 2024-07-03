using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class SectionDetailsVersionService : ISectionDetailsVersionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFirebaseService _firebaseService;

    public SectionDetailsVersionService(IUnitOfWork unitOfWork, IFirebaseService firebaseService)
    {
        _unitOfWork = unitOfWork;
        _firebaseService = firebaseService;
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

    public Task<ResponseDTO> GetSectionsDetailsVersions
    (
        ClaimsPrincipal User,
        Guid? courseSectionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetSectionDetailsVersion
    (
        ClaimsPrincipal User,
        Guid detailsId
    )
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateSectionDetailsVersion
    (
        ClaimsPrincipal User,
        CreateSectionDetailsVersionDTO createSectionDetailsVersionDto
    )
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> EditSectionDetailsVersion
    (
        ClaimsPrincipal User,
        EditSectionDetailsVersionDTO editSectionDetailsVersionDto
    )
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RemoveSectionDetailsVersion
    (
        ClaimsPrincipal User,
        Guid detailsId
    )
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> UploadSectionDetailsVersionContent
    (
        ClaimsPrincipal User,
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
            var courseDetail = await _unitOfWork.SectionDetailsVersionRepository.GetAsync(x => x.Id == uploadSectionDetailsVersionContentDto.SectionDetailsVersionId);
            if (courseDetail == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Course section details version not found."
                };
            }

            var courseSection = await _unitOfWork.CourseSectionVersionRepository.GetAsync(x => x.Id == courseDetail.CourseSectionVersionId);
            if (courseSection == null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Course section version not found."
                };
            }

            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseSection.CourseVersionId);
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

    public Task<ResponseDTO> DisplaySectionDetailsVersionContent
    (
        ClaimsPrincipal User,
        string filePath
    )
    {
        throw new NotImplementedException();
    }
}