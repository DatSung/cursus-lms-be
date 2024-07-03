using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailTemplatesSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "TemplateName", "SenderName", "SenderEmail", "Category", "SubjectLine", "PreHeaderText", "PersonalizationTags", "BodyContent", "FooterContent", "CallToAction", "Language", "RecipientType", "CreateBy", "CreateTime", "UpdateBy", "UpdateTime", "Status" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "WelcomeEmail", "Cursus Team", "cursusservicetts@gmail.com", "Welcome", "Welcome to Cursus!", "Thank you for signing up!", "{FirstName}, {LastName}", "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<p>Contact us at cursusservicetts@gmail.com</p>", "<a href=\\\"https://cursuslms.azurewebsites.net/api/login\\\">Login</a>", "English", "Customer", "System", DateTime.Now, "Admin", DateTime.Now, 1 },
                    { Guid.NewGuid(), "ForgotPasswordEmail", "Cursus Team", "cursusservicetts@gmail.com", "Security", "Reset Your Password", "Reset your password to regain access", "[UserFullName], [ResetPasswordLink]", "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "If you did not request a password reset, please ignore this email.", $"https://cursuslms.azurewebsites.net/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "English", "Customer", "System", DateTime.Now, "Admin", DateTime.Now, 1 },  
                    { Guid.NewGuid(), "SendVerifyEmail", "Cursus Team", "cursusservicetts@gmail.com", "Verify", "Cursus Verify Email", "User Account Verified!", "{FirstName}, {LinkLogin}", "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<p>Contact us at cursusservicetts@gmail.com</p>", "<a href=\\\"{{Login}}\\\">Login now</a>", "English", "Customer", "System", DateTime.Now, "Admin", DateTime.Now, 1 },
                    { Guid.NewGuid(), "SendEmailForInstructorApproval", "Cursus Team", "cursusservicetts@gmail.com", "Approval", "Circus Verify Email For Instructor Approval", "Circus Verify Email For Instructor Approval", "{FirstName}, {LastName}", "<h2>-Your Account has been aprroval!</h2>", "<p>Thank you for your waiting! Click this to go to the main page</p>", $"<p><a href='http://bloodmoonrpg.carrd.co?token={{token}}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "English", "Instructor", "System", DateTime.Now, "Admin", DateTime.Now, 1 },
                    { Guid.NewGuid(), "SendEmailForInstructorApproval", "Cursus Team", "cursusservicetts@gmail.com", "Security", "Reset Your Password", "Reset your password to regain access.", "{FirstName}, {ResetLink}", "<p>Hello {FirstName},</p><p>Click <a href=\\\"{ResetLink}\\\">here</a> to reset your password.</p>", "<p>Contact us at cursusservicetts@gmail.com</p>", "<a href=\\\"{{ResetLink}}\\\">Reset Password</a>", "English", "Customer", "System", DateTime.Now, "Admin", DateTime.Now, 1 },
                    { Guid.NewGuid(), "InactiveCourseEmail", "Instructor", "instructor@gmail.com", "Notification", "Inactive Course", "Hello friends,", "{FullName}", "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<p>Contact us at cursusservicetts@gmail.com</p>", "<a href=\\\"{{LoginLink}}\\\">Login Now</a>", "English", "Customer", "System", DateTime.Now, "Admin", DateTime.Now, 1 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
