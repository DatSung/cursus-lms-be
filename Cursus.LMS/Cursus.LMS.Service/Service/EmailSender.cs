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

        public async Task<bool> SendVerifyEmail(string toMail, string confirmationLink)
        {
            string subject = "[Curcus Verify Email for Student]";
            string body = $@"
            <html>
            <body>
                <h1>CURSUS VERIFY EMAIL</h1>
                <h2>-Student Account Verified!</h2>
                <p>Thank you for registering your Cursus account. Click here to go back the page</p>
                <p><a href='{confirmationLink}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>
            </body>
            </html>";

            return await _emailService.SendEmailAsync(toMail, subject, body);
        }

        public async Task<bool> SendEmailForInstructor(string toMail, string token)
        {
            string subject = "[Curcus Verify Email For Instructor]";
            string body = $@"
            <html>
            <body>
                <h1>CURSUS VERIFY EMAIL FOR Instructor</h1>
                <h2>-Instructor Account Verified</h2>
                <p>Thank you for registering your Cursus account. Your result will be show after 24h. Click here to go back the page</p>
                <p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>
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

        // private bool SendEmailInternal(string toMail, string subject, string body, string fromMail, string fromPassword)
        // {
        //     try
        //     {
        //         using (MailMessage mail = new MailMessage())
        //         {
        //             mail.From = new MailAddress(fromMail);
        //             mail.To.Add(toMail);
        //             mail.Subject = subject;
        //             mail.Body = body;
        //             mail.IsBodyHtml = true;
        //
        //             using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
        //             {
        //                 smtp.Credentials = new NetworkCredential(fromMail, fromPassword);
        //                 smtp.EnableSsl = true;
        //                 smtp.Send(mail);
        //             }
        //         }
        //
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error sending email: {ex.Message}");
        //         return false;
        //     }
        // }

        // private string GenerateRandomToken()
        // {
        //     var token = new StringBuilder();
        //     var random = new Random();
        //     const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //     for (int i = 0; i < 20; i++)
        //     {
        //         token.Append(chars[random.Next(chars.Length)]);
        //     }
        //
        //     return token.ToString();
        // }
    }
}