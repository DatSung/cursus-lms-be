using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCourseReportAndCourseReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("081c794e-567b-4443-9286-13cb698d30d2"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("11d90b0f-588d-40f7-8637-5e064734e13d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("201f211f-3ead-4269-9acf-ebd72cc5eb05"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("2f954a57-806d-441b-b80a-dfa7f3bf1b5d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("49b0fcc7-a967-4d4b-bc48-d29088f3ce55"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("9cc42316-e076-437a-9613-c07715831839"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("ae786c05-f9e5-48e6-b64f-47974bbe082c"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("d29c3a74-11cc-49b1-8a0e-aeefb1da7670"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("e96871e3-781b-46fb-81e1-e7bb614593e7"));

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "CourseReviews");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CourseReviews");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "CourseReports");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "CourseReports");

            migrationBuilder.DropColumn(
                name: "IsSent",
                table: "CourseReports");

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "CourseReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "CourseReviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CourseReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "CourseReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CourseReviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "CourseReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "CourseReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CourseReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "CourseReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CourseReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69151926-a093-4ce5-a07c-601d1fdc43c7", new DateTime(2024, 7, 12, 7, 43, 46, 626, DateTimeKind.Utc).AddTicks(868), "AQAAAAIAAYagAAAAEMmYNSaHBXOsqq6ofMcNvLbIq8JMFfcmpJEr1thHv4zHC+Y8Q/leZFbT5QDBHUgARQ==", "4d33ade3-d280-455f-b7c2-063fee2bd9b8" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreateBy", "CreateTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("2dce34ad-c1e4-4538-a6d9-e8a3840c85a1"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2462), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2463) },
                    { new Guid("31327de5-6f81-4f6c-af27-ca2b2bd7e75b"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2443), "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2444) },
                    { new Guid("3429c846-39cd-4da3-8dae-2f5915367ca5"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2458), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2459) },
                    { new Guid("39e1e71c-64d7-4eb9-a422-cca45e51c64e"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2466), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2467) },
                    { new Guid("631b1d3e-d10e-4bb5-a0c0-2152cb40e9e0"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2452), "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2454) },
                    { new Guid("6878b65f-422e-4208-9b51-bd41d5273778"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2448), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2449) },
                    { new Guid("92705a11-862c-4f3e-8cbd-6037c1a9cbe2"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2470), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2471) },
                    { new Guid("930aa9e5-133a-4009-8b66-88ebcf0eb81a"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2423), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2436) },
                    { new Guid("c73545e4-eb95-45d2-89c2-1e299b97cfed"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", "System", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2478), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", "Admin", new DateTime(2024, 7, 12, 14, 43, 46, 742, DateTimeKind.Local).AddTicks(2479) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("2dce34ad-c1e4-4538-a6d9-e8a3840c85a1"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("31327de5-6f81-4f6c-af27-ca2b2bd7e75b"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("3429c846-39cd-4da3-8dae-2f5915367ca5"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("39e1e71c-64d7-4eb9-a422-cca45e51c64e"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("631b1d3e-d10e-4bb5-a0c0-2152cb40e9e0"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("6878b65f-422e-4208-9b51-bd41d5273778"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("92705a11-862c-4f3e-8cbd-6037c1a9cbe2"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("930aa9e5-133a-4009-8b66-88ebcf0eb81a"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c73545e4-eb95-45d2-89c2-1e299b97cfed"));

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "CourseReviews");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "CourseReviews");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CourseReviews");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "CourseReviews");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CourseReviews");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "CourseReports");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "CourseReports");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CourseReports");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "CourseReports");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CourseReports");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "CourseReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CourseReviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "CourseReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "CourseReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                table: "CourseReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f98d446-4a4d-4eb6-bd01-7e22df63670e", new DateTime(2024, 7, 12, 7, 23, 48, 306, DateTimeKind.Utc).AddTicks(3934), "AQAAAAIAAYagAAAAEOGKQnNgaFZZFeb+YwYjOEEboIBnW0s7wA2E/clFLktmw9tt/M4dj5PxEIO2IEgRlw==", "652e332f-2d5e-4612-bd3e-32684bd9595f" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreateBy", "CreateTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("081c794e-567b-4443-9286-13cb698d30d2"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1370), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1371) },
                    { new Guid("11d90b0f-588d-40f7-8637-5e064734e13d"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1378), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1378) },
                    { new Guid("201f211f-3ead-4269-9acf-ebd72cc5eb05"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1356), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1357) },
                    { new Guid("2f954a57-806d-441b-b80a-dfa7f3bf1b5d"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1386), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1387) },
                    { new Guid("49b0fcc7-a967-4d4b-bc48-d29088f3ce55"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1361), "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1362) },
                    { new Guid("9cc42316-e076-437a-9613-c07715831839"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1366), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1367) },
                    { new Guid("ae786c05-f9e5-48e6-b64f-47974bbe082c"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1352), "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1352) },
                    { new Guid("d29c3a74-11cc-49b1-8a0e-aeefb1da7670"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1319), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1345) },
                    { new Guid("e96871e3-781b-46fb-81e1-e7bb614593e7"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", "System", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1382), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", "Admin", new DateTime(2024, 7, 12, 14, 23, 48, 423, DateTimeKind.Local).AddTicks(1383) }
                });
        }
    }
}
