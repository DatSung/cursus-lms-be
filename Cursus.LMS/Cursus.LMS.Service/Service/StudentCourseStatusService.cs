using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class StudentCourseStatusService : IStudentCourseStatusService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentCourseStatusService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ResponseDTO> GetStudentCoursesStatus(Guid studentCourseId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetStudentCourseStatus(Guid studentCourseStatusId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> CreateStudentCourseStatus(CreateStudentCourseStatusDTO createStudentCourseStatusDto)
    {
        try
        {
            var studentCourseStatus = new StudentCourseStatus()
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.UtcNow,
                Status = createStudentCourseStatusDto.Status,
                StudentCourseId = createStudentCourseStatusDto.StudentCourseId,
                CreatedBy = createStudentCourseStatusDto.CreatedBy
            };

            await _unitOfWork.StudentCourseStatusRepository.AddAsync(studentCourseStatus);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Create student course status successfully",
                Result = studentCourseStatus.Id
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
}