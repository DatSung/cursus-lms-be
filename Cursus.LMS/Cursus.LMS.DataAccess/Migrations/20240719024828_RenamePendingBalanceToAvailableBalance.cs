using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenamePendingBalanceToAvailableBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("2b14568f-1fe3-4029-8a76-9e95e52484c5"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("45e0dd0c-cb6d-419d-8234-f69d2ae297bd"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("77efd8d1-70b1-4a96-b31a-a42b3da51082"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7ba6c847-f51e-4900-8de7-18b3715758d7"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("8d40eac2-b033-4f24-9cbb-ff41af9513e9"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("9dee3b47-1066-409d-8e8a-210af4931098"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("aebce6d2-3e22-4e08-ad71-4b8538c35a8c"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c6abd686-28d5-4a14-9f7f-6ec115fe8618"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c78e103b-9447-4786-bb90-9f89f6d5cbb6"));

            migrationBuilder.RenameColumn(
                name: "PendingBalance",
                table: "Balances",
                newName: "PayoutBalance");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0fae2dd-74cf-48da-988a-0d305f1b1e8d", new DateTime(2024, 7, 19, 2, 48, 27, 141, DateTimeKind.Utc).AddTicks(7232), "AQAAAAIAAYagAAAAEPobb/K/hhF5cxLOEjKpey3IBCykW6pUlFy5HQQ9aXXzTyis3OOpHBOL0Bxyfndzzg==", "2b48fed6-c686-4238-900a-6d8f77910e94" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("008aded6-84a4-4fb4-a7e7-02962f2f807e"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "https://cursuslms.xyz/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("02f42c81-00e2-41ca-ae15-63d04062358e"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("25e07fdc-9235-4865-a857-2e11c4001f41"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("33c62f98-8bee-4bd7-8ce1-6b0bc25bd896"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("653d01e6-b9da-41a0-826c-85000b562d44"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("bbc76bc8-42e6-4b68-b966-e5e15aded4b4"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("c0a66223-5dbc-4db5-a2ce-08a7c1ffe774"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("c5490e9e-a34a-4de1-a830-e97f96c3c88f"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("e18f6b6d-ff10-45c6-b5e5-bf2fc68dd8a3"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("008aded6-84a4-4fb4-a7e7-02962f2f807e"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("02f42c81-00e2-41ca-ae15-63d04062358e"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("25e07fdc-9235-4865-a857-2e11c4001f41"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("33c62f98-8bee-4bd7-8ce1-6b0bc25bd896"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("653d01e6-b9da-41a0-826c-85000b562d44"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("bbc76bc8-42e6-4b68-b966-e5e15aded4b4"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c0a66223-5dbc-4db5-a2ce-08a7c1ffe774"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c5490e9e-a34a-4de1-a830-e97f96c3c88f"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("e18f6b6d-ff10-45c6-b5e5-bf2fc68dd8a3"));

            migrationBuilder.RenameColumn(
                name: "PayoutBalance",
                table: "Balances",
                newName: "PendingBalance");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7effd55-5911-450f-9d51-3cff8fccf922", new DateTime(2024, 7, 19, 1, 59, 42, 7, DateTimeKind.Utc).AddTicks(6321), "AQAAAAIAAYagAAAAEIijpmYA5nWmMvZGUHhvAheH6LfvvO9RvFjX70IJ3K1iTxgg+vXF1XSssAawby6pqg==", "913166e2-b72b-45f6-949c-7c2054217860" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("2b14568f-1fe3-4029-8a76-9e95e52484c5"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("45e0dd0c-cb6d-419d-8234-f69d2ae297bd"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("77efd8d1-70b1-4a96-b31a-a42b3da51082"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "https://cursuslms.xyz/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("7ba6c847-f51e-4900-8de7-18b3715758d7"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("8d40eac2-b033-4f24-9cbb-ff41af9513e9"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("9dee3b47-1066-409d-8e8a-210af4931098"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("aebce6d2-3e22-4e08-ad71-4b8538c35a8c"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("c6abd686-28d5-4a14-9f7f-6ec115fe8618"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("c78e103b-9447-4786-bb90-9f89f6d5cbb6"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null }
                });
        }
    }
}
