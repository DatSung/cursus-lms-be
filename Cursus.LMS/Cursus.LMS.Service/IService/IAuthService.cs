using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IAuthService
{
    Task<ResponseDTO> SignUpStudent();
    Task<ResponseDTO> SignUpInstructor(InstructorDTO instructorDto);
    Task<ResponseDTO> SignIn();
    Task<ResponseDTO> ForgotPassword();
    Task<ResponseDTO> ChangePassword();
    Task<ResponseDTO> VerifyEmail();
}