using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace Cursus.LMS.Service.Models
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Category { get; set; }
        public string SubjectLine { get; set; }
        public string PreHeaderText { get; set; }
        public string PersonalizationTags { get; set; }
        public string BodyContent { get; set; }
        public string FooterContent { get; set; }
        public string CallToAction { get; set; }
        public string Language { get; set; }
        public string RecipientType { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }

        public string BuildEmail(string recipientName, string confirmationLink = "", string token = "")
        {
            string emailBody = BodyContent;

            if (!string.IsNullOrEmpty(confirmationLink))
            {
                emailBody = emailBody.Replace("{confirmationLink}", confirmationLink);
            }

            if (!string.IsNullOrEmpty(token))
            {
                emailBody = emailBody.Replace("{token}", token);
            }

            emailBody = emailBody.Replace("{recipientName}", recipientName);

            string fullEmail = $@"
            <html>
            <body>
                <h1>{TemplateName}</h1>
                <p>{PreHeaderText}</p>
                {emailBody}
                <p>{FooterContent}</p>
                <p><a href='{CallToAction}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Action</a></p>
            </body>
            </html>";

            return fullEmail;
        }
    }

    public class EmailTemplateRepository
    {
        private readonly string _connectionString;

        public EmailTemplateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<EmailTemplate> GetEmailTemplateByNameAsync(string templateName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT TOP 1 *
                              FROM [Cursus_LMS_DB].[dbo].[EmailTemplates]
                              WHERE TemplateName = @TemplateName";
                return await connection.QuerySingleOrDefaultAsync<EmailTemplate>(query,
                    new { TemplateName = templateName });
            }
        }
    }
}