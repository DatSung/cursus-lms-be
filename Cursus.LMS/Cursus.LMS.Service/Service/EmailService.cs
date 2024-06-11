using System.Net;
using System.Net.Mail;
using Cursus.LMS.Model.Domain;
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

    public async Task<bool> SendEmailResetAsync(string toEmail, string subject, ApplicationUser user, string currentDate, string resetLink,
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
    
}