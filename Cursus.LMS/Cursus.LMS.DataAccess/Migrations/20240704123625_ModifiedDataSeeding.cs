using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "525df932-5562-46af-9c13-8398accd2396", new DateTime(2024, 7, 4, 12, 36, 24, 603, DateTimeKind.Utc).AddTicks(3132), "AQAAAAIAAYagAAAAEOJJq82i1BRvdIa76j8QRRfBzaEcHrmDB4lyWG87+X0UzO5KAGIuQkTk+58WFf/m3A==", "d3ab2068-d7ba-4d0c-a4d5-35b97f3bd8b8" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "BodyContent", "CallToAction", "Category", "CreateBy", "CreateTime", "FooterContent", "Language", "PersonalizationTags", "PreHeaderText", "RecipientType", "SenderEmail", "SenderName", "Status", "SubjectLine", "TemplateName", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("169aa42f-1497-440b-a79d-016d87deee34"), "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>", "<a href=\"{{ResetLink}}\">Reset Password</a>", "Security", "System", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(29), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {ResetLink}", "Reset your password to regain access.", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ChangePassword", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(30) },
                    { new Guid("440dbe11-cf83-485b-b98f-64cce18d6abe"), "<p>Thank you for registering your Cursus account. Click here to go back the page</p>", "<a href=\"{{Login}}\">Login now</a>", "Verify", "System", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(20), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LinkLogin}", "User Account Verified!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Cursus Verify Email", "SendVerifyEmail", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(21) },
                    { new Guid("47f74758-be20-4468-8113-031d7d93e5f5"), "New course has been added by Instructor, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for admin", "System", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(39), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available", "Admin", "cursusservicetts@gmail.com", "Cursus Team", 1, "New course has been created!", "NotificationForAdminAboutNewCourse", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(39) },
                    { new Guid("7089efd0-7e14-4b68-88fd-fc696c5e2fe9"), "<h2>-Your Account has been aprroval!</h2>", "<p><a href='http://bloodmoonrpg.carrd.co?token={token}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>", "Approval", "System", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(24), "<p>Thank you for your waiting! Click this to go to the main page</p>", "English", "{FirstName}, {LastName}", "Circus Verify Email For Instructor Approval", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Circus Verify Email For Instructor Approval", "SendEmailForInstructorApproval", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(25) },
                    { new Guid("918ff637-4b54-47b2-8592-a2e71e2ff7e4"), "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.", "http://localhost:30475/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)", "Security", "System", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(15), "If you did not request a password reset, please ignore this email.", "English", "[UserFullName], [ResetPasswordLink]", "Reset your password to regain access", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Reset Your Password", "ForgotPasswordEmail", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(16) },
                    { new Guid("9c53afe0-09d7-411c-bb8d-a9f68799ed1d"), "New course has been rejected by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", "System", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(47), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is not available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been rejected!", "RejectInstructorCourse", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(48) },
                    { new Guid("a1ef88fb-89d3-4c82-b6f7-26913cb28519"), "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>", "<a href=\"{{LoginLink}}\">Login Now</a>", "Notification", "System", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(34), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FullName}", "Hello friends,", "Customer", "instructor@gmail.com", "Instructor", 1, "Inactive Course", "InactiveCourseEmail", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(35) },
                    { new Guid("cd669078-8181-4ec4-af68-642eab993369"), "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.", "<a href=\"https://cursus.com/login\">Login</a>", "Welcome", "System", new DateTime(2024, 7, 4, 19, 36, 24, 718, DateTimeKind.Local).AddTicks(9978), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "Thank you for signing up!", "Customer", "cursusservicetts@gmail.com", "Cursus Team", 1, "Welcome to Cursus!", "WelcomeEmail", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 718, DateTimeKind.Local).AddTicks(9995) },
                    { new Guid("fa4b1bb5-8d77-43c7-9830-6f8ffc9af9fb"), "New course has been approved by Admin, please check in the main page.", "<a href=\"https://cursus.com/login\">Login</a>", "Notice for instructor", "System", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(43), "<p>Contact us at cursusservicetts@gmail.com</p>", "English", "{FirstName}, {LastName}", "The New Courses is available now", "Instructor", "cursusservicetts@gmail.com", "Cursus Team", 1, "Your course has been approved!", "ApproveInstructorCourse", "Admin", new DateTime(2024, 7, 4, 19, 36, 24, 719, DateTimeKind.Local).AddTicks(43) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("169aa42f-1497-440b-a79d-016d87deee34"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("440dbe11-cf83-485b-b98f-64cce18d6abe"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("47f74758-be20-4468-8113-031d7d93e5f5"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7089efd0-7e14-4b68-88fd-fc696c5e2fe9"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("918ff637-4b54-47b2-8592-a2e71e2ff7e4"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("9c53afe0-09d7-411c-bb8d-a9f68799ed1d"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a1ef88fb-89d3-4c82-b6f7-26913cb28519"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("cd669078-8181-4ec4-af68-642eab993369"));

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: new Guid("fa4b1bb5-8d77-43c7-9830-6f8ffc9af9fb"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "163baa2e-58a0-4774-9218-08e92f9ba7f0", new DateTime(2024, 7, 1, 5, 53, 37, 747, DateTimeKind.Utc).AddTicks(1446), "AQAAAAIAAYagAAAAENGB5r0Q4vF88yfjry6WQnYEry9vK+3a7pD7MAcQyBI49YVcX5/Sv2BuL4htrAp6nA==", "c9958e9b-f046-4fdf-b0c7-4146339073e1" });
        }
    }
}
