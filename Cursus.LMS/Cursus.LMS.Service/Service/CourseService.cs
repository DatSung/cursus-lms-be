using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
                Category = null,
                Code = null,
                Description = null,
                InstructorId = instructor?.InstructorId,
                Price = 0,
                Status = 0,
                Title = null,
                Version = 1,
                CategoryId = null,
                LearningTime = 0,
                LevelId = null,
                OldPrice = 0,
                StudentSlot = 0,
                TotalRate = 0,
                CourseImgUrl = null,
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

    public async Task<ResponseDTO> MergeCourseFromCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    )
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            // Get course version
            var courseVersion =
                await _unitOfWork.CourseVersionRepository
                    .GetCourseVersionAsync
                    (
                        courseVersionId,
                        asNoTracking: true
                    );

            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course version was not found",
                    StatusCode = 404,
                    Result = null,
                    IsSuccess = false
                };
            }

            // Get course section versions of course version
            courseVersion.CourseSectionVersions =
                await _unitOfWork.CourseSectionVersionRepository
                    .GetAllAsync(x => x.CourseVersionId == courseVersion.Id);

            // Get section details versions of course section versions
            foreach (var courseSectionVersion in courseVersion.CourseSectionVersions)
            {
                courseSectionVersion.SectionDetailsVersions =
                    await _unitOfWork.SectionDetailsVersionRepository.GetAllAsync(x =>
                        x.CourseSectionVersionId == courseSectionVersion.Id);
            }


            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseVersion.CourseId);

            if (course is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course was not found",
                    StatusCode = 404,
                    Result = null,
                    IsSuccess = false
                };
            }

            course.CourseSections = await _unitOfWork.CourseSectionRepository.GetAllAsync(x => x.CourseId == course.Id);

            foreach (var courseSection in course.CourseSections)
            {
                courseSection.SectionDetails =
                    await _unitOfWork.SectionDetailsRepository.GetAllAsync(x => x.CourseSectionId == courseSection.Id);
            }

            // Remove section details versions and course section versions 
            foreach (var courseSection in course.CourseSections)
            {
                _unitOfWork.SectionDetailsRepository.RemoveRange(courseSection.SectionDetails);
            }

            _unitOfWork.CourseSectionRepository.RemoveRange(course.CourseSections);


            // Merge section details versions and course section versions 
            var courseSections = new List<CourseSection>();
            var sectionsDetails = new List<SectionDetails>();
            
            foreach (var courseSectionVersion in courseVersion.CourseSectionVersions)
            {
                var courseSection = new CourseSection()
                {
                    Id = Guid.NewGuid(),
                    Description = courseSectionVersion.Description ?? "",
                    Title = courseSectionVersion.Title ?? "",
                    CourseId = course.Id
                };
                courseSections.Add(courseSection);

                foreach (var sectionDetailsVersion in courseSectionVersion.SectionDetailsVersions)
                {
                    var sectionDetails = new SectionDetails()
                    {
                        Id = Guid.NewGuid(),
                        CourseSectionId = courseSection.Id,
                        Name = sectionDetailsVersion.Name ?? "",
                        VideoUrl = sectionDetailsVersion.VideoUrl ?? "",
                        SlideUrl = sectionDetailsVersion.SlideUrl ?? "",
                        DocsUrl = sectionDetailsVersion.DocsUrl ?? "",
                    };
                    sectionsDetails.Add(sectionDetails);
                }
            }

            await _unitOfWork.CourseSectionRepository.AddRangeAsync(courseSections);
            await _unitOfWork.SectionDetailsRepository.AddRangeAsync(sectionsDetails);

            // Merge course version to course.
            course.CategoryId = courseVersion.CategoryId;
            course.CourseImgUrl = courseVersion.CourseImgUrl;
            course.LevelId = courseVersion.LevelId;
            course.Code = courseVersion.Code;
            course.Price = courseVersion.Price;
            course.Title = courseVersion.Title;
            course.Description = courseVersion.Description;
            course.Version = courseVersion.Version;
            course.Status = 1;
            course.ActivatedBy = user.Email;
            course.ActivatedTime = DateTime.UtcNow;
            course.MergedBy = user.Email;
            course.MergedTime = DateTime.UtcNow;

            _unitOfWork.CourseRepository.Update(course);

            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
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