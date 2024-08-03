using Cursus.LMS.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Service.IService
{
    public interface IStudentsService
    {
        Task<ResponseDTO> GetAllStudent
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

        Task<ResponseDTO> GetById(Guid id);
        Task<ResponseDTO> UpdateById(UpdateStudentDTO updateStudentDTO);
        Task<ResponseDTO> ActivateStudent(ClaimsPrincipal User, Guid studentId);
        Task<ResponseDTO> DeactivateStudent(ClaimsPrincipal User, Guid studentId);
        Task<ResponseDTO> GetStudentTotalCourses(Guid studentId);
        Task<ResponseDTO> GetAllCourseByStudentId(ClaimsPrincipal User ,CourseByStudentDTO courseByStudentDTO);
        Task<ResponseDTO> GetAllCourseStudentEnrolled(Guid studentId);
        Task<ResponseDTO> GetAllStudentComment(Guid studentId, int pageNumber, int pageSize);
        Task<ResponseDTO> CreateStudentComment(ClaimsPrincipal User, CreateStudentCommentDTO createStudentCommentDTO);
        Task<ResponseDTO> UpdateStudentComment(ClaimsPrincipal User, UpdateStudentCommentDTO updateStudentCommentDTO);
        Task<ResponseDTO> DeleteStudentComment(Guid commentId);
        Task<ResponseDTO> ExportStudents(string userId, int month, int year);
        Task<ClosedXMLResponseDTO> DownloadStudents(string fileName);
        Task<ResponseDTO> TotalPricesCoursesByStudentId(Guid studentId);

    }
}
