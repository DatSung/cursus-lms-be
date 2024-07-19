using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5a42b7d-ddc4-47b4-b089-2fcd650eb3a7", new DateTime(2024, 7, 19, 3, 51, 27, 172, DateTimeKind.Utc).AddTicks(7271), "AQAAAAIAAYagAAAAEAME6aN31+yObHRXFMsBYU3QQ9Ftmq/MByZXn7942F2EKw06CU8jmjt2knQXtEJr/Q==", "9f0729a2-226b-402f-b003-00eb890dc715" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("380766a8-9a0e-40c4-8729-4e20d7b3d095"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("655a9238-d893-4655-88b2-d7b3d76b47f2"), "Dear [UserFullName],<br><br>Your account has been deleted.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Delete Account", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Delete Account!", "DeleteAccount", null, null },
                    { new Guid("7c9e3886-d7a0-4696-b72e-78b2a0e6974e"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("ad5e88da-badc-42cc-9081-7c55fb554179"), "Dear {FirstName} {LastName},<br><br>\r\n\r\n                    This email confirms that your payout request has been processed successfully.\r\n                    <br>\r\n                    <strong>Payout Details:</strong>\r\n                    <ul>\r\n                    <li>Amount: {PayoutAmount}</li>\r\n                    <li>Transaction Date: {TransactionDate}</li> \r\n                    </ul>\r\n                    <br>\r\n                    You can view your payout history in your instructor dashboard. \r\n                    <br> \r\n                    Thank you for being a valued Cursus instructor!\r\n                    <br>", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Payout", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}, {PayoutAmount}, {TransactionDate}", "Payout Successful!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your Cursus Payout is Complete!", "NotifyInstructorPaymentReceived", null, null },
                    { new Guid("b29c433c-870f-4f2a-9817-c9e3fedad585"), "Dear [UserFullName],<br><br>Your account will be deleted after 14 days.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Course completed", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Congratulations on completing the course!", "StudentCompleteCourse", null, null },
                    { new Guid("b98312f9-c7b8-41a9-8d49-2b03f49f7bbb"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("d6ff350a-db7e-419d-be06-d434eb750160"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("da4ebfa9-a8db-46c2-8d8a-339dfcb7f844"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("df6f0d22-0bfa-4289-bdc1-e2615f76490d"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Student", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("f7440dc1-69c9-4513-b56d-cff24bbcb86e"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("fa7ddc4d-3de3-47f5-96ba-f3af71599d5d"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "https://cursuslms.xyz/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("fb20348b-ab63-447b-ba95-3a6820967466"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("fd8f1dc0-dbd6-47ca-92b2-598e63df0f1e"), "Dear [UserFullName],<br><br>You have completed our course program, you can take new courses to increase your knowledge and skills.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Remind Account", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Remind Delete Account!", "RemindDeleteAccount", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("380766a8-9a0e-40c4-8729-4e20d7b3d095"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("655a9238-d893-4655-88b2-d7b3d76b47f2"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7c9e3886-d7a0-4696-b72e-78b2a0e6974e"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("ad5e88da-badc-42cc-9081-7c55fb554179"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("b29c433c-870f-4f2a-9817-c9e3fedad585"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("b98312f9-c7b8-41a9-8d49-2b03f49f7bbb"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("d6ff350a-db7e-419d-be06-d434eb750160"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("da4ebfa9-a8db-46c2-8d8a-339dfcb7f844"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("df6f0d22-0bfa-4289-bdc1-e2615f76490d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("f7440dc1-69c9-4513-b56d-cff24bbcb86e"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("fa7ddc4d-3de3-47f5-96ba-f3af71599d5d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("fb20348b-ab63-447b-ba95-3a6820967466"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("fd8f1dc0-dbd6-47ca-92b2-598e63df0f1e"));

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
    }
}
