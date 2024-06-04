using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Service.IService;

public interface IAuthService
{

    Task<ResponseDTO> SignUpStudent(RegisterStudentDTO registerStudentDTO);
    Task<ResponseDTO> SignUpInstructor(InstructorDTO instructorDto);
    Task<ResponseDTO> UploadInstructorDegree(IFormFile file, ClaimsPrincipal user);
    Task<ResponseDTO> UploadUserAvatar(IFormFile file, ClaimsPrincipal user);
    Task<DegreeResponseDTO> GetInstructorDegree(ClaimsPrincipal user);
    Task<MemoryStream> GetUserAvatar(ClaimsPrincipal user);
    Task<SignResponseDTO> SignIn(SignDTO signDTO);
    Task<ResponseDTO> ForgotPassword();
    Task<ResponseDTO> ChangePassword();
    Task<ResponseDTO> VerifyEmail();
}