using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReAddTableBalances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("1be3e035-eb3e-4ec0-af7a-f17c6ab63009"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("21f6e643-992c-4e2a-b625-5d4b61c546d3"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("23454a6d-6e79-4976-b151-511f841a2343"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("65bf181e-7780-4131-a484-4080d11fcf86"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("84727704-ba0e-4fd1-a985-8869d3f72362"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("944782fa-69f8-45dd-879e-d58b8bb7b305"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("97c91f90-f535-4df0-83a5-ca8e91a2778e"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c03ee2cf-ccd1-4177-861f-2fd0ebbe6f22"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("d8709804-8786-420a-82aa-cd004002fc1b"));

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AvailableBalance = table.Column<int>(type: "int", nullable: false),
                    PendingBalance = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Balances_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea124e55-077c-4b63-82c0-98f437db37f3", new DateTime(2024, 7, 17, 2, 24, 33, 770, DateTimeKind.Utc).AddTicks(6316), "AQAAAAIAAYagAAAAEIJwkalm3sMFh5NlmOZ6JWUJOq3n0aZF/ieqzU8I+s3V9h4RWZOXtI7gx2eaXBElFQ==", "ced80767-b23f-4f29-9a2e-855489724c01" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("06e999a5-ba3c-4c5e-9dcd-5dd0dee00b95"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("52519d8b-da1c-43d2-ba1e-523740e0becb"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("5edc2be2-4276-49b0-b34d-8b1f80b9528b"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("7138b474-b915-4deb-945e-309ae1d6419d"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("9d5437a3-4bb6-4c1a-a4a9-db4cf2bb7d32"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("da2bf22a-d5fe-4f7a-b813-5b6f802fba6e"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("da3686e8-0bc0-40c7-bca4-94a686b31707"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("ef5a483c-be73-42fb-918d-cb62fe0eaa3b"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("f2e07b83-6e0f-40c2-8bed-929ba364ab28"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("06e999a5-ba3c-4c5e-9dcd-5dd0dee00b95"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("52519d8b-da1c-43d2-ba1e-523740e0becb"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("5edc2be2-4276-49b0-b34d-8b1f80b9528b"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7138b474-b915-4deb-945e-309ae1d6419d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("9d5437a3-4bb6-4c1a-a4a9-db4cf2bb7d32"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("da2bf22a-d5fe-4f7a-b813-5b6f802fba6e"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("da3686e8-0bc0-40c7-bca4-94a686b31707"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("ef5a483c-be73-42fb-918d-cb62fe0eaa3b"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("f2e07b83-6e0f-40c2-8bed-929ba364ab28"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "326de14a-0160-4644-acd8-8a41a81ec250", new DateTime(2024, 7, 17, 2, 21, 58, 207, DateTimeKind.Utc).AddTicks(2436), "AQAAAAIAAYagAAAAEDN8xosxgLY/mon9uzo3SV/m6R8bjsqBE8N/9HqMNv4qiE+c/+l5Dt6FDoPJJSSQmA==", "4f244312-9479-4c6f-9fe7-23ad18dcce9f" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("1be3e035-eb3e-4ec0-af7a-f17c6ab63009"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("21f6e643-992c-4e2a-b625-5d4b61c546d3"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("23454a6d-6e79-4976-b151-511f841a2343"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("65bf181e-7780-4131-a484-4080d11fcf86"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("84727704-ba0e-4fd1-a985-8869d3f72362"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("944782fa-69f8-45dd-879e-d58b8bb7b305"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("97c91f90-f535-4df0-83a5-ca8e91a2778e"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("c03ee2cf-ccd1-4177-861f-2fd0ebbe6f22"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("d8709804-8786-420a-82aa-cd004002fc1b"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null }
                });
        }
    }
}
