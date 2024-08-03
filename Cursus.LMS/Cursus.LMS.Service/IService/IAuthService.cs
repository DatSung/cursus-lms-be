using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Service.IService;

public interface IAuthService
{
    Task<ResponseDTO> SignUpStudent(RegisterStudentDTO registerStudentDTO);
    Task<ResponseDTO> SignUpInstructor(SignUpInstructorDTO signUpInstructorDto);
    Task<ResponseDTO> UploadInstructorDegree(IFormFile file, ClaimsPrincipal user);
    Task<ResponseDTO> UploadUserAvatar(IFormFile file, ClaimsPrincipal user);
    Task<DegreeResponseDTO> GetInstructorDegree(ClaimsPrincipal user);
    Task<MemoryStream> GetUserAvatar(ClaimsPrincipal user);
    Task<ResponseDTO> SignIn(SignDTO signDto);
    Task<ResponseDTO> ForgotPassword(ForgotPasswordDTO forgotPasswordDto);
    Task<ResponseDTO> Refresh(string token);
    Task<ResponseDTO> ResetPassword(string resetPasswordDto, string token, string password);
    Task<ResponseDTO> ChangePassword(string userId, string oldPassword, string newPassword, string confirmNewPassword);
    Task<ResponseDTO> SendVerifyEmail(string email, string confirmationLink);
    Task<ResponseDTO> VerifyEmail(string userId, string token);
    Task<ResponseDTO> CheckEmailExist(string email);
    Task<ResponseDTO> CheckPhoneNumberExist(string phoneNumber);
    Task<ResponseDTO> SignInByGoogle(SignInByGoogleDTO signInByGoogleDto);
    Task<ResponseDTO> CompleteStudentProfile(ClaimsPrincipal User, CompleteStudentProfileDTO studentProfileDto);
    Task<ResponseDTO> CompleteInstructorProfile(ClaimsPrincipal User, CompleteInstructorProfileDTO instructorProfileDto);
    Task<ResponseDTO> GetUserInfo(ClaimsPrincipal User);
    Task<MemoryStream> DisplayUserAvatar(string userId);
    Task<DegreeResponseDTO> DisplayInstructorDegree(string userId);
    Task<ResponseDTO> UpdateStudent(UpdateStudentProfileDTO updateStudentDto, ClaimsPrincipal User);
    Task<ResponseDTO> UpdateInstructor(UpdateIntructorProfileDTO updateIntructorDto, ClaimsPrincipal User);
    Task<ResponseDTO> LockUser(LockUserDTO lockUserDto);
    Task<ResponseDTO> UnlockUser(LockUserDTO lockUserDto);
    Task SendClearEmail(int fromMonth);
    Task ClearUser();
}