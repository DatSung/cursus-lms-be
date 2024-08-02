using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Service.Service
{
    public class CourseReportService : ICourseReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> GetCourseReports(ClaimsPrincipal User, Guid? courseId, string? filterOn, string? filterQuery, string? sortBy, bool? isAscending, int pageNumber, int pageSize)
        {
            try
            {
                var courseReports = await _unitOfWork.CourseReportRepository.GetAllAsync(
                    filter: x => !courseId.HasValue || x.CourseId == courseId,
                    includeProperties: "Course"
                );

                // Apply filters
                if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
                {
                    courseReports = courseReports.Where(cr =>
                        (filterOn.ToLower() == "message" && cr.Message.Contains(filterQuery, StringComparison.OrdinalIgnoreCase))
                    ).ToList();
                }

                // Apply sorting
                if (!string.IsNullOrEmpty(sortBy))
                {
                    courseReports = isAscending == true
                        ? courseReports.OrderBy(cr => EF.Property<object>(cr, sortBy)).ToList()
                        : courseReports.OrderByDescending(cr => EF.Property<object>(cr, sortBy)).ToList();
                }

                // Apply pagination
                courseReports = courseReports.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                var courseReportDTOs = _mapper.Map<List<CourseReportDTO>>(courseReports);

                return new ResponseDTO
                {
                    Message = "Course reports retrieved successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = courseReportDTOs
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = null
                };
            }
        }

        public async Task<ResponseDTO> GetCourseReportById(Guid id)
        {
            try
            {
                var courseReport = await _unitOfWork.CourseReportRepository.GetById(id);
                if (courseReport == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course report not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                var courseReportDTO = _mapper.Map<CourseReportDTO>(courseReport);

                return new ResponseDTO
                {
                    Message = "Course report retrieved successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = courseReportDTO
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = null
                };
            }
        }

        public async Task<ResponseDTO> CreateCourseReport(CreateCourseReportDTO createCourseReportDTO)
        {
            try
            {
                var course = await _unitOfWork.CourseRepository.GetById(createCourseReportDTO.CourseId);
                if (course == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                var student = await _unitOfWork.StudentRepository.GetById(createCourseReportDTO.StudentId);
                if (student == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Student not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                var courseReport = new CourseReport
                {
                    Id = Guid.NewGuid(),
                    CourseId = createCourseReportDTO.CourseId,
                    StudentId = createCourseReportDTO.StudentId,
                    Message = createCourseReportDTO.Message,
                    CreatedBy = createCourseReportDTO.StudentId.ToString(),
                    CreatedTime = DateTime.UtcNow,
                    Status = 1 // Active status
                };

                await _unitOfWork.CourseReportRepository.AddAsync(courseReport);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO
                {
                    Message = "Course report created successfully",
                    IsSuccess = true,
                    StatusCode = 201,
                    Result = courseReport.Id
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = null
                };
            }
        }

        public async Task<ResponseDTO> UpdateCourseReport(ClaimsPrincipal User,UpdateCourseReportDTO updateCourseReportDTO)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (userId is null)
                {
                    return new ResponseDTO
                    {
                        Message = "User not found",
                        Result = null,
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                var courseReport = await _unitOfWork.CourseReportRepository.GetById(updateCourseReportDTO.Id);
                if (courseReport == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course report not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                courseReport.Message = updateCourseReportDTO.Message;
                courseReport.UpdatedBy = userId;
                courseReport.UpdatedTime = DateTime.UtcNow;

                _unitOfWork.CourseReportRepository.Update(courseReport);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO
                {
                    Message = "Course report updated successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = courseReport.Id
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = null
                };
            }
        }

        public async Task<ResponseDTO> DeleteCourseReport(Guid id)
        {
            try
            {
                var courseReport = await _unitOfWork.CourseReportRepository.GetById(id);
                if (courseReport == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Course report not found",
                        IsSuccess = false,
                        StatusCode = 404,
                        Result = null
                    };
                }

                courseReport.Status = 0; // Inactive status
                courseReport.UpdatedTime = DateTime.UtcNow;

                _unitOfWork.CourseReportRepository.Update(courseReport);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO
                {
                    Message = "Course report deleted successfully",
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = null
                };
            }
        }
    }

}
