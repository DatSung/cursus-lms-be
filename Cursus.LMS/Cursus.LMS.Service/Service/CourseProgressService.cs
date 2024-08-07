using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service;

public class CourseProgressService : ICourseProgressService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentCourseService _studentCourseService;
    private readonly IEmailService _emailService;

    public CourseProgressService
    (
        IUnitOfWork unitOfWork, IStudentCourseService studentCourseService, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _studentCourseService = studentCourseService;
        _emailService = emailService;
    }

    public async Task<ResponseDTO> CreateProgress(CreateProgressDTO createProgressDto)
    {
        try
        {
            var studentCourse =
                await _unitOfWork.StudentCourseRepository.GetAsync(x => x.Id == createProgressDto.StudentCourseId);

            if (studentCourse is null)
            {
                return new ResponseDTO()
                {
                    Message = "Student course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var courseProgress = await _unitOfWork.CourseProgressRepository
                .GetAsync(x => x.StudentCourseId == studentCourse.Id);

            if (courseProgress is not null)
            {
                return new ResponseDTO()
                {
                    Message = "Course progress has been existed",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            var courseVersionId = _unitOfWork.CourseRepository
                .GetAsync(x => x.Id == studentCourse.CourseId)
                .GetAwaiter()
                .GetResult()!
                .CourseVersionId;

            var sectionVersions = await _unitOfWork.CourseSectionVersionRepository
                .GetAllAsync(x => x.CourseVersionId == courseVersionId);

            var rootSectionsDetails = new List<SectionDetailsVersion>();
            foreach (var sectionVersion in sectionVersions)
            {
                var sectionsDetails = await _unitOfWork.SectionDetailsVersionRepository
                    .GetAllAsync(x => x.CourseSectionVersionId == sectionVersion.Id);
                rootSectionsDetails.AddRange(sectionsDetails);
            }

            var coursesProgresses = rootSectionsDetails.Select(x => new CourseProgress()
            {
                Id = Guid.NewGuid(),
                CourseId = studentCourse.CourseId,
                CompletedTime = null,
                DetailsId = x.Id,
                IsCompleted = false,
                SectionId = x.CourseSectionVersionId,
                StudentCourseId = studentCourse.Id,
            });

            await _unitOfWork.CourseProgressRepository.AddRangeAsync(coursesProgresses);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = null,
                Message = "Create course progress successfully"
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

    public async Task<ResponseDTO> UpdateProgress(ClaimsPrincipal User, UpdateProgressDTO updateProgressDto)
    {
        try
        {
            var studentCourse = await _unitOfWork.StudentCourseRepository
                .GetAsync
                (
                    x => x.CourseId == updateProgressDto.CourseId
                         && x.StudentId == updateProgressDto.StudentId
                );

            if (studentCourse is null)
            {
                return new ResponseDTO()
                {
                    Message = "Student course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var courseProgress = await _unitOfWork.CourseProgressRepository.GetAsync
            (
                x => x.StudentCourseId == studentCourse.Id
                     && x.CourseId == studentCourse.CourseId
                     && x.SectionId == updateProgressDto.SectionId
                     && x.DetailsId == updateProgressDto.DetailsId
            );

            if (courseProgress is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course progress was not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            courseProgress.IsCompleted = true;
            courseProgress.CompletedTime = DateTime.Now;

            await _unitOfWork.SaveAsync();

            await CheckFinishCourse(User, studentCourse.StudentId, studentCourse.CourseId);

            return new ResponseDTO()
            {
                Message = "Update progress successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
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

    public async Task<ResponseDTO> GetProgress(GetProgressDTO getProgressDto)
    {
        try
        {
            var studentCourse = await _unitOfWork.StudentCourseRepository
                .GetAsync(
                    x => x.CourseId == getProgressDto.CourseId
                         && x.StudentId == getProgressDto.StudentId
                );

            if (studentCourse is null)
            {
                return new ResponseDTO()
                {
                    Message = "Student course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var courseProgress = await _unitOfWork.CourseProgressRepository.GetAsync
            (
                x => x.StudentCourseId == studentCourse.Id
                     && x.CourseId == studentCourse.CourseId
                     && x.SectionId == getProgressDto.SectionId
                     && x.DetailsId == getProgressDto.DetailsId
            );

            if (courseProgress is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course progress was not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            return new ResponseDTO()
            {
                Result = courseProgress,
                Message = "Get course progress successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseDTO> GetPercentage(GetPercentageDTO getPercentageDto)
    {
        try
        {
            var studentCourse = await _unitOfWork.StudentCourseRepository.GetAsync
            (
                x => x.StudentId == getPercentageDto.StudentId
                     && x.CourseId == getPercentageDto.CourseId
            );

            if (studentCourse is null)
            {
                return new ResponseDTO()
                {
                    Message = "Student course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var courseProgress = await _unitOfWork.CourseProgressRepository
                .GetAllAsync(x => x.StudentCourseId == studentCourse.Id);

            var percentage = (courseProgress.Count(x => x.IsCompleted) * 100) / courseProgress.Count();

            return new ResponseDTO()
            {
                Message = "Get percentage successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = percentage
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

    private async Task CheckFinishCourse(ClaimsPrincipal User, Guid studentId, Guid courseId)
    {
        try
        {
            var courseProgress = await _unitOfWork.CourseProgressRepository.GetAllAsync(x => x.CourseId == courseId);
            var isCourseCompleted = courseProgress.Any(x => x.IsCompleted is false);

            if (isCourseCompleted)
            {
                await _studentCourseService.UpdateStudentCourse
                (
                    User,
                    new UpdateStudentCourseDTO()
                    {
                        CourseId = courseId,
                        StudentId = studentId,
                        Status = StaticStatus.StudentCourse.Completed
                    }
                );

                var userId = _unitOfWork.StudentRepository.GetAsync(x => x.StudentId == studentId).GetAwaiter()
                    .GetResult()!.UserId;
                var userEmail = _unitOfWork.UserManagerRepository.FindByIdAsync(userId).GetAwaiter().GetResult().Email;

                if (userEmail != null)
                {
                    await _emailService.SendEmailForStudentAboutCompleteCourse(userEmail);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}