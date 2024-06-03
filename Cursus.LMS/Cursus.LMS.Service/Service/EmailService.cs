using System.Net;
using System.Net.Mail;
using Cursus.LMS.Service.IService;
using Microsoft.Extensions.Configuration;

namespace Cursus.LMS.Service.Service;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        // Lấy thông tin cấu hình email từ file appsettings.json
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
    }
}