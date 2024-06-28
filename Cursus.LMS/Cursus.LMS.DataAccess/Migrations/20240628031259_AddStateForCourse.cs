using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStateForCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8fa7c7bb-daa5-a660-bf02-82301a5eb327", "BestZedandYasuo" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedandYasuo");

            migrationBuilder.AddColumn<string>(
                name: "ActivatedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivatedTime",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeactivatedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeactivatedTime",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "BirthDate", "ConcurrencyStamp", "Country", "CreateTime", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxNumber", "TwoFactorEnabled", "UpdateTime", "UserName" },
                values: new object[] { "BestZedAndYasuo", 0, "123 Admin St", "https://example.com/avatar.png", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cfb8a8e0-97c6-40d4-a105-c662900978cf", "Country", new DateTime(2024, 6, 28, 3, 12, 59, 8, DateTimeKind.Utc).AddTicks(7749), "admin@gmail.com", true, "Admin User", "Male", true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBESQKQ2qpVQ9GzZR5CKp/CyWQG9KVPoxsrl3Y9Ftj2fb+nECllXJXZusdbl85ibrw==", "1234567890", true, "b81793a6-500c-4b79-92cc-7674c0685ab6", "123456789", false, new DateTime(2003, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8fa7c7bb-daa5-a660-bf02-82301a5eb327", "BestZedAndYasuo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8fa7c7bb-daa5-a660-bf02-82301a5eb327", "BestZedAndYasuo" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo");

            migrationBuilder.DropColumn(
                name: "ActivatedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ActivatedTime",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeactivatedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeactivatedTime",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Courses");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "BirthDate", "ConcurrencyStamp", "Country", "CreateTime", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxNumber", "TwoFactorEnabled", "UpdateTime", "UserName" },
                values: new object[] { "BestZedandYasuo", 0, "123 Admin St", "https://example.com/avatar.png", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c2e754c0-5497-483d-a5fd-ac074be1b896", "Country", new DateTime(2024, 6, 28, 3, 1, 44, 193, DateTimeKind.Utc).AddTicks(6638), "admin@gmail.com", true, "Admin User", "Male", true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJPF0OroFQLtaghgsPblyh0WKmmQ7GORclqpKpouETl/AALIG0pSN/1WXhyrTNfGIQ==", "1234567890", true, "c3e7f730-9f4a-4890-aa06-d54505a097cb", "123456789", false, new DateTime(2024, 6, 28, 3, 1, 44, 310, DateTimeKind.Utc).AddTicks(1219), "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8fa7c7bb-daa5-a660-bf02-82301a5eb327", "BestZedandYasuo" });
        }
    }
}
