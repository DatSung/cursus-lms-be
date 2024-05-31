using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IAuthService
{
    Task<ResponseDTO> SignUpStudent(RegisterStudentDTO registerStudentDTO);
    Task<ResponseDTO> SignUpInstructor();
    Task<ResponseDTO> SignIn();
    Task<ResponseDTO> ForgotPassword();
    Task<ResponseDTO> ChangePassword();
    Task<ResponseDTO> VerifyEmail();
}