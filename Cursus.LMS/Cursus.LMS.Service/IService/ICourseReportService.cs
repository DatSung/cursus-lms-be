using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Http;


namespace Cursus.LMS.Service.IService;

    public interface ICourseReportService
    {
        Task<ResponseDTO> GetCourseReports(ClaimsPrincipal User, Guid? courseId, string? filterOn, string? filterQuery, string? sortBy, bool? isAscending, int pageNumber, int pageSize);
        Task<ResponseDTO> GetCourseReportById(Guid id);
        Task<ResponseDTO> CreateCourseReport(CreateCourseReportDTO createCourseReportDTO);
        Task<ResponseDTO> UpdateCourseReport(ClaimsPrincipal User,UpdateCourseReportDTO updateCourseReportDTO);
        Task<ResponseDTO> DeleteCourseReport(Guid id);
        
    }

