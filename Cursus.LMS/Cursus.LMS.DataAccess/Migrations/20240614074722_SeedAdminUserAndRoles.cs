using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35446074-daa5-4973-bf02-82301a5eb327", "INSTRUCTOR", "INSTRUCTOR", "INSTRUCTOR" },
                    { "8fa7c7bb-b4dc-480d-a660-e07a90855d5d", "STUDENT", "STUDENT", "STUDENT" },
                    { "8fa7c7bb-daa5-a660-bf02-82301a5eb327", "ADMIN", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "BirthDate", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxNumber", "TwoFactorEnabled", "UpdateTime", "UserName" },
                values: new object[] { "BestZedandYasuo", 0, "123 Admin St", "https://example.com/avatar.png", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6e026948-e6a2-480c-b1c3-8702e2f35822", "Country", "admin@gmail.com", true, "Admin User", "Male", true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEDc6m9ru8bpgwk+FxGuBs8UJuZKBP5Lw4PtDNyFzCWgUS84TwXlDZMSbDHQ6JBf4og==", "1234567890", true, "6cfb7d2e-645e-424c-93d5-d02a97fb1808", "123456789", false, new DateTime(2024, 6, 14, 7, 47, 21, 859, DateTimeKind.Utc).AddTicks(2060), "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8fa7c7bb-daa5-a660-bf02-82301a5eb327", "BestZedandYasuo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35446074-daa5-4973-bf02-82301a5eb327");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa7c7bb-b4dc-480d-a660-e07a90855d5d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8fa7c7bb-daa5-a660-bf02-82301a5eb327", "BestZedandYasuo" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa7c7bb-daa5-a660-bf02-82301a5eb327");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedandYasuo");
        }
    }
}
