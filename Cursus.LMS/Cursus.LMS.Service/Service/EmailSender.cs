using Cursus.LMS.Service.IService;
using Cursus.LMS.DataAccess.IRepository;
using Microsoft.Extensions.Configuration;
using Cursus.LMS.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace Cursus.LMS.Service.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public EmailSender(IConfiguration configuration, IEmailService emailService, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _configuration = configuration;
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

            return await _emailService.SendEmailInactiveCourseAsync(instructorEmail, studentEmail, subject, body);
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

            return await _emailService.SendEmailAsync(toMail, subject, body);
        }
        /// <summary>
        /// Generic method for sending email based on template
        /// </summary>
        /// <param name="toMail">Email of recipient</param>
        /// <param name="templateName">Name of the email template</param>
        /// <param name="replacementValue">Value to replace in the template (like link or token)</param>
        /// <returns></returns>
        public async Task<bool> SendEmailForAdminAboutNewCourse(string toMail)
        {
            // Truy vấn cơ sở dữ liệu để lấy template
            var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "NotificationForAdminAboutNewCourse");
            var courseStatus = await _unitOfWork.CourseVersionRepository.GetAsync(z => z.CurrentStatus == 0);
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
                <p>The new course status: {courseStatus.CurrentStatus}</p>
                {template.FooterContent}
            </body>
            </html>";

            return await _emailService.SendEmailAsync(toMail, subject, body);
        }

        /// <summary>
        /// Generic method for sending email based on template
        /// </summary>
        /// <param name="toMail">Email of recipient</param>
        /// <param name="templateName">Name of the email template</param>
        /// <param name="replacementValue">Value to replace in the template (like link or token)</param>
        /// <returns></returns>
        public async Task<bool> SendApproveEmailForInstructorAboutNewCourse(string toMail)
        {
            // Truy vấn cơ sở dữ liệu để lấy template
            var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "ApproveInstructorCourse");
            var courseStatus = await _unitOfWork.CourseVersionRepository.GetAsync(z => z.CurrentStatus == 0);
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
                <p>The new course status: {courseStatus.CurrentStatus}</p>
                {template.FooterContent}
            </body>
            </html>";

            return await _emailService.SendEmailAsync(toMail, subject, body);
        }

        /// <summary>
        /// Generic method for sending email based on template
        /// </summary>
        /// <param name="toMail">Email of recipient</param>
        /// <param name="templateName">Name of the email template</param>
        /// <param name="replacementValue">Value to replace in the template (like link or token)</param>
        /// <returns></returns>
        public async Task<bool> SendRejectEmailForInstructorAboutNewCourse(string toMail)
        {
            // Truy vấn cơ sở dữ liệu để lấy template
            var template = await _unitOfWork.EmailTemplateRepository.GetAsync(t => t.TemplateName == "RejectInstructorCourse");
            var courseStatus = await _unitOfWork.CourseVersionRepository.GetAsync(z => z.CurrentStatus == 0);
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
                <p>{courseStatus.CurrentStatus}New</p>
                {template.FooterContent}
            </body>
            </html>";

            return await _emailService.SendEmailAsync(toMail, subject, body);
        }

        public Task<bool> SendEmailForInstructorApproval(string toMail, Guid instructorId)
        {
            throw new NotImplementedException();
        }
    }
}