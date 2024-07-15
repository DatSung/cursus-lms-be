using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullForCourseTilteInOrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("03ffe4ce-38cf-40d0-a65a-49ed91d16821"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("324f88a4-4c94-4616-9e98-e9db1cfb34e5"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("334e2c32-5c34-420a-9d9a-5639e6599f6d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("3c9fa735-c564-4727-972b-3c745e9caa13"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("57021cf2-6979-4f19-9bfd-535c224881ca"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("94155b2b-e7f8-4c9b-b6e1-68fb07d1f8f0"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("9830a039-f69c-4273-a8c8-bd733405eea6"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("dfbe17ef-8220-4a5a-a013-cdca39512fdd"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("f0d0943f-cb5a-4458-b34e-bafd8dccb18f"));

            migrationBuilder.AlterColumn<string>(
                name: "CourseTitle",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3d1606a-300f-467d-a3e3-92041011ed61", new DateTime(2024, 7, 13, 6, 53, 10, 776, DateTimeKind.Utc).AddTicks(7056), "AQAAAAIAAYagAAAAEDvUaYOZ7RcVgZZT9EOEbZxHd6J8DCFaPNDerBfnaNw4LEGsCVNqV37am9B9+f6lPw==", "032f1d3c-ace1-4ba7-85a1-a240c31fea4c" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("177221d0-bc16-4271-80ba-c63562f15161"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("1c16157b-39c8-40ab-8341-6893e062320f"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("3b891a71-0169-42c6-be38-71b9349fcf77"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("8a317b4a-db1e-4f2d-a4a5-853a5766e6f2"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("8e365772-0d39-443b-8a12-9340c0ca2c10"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("bdf9cc3e-ef29-4fdc-90ea-be763fe85bdd"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("c8537b64-4b5e-4e50-9d13-8c21b31f2441"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("cc2f0d53-961f-41a0-93f6-e17dcfa6cdaf"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("d7c84721-3f29-4b1f-93af-7e5a8f00096e"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("177221d0-bc16-4271-80ba-c63562f15161"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("1c16157b-39c8-40ab-8341-6893e062320f"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("3b891a71-0169-42c6-be38-71b9349fcf77"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("8a317b4a-db1e-4f2d-a4a5-853a5766e6f2"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("8e365772-0d39-443b-8a12-9340c0ca2c10"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("bdf9cc3e-ef29-4fdc-90ea-be763fe85bdd"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c8537b64-4b5e-4e50-9d13-8c21b31f2441"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("cc2f0d53-961f-41a0-93f6-e17dcfa6cdaf"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("d7c84721-3f29-4b1f-93af-7e5a8f00096e"));

            migrationBuilder.AlterColumn<string>(
                name: "CourseTitle",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5698fe4-456a-4297-86fa-17543cd57ca1", new DateTime(2024, 7, 13, 6, 48, 25, 967, DateTimeKind.Utc).AddTicks(7451), "AQAAAAIAAYagAAAAEIhyCfSWStJusX7ivOXobF5BkXmKtUl2SNLzkX9XhFMjFULo3Wn30/LLNZkBagNyLQ==", "b61f3634-2688-4240-a68f-dd9571fe9b42" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("03ffe4ce-38cf-40d0-a65a-49ed91d16821"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("324f88a4-4c94-4616-9e98-e9db1cfb34e5"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("334e2c32-5c34-420a-9d9a-5639e6599f6d"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("3c9fa735-c564-4727-972b-3c745e9caa13"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("57021cf2-6979-4f19-9bfd-535c224881ca"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("94155b2b-e7f8-4c9b-b6e1-68fb07d1f8f0"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("9830a039-f69c-4273-a8c8-bd733405eea6"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("dfbe17ef-8220-4a5a-a013-cdca39512fdd"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("f0d0943f-cb5a-4458-b34e-bafd8dccb18f"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null }
                });
        }
    }
}
