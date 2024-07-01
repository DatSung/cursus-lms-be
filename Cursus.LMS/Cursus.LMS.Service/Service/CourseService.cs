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
                Code = null,
                InstructorId = instructor?.InstructorId,
                Status = 0,
                Version = 1,
                StudentSlots = 0,
                TotalRate = 0,
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
}