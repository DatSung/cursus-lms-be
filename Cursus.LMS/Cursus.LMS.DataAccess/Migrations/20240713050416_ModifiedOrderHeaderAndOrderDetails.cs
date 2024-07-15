using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedOrderHeaderAndOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CreateAt",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "IsPayout",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "IsSuccess",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "StudentComments",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "StudentComments",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "StudentComments",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "StudentComments",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Levels",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "Levels",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Levels",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Levels",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "InstructorRatings",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "InstructorRatings",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "InstructorRatings",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "InstructorRatings",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "InstructorComments",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "InstructorComments",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "InstructorComments",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "InstructorComments",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "EmailTemplates",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "EmailTemplates",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "EmailTemplates",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "EmailTemplates",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "CourseVersionComments",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "CourseVersionComments",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "CourseVersionComments",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "CourseVersionComments",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "CourseReviews",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "CourseReviews",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "CourseReviews",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "CourseReviews",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "CourseReports",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "CourseReports",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "CourseReports",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "CourseReports",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Categories",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "Categories",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Categories",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Categories",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "OrderHeaders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "OrderHeaders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseTitle",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f0fd638-2ecb-463e-833f-2c51d20e4c94", new DateTime(2024, 7, 13, 5, 4, 13, 16, DateTimeKind.Utc).AddTicks(3721), "AQAAAAIAAYagAAAAELuyd1ry9/vNlyDNPd9wEid+/BNyx7DhWRgn9Gh5O/2LCR+7A8a5pe85oUgHrXUc7w==", "1f156147-cc4b-4c85-bef4-8c2d9a09232d" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("05a5cdf1-642a-4f71-85c5-1ba0cce17856"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("0efb7637-f975-4dc0-b8a6-62bb05976afb"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("2206ab7b-e746-465e-b266-285d4c530c17"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("55268954-707d-4cf8-a430-f4aecb77976b"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("83ee2bda-0d76-4c2e-8c7b-7ecfb89f3648"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("a053546c-017c-45f7-81d6-60b36a1e0a22"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("b124d4ff-1e48-4da5-843b-da5f484f67dd"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("cac9ddaf-340e-4c80-8810-a257ecc03375"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("d3311e6a-0ae0-43e7-b482-1427fe3ac65d"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("05a5cdf1-642a-4f71-85c5-1ba0cce17856"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("0efb7637-f975-4dc0-b8a6-62bb05976afb"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("2206ab7b-e746-465e-b266-285d4c530c17"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("55268954-707d-4cf8-a430-f4aecb77976b"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("83ee2bda-0d76-4c2e-8c7b-7ecfb89f3648"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a053546c-017c-45f7-81d6-60b36a1e0a22"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("b124d4ff-1e48-4da5-843b-da5f484f67dd"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("cac9ddaf-340e-4c80-8810-a257ecc03375"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("d3311e6a-0ae0-43e7-b482-1427fe3ac65d"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "CourseTitle",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "StudentComments",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "StudentComments",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "StudentComments",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "StudentComments",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Levels",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Levels",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Levels",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Levels",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "InstructorRatings",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "InstructorRatings",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "InstructorRatings",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "InstructorRatings",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "InstructorComments",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "InstructorComments",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "InstructorComments",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "InstructorComments",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "EmailTemplates",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "EmailTemplates",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "EmailTemplates",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "EmailTemplates",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "CourseVersionComments",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "CourseVersionComments",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "CourseVersionComments",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "CourseVersionComments",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "CourseReviews",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "CourseReviews",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "CourseReviews",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "CourseReviews",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "CourseReports",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "CourseReports",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "CourseReports",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "CourseReports",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Categories",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Categories",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Categories",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Categories",
                newName: "CreateBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "OrderHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPayout",
                table: "OrderHeaders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccess",
                table: "OrderHeaders",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
    }
}
