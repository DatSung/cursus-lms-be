using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.Extensions.Configuration;
using Cursus.LMS.DataAccess.IRepository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace Cursus.LMS.Service.Service;

public class EmailService : IEmailService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmailService(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _configuration = configuration;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetAll(
        ClaimsPrincipal User, 
        string? filterOn, 
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize)
    {
        #region MyRegion

        try
        {
            List<EmailTemplate> emailTemplates = new List<EmailTemplate>();

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "templatename":
                    {
                        emailTemplates = _unitOfWork.EmailTemplateRepository.GetAllAsync()
                            .GetAwaiter().GetResult().Where(x => x.TemplateName.Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                   
                    default:
                    {
                        emailTemplates = _unitOfWork.EmailTemplateRepository.GetAllAsync()
                            .GetAwaiter().GetResult().ToList();
                        break;
                    }
                }
            }
            else
            {
                emailTemplates = _unitOfWork.EmailTemplateRepository.GetAllAsync()
                    .GetAwaiter().GetResult().ToList();
            }

            // Sort Query
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "templatename":
                    {
                        emailTemplates = isAscending == true
                            ? [.. emailTemplates.OrderBy(x => x.TemplateName)]
                            : [.. emailTemplates.OrderByDescending(x => x.TemplateName)];
                        break;
                    }
                    case "sendername":
                    {
                        emailTemplates = isAscending == true
                            ? [.. emailTemplates.OrderBy(x => x.SenderName)]
                            : [.. emailTemplates.OrderByDescending(x => x.SenderName)];
                        break;
                    }
                    case "senderemail":
                    {
                        emailTemplates = isAscending == true
                            ? [.. emailTemplates.OrderBy(x => x.SenderEmail)]
                            : [.. emailTemplates.OrderByDescending(x => x.SenderEmail)];
                        break;
                    }
                    case "category":
                    {
                        emailTemplates = isAscending == true
                            ? [.. emailTemplates.OrderBy(x => x.Category)]
                            : [.. emailTemplates.OrderByDescending(x => x.Category)];
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            // Pagination
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                emailTemplates = emailTemplates.Skip(skipResult).Take(pageSize).ToList();
            }

            #endregion Query Parameters

            if (emailTemplates.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "There are no emailTemplates",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var instructorInfoLiteDto = _mapper.Map<List<EmailTemplate>>(emailTemplates);

            return new ResponseDTO()
            {
                Message = "Get all email template successfully",
                Result = instructorInfoLiteDto,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }
    
    /// <summary>
    /// Generic method for sending email based on template
    /// </summary>
    /// <param name="toMail">Email of recipient</param>
    /// <param name="templateName">Name of the email template</param>
    /// <param name="replacementValue">Value to replace in the template (like link or token)</param>
    /// <returns></returns>
    private async Task<bool> SendEmailFromTemplate(string toMail, string templateName, string replacementValue)
    {
        // Truy vấn cơ sở dữ liệu để lấy template
        var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == templateName);

        if (template == null)
        {
            // Xử lý khi template không tồn tại
            throw new Exception("Email template not found");
        }

        // Sử dụng thông tin từ template để tạo email
        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent}</p>
                <p><a href='{replacementValue}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>{template.CallToAction.Replace("{Login}", replacementValue)}</a></p>
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailAsync(toMail, subject, body);
    }
    
    private async Task<bool> SendEmailInactiveCourseTemplate(string studentEmail, string templateName, string instructorEmail, string instructorName, string courseTitle)
    {
        var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == templateName);

        if (template == null)
        {
            throw new Exception("Email template not found");
        }
            
        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent.Replace("{courseTitle}", courseTitle).Replace("instructorName", instructorName)}</p>
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailInactiveCourseAsync(instructorEmail, studentEmail, subject, body);
    }
    
    public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
    {
        // Lấy thông tin cấu hình email từ file appsettings.json
        try
        {
            var fromEmail = _configuration["EmailSettings:FromEmail"];
            var fromPassword = _configuration["EmailSettings:FromPassword"];
            var smtpHost = _configuration["EmailSettings:SmtpHost"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);

            // Tạo đối tượng MailMessage
            var message = new MailMessage(fromEmail, toEmail, subject, body);
            message.IsBodyHtml = true;

            // Tạo đối tượng SmtpClient và gửi email
            using var smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };
            await smtpClient.SendMailAsync(message);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    
    // Send Email Inactive Course
    public async Task<bool> SendEmailInactiveCourseAsync(string instructorEmail, string studentEmail, string subject, string body)
    {
        try
        {
            var fromPassword = _configuration["EmailSettings:FromPassword"];
            var smtpHost = _configuration["EmailSettings:SmtpHost"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            
            var message = new MailMessage(instructorEmail, studentEmail, subject, body);
            message.IsBodyHtml = true;
            
            using var smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(instructorEmail, fromPassword),
                EnableSsl = true
            };
            await smtpClient.SendMailAsync(message);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> SendEmailResetAsync(string toEmail, string subject, ApplicationUser user,
        string currentDate, string resetLink,
        string operatingSystem, string browser, string ip, string region, string city, string country)
    {
        // Lấy thông tin cấu hình email từ file appsettings.json
        try
        {
            var fromEmail = _configuration["EmailSettings:FromEmail"];
            var fromPassword = _configuration["EmailSettings:FromPassword"];
            var smtpHost = _configuration["EmailSettings:SmtpHost"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);

            var body = $@"
<table style=""width: 720px; margin: 0 auto;"">
    <tr>
        <td align=""left""><img src=""https://demo.stripocdn.email/content/guids/videoImgGuid/images/group_48_CGo.png"" alt=""Cursus Logo"" style=""display: block"" height=""37"" title=""Logo"" /></td>
        <td align=""center""><h2 style=""font-size: 16px"">{currentDate}</h2></td>
        <td align=""right"">
           <div>   
                <a target=""_blank"" href=""#""><img title=""Facebook"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-black/facebook-logo-black.png"" alt=""Facebook"" width=""24"" height=""24"" /></a>           
                <a target=""_blank"" href=""#""><img title=""Twitter"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-black/twitter-logo-black.png"" alt=""Twitter"" width=""24"" height=""24"" /></a>           
                <a target=""_blank"" href=""#""><img title=""Instagram"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-black/instagram-logo-black.png"" alt=""Instagram"" width=""24"" height=""24"" /></a>           
                <a target=""_blank"" href=""#""><img title=""Youtube"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-black/youtube-logo-black.png"" alt=""Youtube"" width=""24"" height=""24"" /></a>
           </div>
        </td>
    </tr>
</table>

<div style=""width: 720px; margin: 0 auto;"">
    <div style=""text-align: -webkit-center;"">
        <img src=""https://demo.stripocdn.email/content/guids/videoImgGuid/images/5184834_EjS.png"" alt=""Reset Image"" style=""display: block;"" title=""Reset Image"" width=""560"">
    </div>
    <div>
        <h2 style=""line-height: 120%;"">Forgot Your Password ?</h2>
        <p style=""font-size: 16px; line-height: 120%;"">Hi <strong>{user.FullName}</strong>,<br><br>We’ve received a request to reset the password for the Cursus account associated with <strong>{user.UserName}</strong>. No changes have been made to your account yet. This password reset is only valid for the next 24 hours.<br><br>You can reset your password by clicking the link button below:</p>
        <div style=""text-align: center; margin-bottom: 40px; margin-top: 40px;"">
            <button style=""background: #26c662; border-radius: 5px; border: none; padding: 10px 20px;"">
                <a href=""{resetLink}"" target=""_blank"" style=""color: rgb(255, 255, 255); background: rgb(38, 198, 98); border-radius: 5px; text-decoration: none;"">RESET YOUR PASSWORD</a>
            </button>
        </div>
    </div>
    <div>
        <p style=""font-size: 16px; line-height: 120%;"">For security, this request was received from a <span style=""color: blue; font-weight: bold;"">{operatingSystem}</span> device using <span style=""color: blue; font-weight: bold;"">{browser}</span> have IP address is <span style=""color: blue; font-weight: bold;"">{ip}</span> at location <span style=""color: blue; font-weight: bold;"">{region}</span>, <span style=""color: blue; font-weight: bold;"">{city}</span>, <span style=""color: blue; font-weight: bold;"">{country}</span>. If you did not request a password reset, please ignore this email or contact support if you have questions.<br><br></p><p style=""font-size: 16px; line-height: 120%;"">Thanks,</p><p style=""font-size: 16px; line-height: 120%;"">The Cursus Team</p></td>
    </div>
    <div style=""background-color: #f6f6f6;"">
        <div style=""padding-top: 10px; "">
            <h2 style=""padding-left: 20px;"" ;><strong>Questions? We have people</strong></h2>
        </div>
        <div style=""text-align: center; padding-top: 20px;"">

<table style=""width: 720px; margin: 0 auto; padding-bottom: 10px;"">
    <tr>
        <td align=""center"">
           <div style=""background-color: white; width: 273px; border-radius: 10px; text-align: center; padding-top: 1px; padding-bottom: 1px;"">
              <h2 style=""color: #666666;""><strong>Call</strong></h2>
              <a target=""_blank"" href=""#""><img src=""https://tlr.stripocdn.email/content/guids/CABINET_2af5bc24a97b758207855506115773ae/images/73661620310209153.png"" alt=""Phone""  width=""20""></a>
              <p style=""margin-top: 5px;""><a target=""_blank"" style=""color: #666666; text-decoration: none;"" href=""tel:"">(+84) 0329 - 258 - 953&nbsp;</a></p>
           </div>
        </td>
        <td align=""center"">
           <div style=""background-color: white; width: 273px; border-radius: 10px; text-align: center; padding-top: 1px; padding-bottom: 1px;"">
              <h2 style=""color: #666666;""><strong>Reply</strong></h2>
              <a target=""_blank"" href=""#""><img src=""https://tlr.stripocdn.email/content/guids/CABINET_2af5bc24a97b758207855506115773ae/images/16961620310208834.png"" alt=""Email""  width=""20""></a>
              <p style=""margin-top: 5px;""><a target=""_blank"" href=""mailto:cursusservicetts@email.com"" style=""color: #666666; text-decoration: none;"">cursusservicetts@gmail.com</a></p>
           </div>
        </td>
    </tr>
</table>
 
            <p style=""padding-top: 10px; padding-bottom: 20px;"">Monday - Friday, 8 am - 6 pm est</p>
        </div>                       
    </div>    
    <div style=""background-color: #26c662; "">
        <div style=""text-align: center; padding-top: 30px;"">
            <a target=""_blank"" href=""mailto:cursusservicetts@email.com"" style=""color: #ffffff; text-decoration: none; padding-right: 20px;"">About us</a>
            <a target=""_blank"" href=""#"" style=""color: #ffffff; text-decoration: none; padding-right: 20px;"">Blog</a>
            <a target=""_blank"" href=""#"" style=""color: #ffffff; text-decoration: none; padding-right: 20px;"">Career</a>
            <a target=""_blank"" href=""#"" style=""color: #ffffff; text-decoration: none;"">News</a>
        </div>
        <div style=""text-align: center; padding-top: 20px;"">            
            <a style=""padding: 20px;"" target=""_blank"" href=""#""><img title=""Facebook"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-white/facebook-logo-white.png"" alt=""Facebook"" width=""24"" height=""24""></a>
            <a style=""padding: 20px;"" target=""_blank"" href=""#""><img title=""Twitter"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-white/twitter-logo-white.png"" alt=""Twitter"" width=""24"" height=""24""></a>
            <a style=""padding: 20px;"" target=""_blank"" href=""#""><img title=""Instagram"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-white/instagram-logo-white.png"" alt=""Instagram"" width=""24"" height=""24""></a>
            <a style=""padding: 20px; align-self: center;"" target=""_blank"" href=""#""><img title=""Youtube"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-white/youtube-logo-white.png"" alt=""Youtube"" width=""24"" height=""24""></a>          
        </div>
        <div>
            <p style=""font-size: 12px; text-align: center; color: #ffffff;padding: 10px 50px 30px 50px"">You are receiving this email because you have visited our site or asked us about the regular newsletter. Make sure our messages get to your Inbox (and not your bulk or junk folders).<br>
            <a target=""_blank"" style=""font-size: 12px; color: #ffffff;"" href=""#"">Privacy police</a> | <a target=""_blank"" style=""font-size: 12px; color: #ffffff;"">Unsubscribe</a></p>
        </div>
    </div>  
</div>";

            // Tạo đối tượng MailMessage
            var message = new MailMessage(fromEmail, toEmail, subject, body);
            message.IsBodyHtml = true;

            // Tạo đối tượng SmtpClient và gửi email
            using var smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };
            await smtpClient.SendMailAsync(message);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    /// <summary>
    /// This method for sending verify email with template
    /// </summary>
    /// <param name="toMail">Email of user to be send</param>
    /// <param name="confirmationLink">Link url to the controller to confirm email action</param>
    /// <returns></returns>
    public async Task<bool> SendVerifyEmail(string toMail, string confirmationLink)
    {
        return await SendEmailFromTemplate(toMail, "SendVerifyEmail", confirmationLink);
    }
    
    /// <summary>
    /// This method for sending email for instructor approval with template
    /// </summary>
    /// <param name="toMail">Email of instructor to be send</param>
    /// <param name="token">Token for the instructor</param>
    /// <returns></returns>
    public async Task<bool> SendEmailForInstructorApproval(string toMail, string token)
    {
        return await SendEmailFromTemplate(toMail, "InstructorApprovalEmail", token);
    }
    
    // Send email for all student enroll into inactive courses
    public async Task<bool> SendEmailInactiveCourse(string instructorEmail, string instructorName, string courseTitle, List<string> studentEmails)
    {
        try
        {
            foreach (var studentEmail in studentEmails)
            {
                await SendEmailInactiveCourseTemplate(studentEmail, "InactiveCourseEmail", instructorEmail, instructorName, courseTitle);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    /// <summary>
    /// Send Email For Admin Abou tNew Course
    /// </summary>
    /// <param name="toMail">Email of recipient</param>
    /// <param name="templateName">Name of the email template</param>
    /// <param name="replacementValue">Value to replace in the template (like link or token)</param>
    /// <returns></returns>
    public async Task<bool> SendEmailForAdminAboutNewCourse(string toMail)
    {
        var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "NotificationForAdminAboutNewCourse");
        var courseStatus = await _unitOfWork.CourseVersionRepository.GetAsync(z => z.CurrentStatus == 0);
        if (template == null)
        {
            throw new Exception("Email template not found");
        }
        
        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent}</p>
                <p>The new course status: {courseStatus.CurrentStatus}</p>
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailAsync(toMail, subject, body);
    }

    /// <summary>
    /// Send Email For Admin Abou tNew Course
    /// </summary>
    /// <param name="toMail">Email of recipient</param>
    /// <param name="templateName">Name of the email template</param>
    /// <param name="replacementValue">Value to replace in the template (like link or token)</param>
    /// <returns></returns>
    public async Task<bool> SendEmailForStudentAboutCompleteCourse(string toMail)
    {
        var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "StudentCompletedCourse");
        var courseStatus = await _unitOfWork.CourseVersionRepository.GetAsync(z => z.CurrentStatus == 0);
        if (template == null)
        {
            throw new Exception("Email template not found");
        }

        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent}</p>
                <p>The new course status: {courseStatus.CurrentStatus}</p>
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailAsync(toMail, subject, body);
    }

    /// <summary>
    /// Send Approv eEmail For Instructor About New Course
    /// </summary>
    /// <param name="toMail">Email of recipient</param>
    /// <returns></returns>
    public async Task<bool> SendApproveEmailForInstructorAboutNewCourse(string toMail)
    {
        var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "ApproveInstructorCourse");
        var courseStatus = await _unitOfWork.CourseVersionRepository.GetAsync(z => z.CurrentStatus == 0);
        if (template == null)
        {
            throw new Exception("Email template not found");
        }
        
        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent}</p>
                <p>The new course status: {courseStatus.CurrentStatus}</p>
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailAsync(toMail, subject, body);
    }
    
    /// <summary>
    /// Send Reject Email For Instructor About New Course
    /// </summary>
    /// <param name="toMail">Email of recipient</param>
    /// <returns></returns>
    public async Task<bool> SendRejectEmailForInstructorAboutNewCourse(string toMail)
    {
        var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "RejectInstructorCourse");
        var courseStatus = await _unitOfWork.CourseVersionRepository.GetAsync(z => z.CurrentStatus == 0);
        if (template == null)
        {
            throw new Exception("Email template not found");
        }
        
        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent}</p>
                <p>{courseStatus.CurrentStatus}New</p>
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailAsync(toMail, subject, body);
    }
    
    /// <summary>
    /// Sends a reminder email for account deletion
    /// </summary>
    /// <param name="toMail">Email of recipient</param>
    /// <returns></returns>
    public async Task<bool> SendEmailRemindDeleteAccount(string toMail)
    {
        var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "RemindDeleteAccount");
        if (template == null)
        {
            throw new Exception("Email template not found");
        }
        
        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent}</p>
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailAsync(toMail, subject, body);
    }
    
    /// <summary>
    /// Sends a email for account deletion
    /// </summary>
    /// <param name="toMail">Email of recipient</param>
    /// <returns></returns>
    public async Task<bool> SendEmailDeleteAccount(string toMail)
    {
        var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "DeleteAccount");
        if (template == null)
        {
            throw new Exception("Email template not found");
        }
        
        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent}</p>
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailAsync(toMail, subject, body);
    }

    /// <summary>
    /// Sends a email for payout of instructor
    /// </summary>
    /// <param name="toMail">Email of recipient</param>
    /// <param name="PayoutAmount">Transaction amount</param>
    /// <param name="TransactionDate">Transaction Date</param>
    /// <returns></returns>
    public async Task<bool> SendEmailToInstructorAfterPayout(string toMail, double PayoutAmount, DateTime TransactionDate)
    {
        var template =
            await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "NotifyInstructorPaymentReceived");
        if (template == null)
        {
            throw new Exception("Email template not found");
        }
        
        string subject = template.SubjectLine;
        string body = $@"
            <html>
            <body>
                <h1>{template.SubjectLine}</h1>
                <h2>{template.PreHeaderText}</h2>
                <p>{template.BodyContent}</p>
                {{template.BodyContent.Replace(""{{PayoutAmount}}"", PayoutAmount.ToString(""C""))
                                      .Replace(""{{TransactionDate}}"", TransactionDate.ToString(""d""))}}
                {template.FooterContent}
            </body>
            </html>";

        return await SendEmailAsync(toMail, subject, body);
    }
}