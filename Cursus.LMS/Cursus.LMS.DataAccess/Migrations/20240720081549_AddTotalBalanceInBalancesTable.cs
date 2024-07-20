using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalBalanceInBalancesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "TotalBalance",
                table: "Balances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe058cd1-48f0-4a7e-8738-96f363865b25", new DateTime(2024, 7, 20, 8, 15, 46, 339, DateTimeKind.Utc).AddTicks(1191), "AQAAAAIAAYagAAAAEB/kCplr74/SMMQrY/RtiIAlEQmkFnq8S3qlqpiedFPvtEpRFVZ5YSvymGV6XodAqg==", "0f0e5fb7-3995-4db8-a661-5dbbacb43430" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("073ae630-555b-4f2e-bf50-12a2276f2925"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("16b40aa8-9ebb-427f-a247-1714b45419a6"), "Dear {FirstName} {LastName},<br><br>\r\n\r\n                    This email confirms that your payout request has been processed successfully.\r\n                    <br>\r\n                    <strong>Payout Details:</strong>\r\n                    <ul>\r\n                    <li>Amount: {PayoutAmount}</li>\r\n                    <li>Transaction Date: {TransactionDate}</li> \r\n                    </ul>\r\n                    <br>\r\n                    You can view your payout history in your instructor dashboard. \r\n                    <br> \r\n                    Thank you for being a valued Cursus instructor!\r\n                    <br>", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Payout", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}, {PayoutAmount}, {TransactionDate}", "Payout Successful!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your Cursus Payout is Complete!", "NotifyInstructorPaymentReceived", null, null },
                    { new Guid("1d8fc025-ea54-4218-80ee-16a5d8c5de47"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("1e459975-178b-4df1-99bb-72fb22c43bf6"), "Dear [UserFullName],<br><br>Your account has been deleted.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Delete Account", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Delete Account!", "DeleteAccount", null, null },
                    { new Guid("394ff7af-8f32-470d-a477-0a3e84602a8a"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("88ecdd32-a189-496b-ab7e-69bafdb77326"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "https://cursuslms.xyz/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("a20fb19e-58f5-4af7-9d40-bf1d6993a80a"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("a5ddfa6a-a17a-4e17-b703-ca591d1c53be"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("b05f1696-6c10-4158-bdbd-092b01709e54"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Student", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("c27549d3-3b62-4538-8b48-321d8f6b63a4"), "Dear [UserFullName],<br><br>Your account will be deleted after 14 days.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Course completed", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Congratulations on completing the course!", "StudentCompleteCourse", null, null },
                    { new Guid("c2d0806c-19bf-40fe-b977-a5d3b297ad65"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("d335353e-2f61-4b2f-87df-292dbb00c8e1"), "Dear [UserFullName],<br><br>You have completed our course program, you can take new courses to increase your knowledge and skills.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Remind Account", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Remind Delete Account!", "RemindDeleteAccount", null, null },
                    { new Guid("e72e2033-846e-4437-b946-2a2b6c161ce8"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("073ae630-555b-4f2e-bf50-12a2276f2925"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("16b40aa8-9ebb-427f-a247-1714b45419a6"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("1d8fc025-ea54-4218-80ee-16a5d8c5de47"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("1e459975-178b-4df1-99bb-72fb22c43bf6"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("394ff7af-8f32-470d-a477-0a3e84602a8a"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("88ecdd32-a189-496b-ab7e-69bafdb77326"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a20fb19e-58f5-4af7-9d40-bf1d6993a80a"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a5ddfa6a-a17a-4e17-b703-ca591d1c53be"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("b05f1696-6c10-4158-bdbd-092b01709e54"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c27549d3-3b62-4538-8b48-321d8f6b63a4"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c2d0806c-19bf-40fe-b977-a5d3b297ad65"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("d335353e-2f61-4b2f-87df-292dbb00c8e1"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("e72e2033-846e-4437-b946-2a2b6c161ce8"));

            migrationBuilder.DropColumn(
                name: "TotalBalance",
                table: "Balances");

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
    }
}
