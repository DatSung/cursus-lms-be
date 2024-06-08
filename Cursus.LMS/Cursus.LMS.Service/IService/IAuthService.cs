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
    Task<ResponseDTO> SignIn(SignDTO signDTO);
    Task<SignResponseDTO> StudentSignInByGoogle(StudentSignInByGoogleDTO studentSignInByGoogleDto);
    Task<SignResponseDTO> InstructorSignInByGoogle(InstructorSignInByGoogleDTO instructorSignInByGoogleDto);
    Task<ResponseDTO> ForgotPassword(ForgotPasswordDTO forgotPasswordDto);
    Task<ResponseDTO> Refresh(string token);
    Task<ResponseDTO> ResetPassword(string resetPasswordDto, string token, string password);
    Task<ResponseDTO> ChangePassword(string userId, string oldPassword, string newPassword, string confirmNewPassword);
    Task<ResponseDTO> SendVerifyEmail(string email, string confirmationLink);
    Task<ResponseDTO> VerifyEmail(string userId, string token);
    Task<ResponseDTO> CheckEmailExist(string email);
    Task<ResponseDTO> CheckPhoneNumberExist(string phoneNumber);
    Task<ResponseDTO> UpdateStudentProfile(ClaimsPrincipal User, UpdateStudentProfileDTO studentProfileDto);
    Task<ResponseDTO> UpdateInstructorProfile(ClaimsPrincipal User, UpdateInstructorProfileDTO instructorProfileDto);
}