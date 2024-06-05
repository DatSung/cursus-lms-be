using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailService _emailService;

        public EmailSender(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// This method for sending verify email with template
        /// </summary>
        /// <param name="toMail">Email of user to be send</param>
        /// <param name="confirmationLink">Link url to the controller to confirm email action</param>
        /// <returns></returns>
        public async Task<bool> SendVerifyEmail(string toMail, string confirmationLink)
        {
            string subject = "[Curcus Verify Email for User]";
            string body = $@"
            <html>
            <body>
                <h1>CURSUS VERIFY EMAIL</h1>
                <h2>-User Account Verified!</h2>
                <p>Thank you for registering your Cursus account. Click here to go back the page</p>
                <p><a href='{confirmationLink}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>
            </body>
            </html>";

            return await _emailService.SendEmailAsync(toMail, subject, body);
        }

        public async Task<bool> SendEmailForInstructorApproval(string toMail, string token)
        {
            string subject = "[Circus Verify Email For Instructor Approval]";
            string body = $@"
            <html>
            <body>
                <h1>CURSUS VERIFY EMAIL FOR INSTRUCTOR APPROVAL</h1>
                <h2>-Your Account has been aprroval!</h2>
                <p>Thank you for your waiting! Click this to go to the main page</p>
                <p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>
            </body>
            </html>";

            return await _emailService.SendEmailAsync(toMail, subject, body);
        }
    }
}