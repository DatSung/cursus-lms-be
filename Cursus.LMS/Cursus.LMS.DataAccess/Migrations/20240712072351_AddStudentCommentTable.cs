using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("172d2cc5-ebb7-433b-b152-dfb462ddb334"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("204315d2-441a-4b5b-86b8-f91b14b69d29"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("51f873e9-63ae-48e6-894e-de74f44e237d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("710cf85e-90d1-4cb4-9b0e-2f9e75f6d832"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7736a38f-a5a9-4d6b-8a95-456709b4c751"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7b28c84b-3695-4a28-b9ab-8af45252fd3f"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("972539f3-8603-47c8-8883-c40a7f130f75"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a00651ab-165c-45f5-bc85-e7e147cd611d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("adfbefe9-6d26-4fc0-9031-84940936bece"));

            migrationBuilder.CreateTable(
                name: "StudentComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentComments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentComments_StudentId",
                table: "StudentComments",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentComments");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55e21a88-a8ab-4ff9-8eec-86f90b0f66da", new DateTime(2024, 7, 5, 5, 21, 15, 633, DateTimeKind.Utc).AddTicks(8112), "AQAAAAIAAYagAAAAEE/mm52z8qWGkjgpMjXl+CMnVWq/p/DETXXx8UtFfVWVl8TY6MXnNH97fPQCadkfvw==", "6e1147a9-2d2c-4674-b051-20771910bf23" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreateBy", "CreateTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("172d2cc5-ebb7-433b-b152-dfb462ddb334"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(5946), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(5965) },
                    { new Guid("204315d2-441a-4b5b-86b8-f91b14b69d29"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6019), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6020) },
                    { new Guid("51f873e9-63ae-48e6-894e-de74f44e237d"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(5982), "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(5983) },
                    { new Guid("710cf85e-90d1-4cb4-9b0e-2f9e75f6d832"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6023), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6024) },
                    { new Guid("7736a38f-a5a9-4d6b-8a95-456709b4c751"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(5977), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(5978) },
                    { new Guid("7b28c84b-3695-4a28-b9ab-8af45252fd3f"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6015), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6016) },
                    { new Guid("972539f3-8603-47c8-8883-c40a7f130f75"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6006), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6007) },
                    { new Guid("a00651ab-165c-45f5-bc85-e7e147cd611d"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(5972), "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(5973) },
                    { new Guid("adfbefe9-6d26-4fc0-9031-84940936bece"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", "System", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6010), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", "Admin", new DateTime(2024, 7, 5, 12, 21, 15, 749, DateTimeKind.Local).AddTicks(6011) }
                });
        }
    }
}
