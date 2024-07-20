using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCourseBookmark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("020e7039-4995-4c24-b7f7-21f3bd5871b6"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("072b1733-7de8-4cfc-8188-9ab5ba498cd9"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("0b1eef21-e5c0-4ffb-ab17-98594cc1d026"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("11249a9a-4146-4f75-be82-58d478dbb362"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("2b185e5f-12b0-408b-804f-6525c666b288"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("2f286e9d-9cb8-435e-b5b5-451b3d92c9ef"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("6982cf66-f8aa-4768-93b6-cb278567cb2f"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("81606800-51df-4fca-ba6b-82a63529d9b9"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a20db927-3c71-46df-b44c-b0dc21a95003"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("b03c32ac-a687-4506-8b17-d63a72e2f4ca"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("d85787f7-dfbd-40ea-9b74-f4ac78e9c60b"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("df9fca40-0d86-4250-834b-35eef88abf97"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("e75420c1-1841-4645-ac3f-a0327e62b6b3"));

            migrationBuilder.CreateTable(
                name: "CourseBookmarks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseBookmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseBookmarks_Students_StudentId",
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
                values: new object[] { "8e21c6d5-42d6-49d9-bcdc-d1c180439cb5", new DateTime(2024, 7, 20, 10, 58, 17, 638, DateTimeKind.Utc).AddTicks(9941), "AQAAAAIAAYagAAAAEBOrWdRShdLECc26Ml+iTn4nGUyVQII4w6CNpIZ/m/uKKN+/Oh90QrZYRCK7cI0s9A==", "3666e7c0-a9b0-4380-9f11-cafd82156a8c" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("150b3f39-935d-4a47-bf01-c5e99c71fee3"), "Dear [UserFullName],<br><br>Your account will be deleted after 14 days.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Course completed", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Congratulations on completing the course!", "StudentCompleteCourse", null, null },
                    { new Guid("21c99209-ea0f-454a-9414-7ff5be1cdf88"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Student", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("31bfde42-0f10-4b84-b1e3-988ce695820d"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "https://cursuslms.xyz/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("479f6a7f-8bd2-4216-8e25-3aff37ef8f4e"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("50ae8e10-e74a-45ef-aa4c-726ef721578a"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("5ca81a9e-1307-4449-a73b-2ea87f5af7cc"), "Dear [UserFullName],<br><br>You have completed our course program, you can take new courses to increase your knowledge and skills.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Remind Account", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Remind Delete Account!", "RemindDeleteAccount", null, null },
                    { new Guid("76a4cff8-4c10-4d42-83da-6ddc3679b433"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("7cd829c1-1bd0-4f2d-8f26-07dfb8a0b59a"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null },
                    { new Guid("81159325-2c32-4b8a-baea-89bd205f37f0"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("a67a4202-672e-40e1-879f-96a99461ec8b"), "Dear [UserFullName],<br><br>Your account has been deleted.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Delete Account", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Delete Account!", "DeleteAccount", null, null },
                    { new Guid("d3047379-fefa-4b9a-9d3d-d1c7a46bbf93"), "Dear {FirstName} {LastName},<br><br>\r\n\r\n                    This email confirms that your payout request has been processed successfully.\r\n                    <br>\r\n                    <strong>Payout Details:</strong>\r\n                    <ul>\r\n                    <li>Amount: {PayoutAmount}</li>\r\n                    <li>Transaction Date: {TransactionDate}</li> \r\n                    </ul>\r\n                    <br>\r\n                    You can view your payout history in your instructor dashboard. \r\n                    <br> \r\n                    Thank you for being a valued Cursus instructor!\r\n                    <br>", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Payout", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}, {PayoutAmount}, {TransactionDate}", "Payout Successful!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your Cursus Payout is Complete!", "NotifyInstructorPaymentReceived", null, null },
                    { new Guid("e4ccf481-b993-4d3a-a79e-00173f8b344c"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("f257a829-6667-49d1-ba2e-5c82a61c92b4"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseBookmarks_StudentId",
                table: "CourseBookmarks",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseBookmarks");

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("150b3f39-935d-4a47-bf01-c5e99c71fee3"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("21c99209-ea0f-454a-9414-7ff5be1cdf88"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("31bfde42-0f10-4b84-b1e3-988ce695820d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("479f6a7f-8bd2-4216-8e25-3aff37ef8f4e"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("50ae8e10-e74a-45ef-aa4c-726ef721578a"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("5ca81a9e-1307-4449-a73b-2ea87f5af7cc"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("76a4cff8-4c10-4d42-83da-6ddc3679b433"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7cd829c1-1bd0-4f2d-8f26-07dfb8a0b59a"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("81159325-2c32-4b8a-baea-89bd205f37f0"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a67a4202-672e-40e1-879f-96a99461ec8b"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("d3047379-fefa-4b9a-9d3d-d1c7a46bbf93"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("e4ccf481-b993-4d3a-a79e-00173f8b344c"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("f257a829-6667-49d1-ba2e-5c82a61c92b4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf8417bd-cdf5-4d4e-af92-9d91eb72f4e0", new DateTime(2024, 7, 20, 8, 32, 0, 321, DateTimeKind.Utc).AddTicks(4814), "AQAAAAIAAYagAAAAEJ4jLGQcOXXTUeHg4CLJOHvziK43WLL5yHNN04NDMErHuaxBzgx/QERsIZLpZPGSVQ==", "37b5cfbe-e426-45e4-9223-0dc166fe9f2f" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreatedBy", "CreatedTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("020e7039-4995-4c24-b7f7-21f3bd5871b6"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Welcome", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", null, null },
                    { new Guid("072b1733-7de8-4cfc-8188-9ab5ba498cd9"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", null, null },
                    { new Guid("0b1eef21-e5c0-4ffb-ab17-98594cc1d026"), "Dear [UserFullName],<br><br>Your account will be deleted after 14 days.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Course completed", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Congratulations on completing the course!", "StudentCompleteCourse", null, null },
                    { new Guid("11249a9a-4146-4f75-be82-58d478dbb362"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for admin", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", null, null },
                    { new Guid("2b185e5f-12b0-408b-804f-6525c666b288"), "Dear [UserFullName],<br><br>You have completed our course program, you can take new courses to increase your knowledge and skills.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Remind Account", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Remind Delete Account!", "RemindDeleteAccount", null, null },
                    { new Guid("2f286e9d-9cb8-435e-b5b5-451b3d92c9ef"), "Dear {FirstName} {LastName},<br><br>\r\n\r\n                    This email confirms that your payout request has been processed successfully.\r\n                    <br>\r\n                    <strong>Payout Details:</strong>\r\n                    <ul>\r\n                    <li>Amount: {PayoutAmount}</li>\r\n                    <li>Transaction Date: {TransactionDate}</li> \r\n                    </ul>\r\n                    <br>\r\n                    You can view your payout history in your instructor dashboard. \r\n                    <br> \r\n                    Thank you for being a valued Cursus instructor!\r\n                    <br>", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Payout", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}, {PayoutAmount}, {TransactionDate}", "Payout Successful!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your Cursus Payout is Complete!", "NotifyInstructorPaymentReceived", null, null },
                    { new Guid("6982cf66-f8aa-4768-93b6-cb278567cb2f"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", null, null },
                    { new Guid("81606800-51df-4fca-ba6b-82a63529d9b9"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "https://cursuslms.xyz/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", null, null, "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", null, null },
                    { new Guid("a20db927-3c71-46df-b44c-b0dc21a95003"), "Dear [UserFullName],<br><br>Your account has been deleted.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Delete Account", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Hello!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Delete Account!", "DeleteAccount", null, null },
                    { new Guid("b03c32ac-a687-4506-8b17-d63a72e2f4ca"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", null, null },
                    { new Guid("d85787f7-dfbd-40ea-9b74-f4ac78e9c60b"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", null, null },
                    { new Guid("df9fca40-0d86-4250-834b-35eef88abf97"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>", "Notice for instructor", null, null, "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Student", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", null, null },
                    { new Guid("e75420c1-1841-4645-ac3f-a0327e62b6b3"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", null, null, "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", null, null }
                });
        }
    }
}
