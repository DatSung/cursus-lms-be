﻿using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CourseProgressService : ICourseProgressService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseProgressService
    (
        IUnitOfWork unitOfWork
    )
    {
        _unitOfWork = unitOfWork;
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
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ResponseDTO> UpdateProgress(UpdateProgressDTO updateProgressDto)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ResponseDTO> GetProgress(GetProgressDTO getProgressDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetPercentage(GetPercentageDTO getPercentageDto)
    {
        throw new NotImplementedException();
    }
}