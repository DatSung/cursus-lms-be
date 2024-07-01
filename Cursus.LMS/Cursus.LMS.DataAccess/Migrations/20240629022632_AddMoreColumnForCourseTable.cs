using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreColumnForCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "CourseVersions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "CourseVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MergedTime",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c32e133-9bc8-41c7-ba0c-7b48e2a4d3c3", new DateTime(2024, 6, 29, 2, 26, 29, 441, DateTimeKind.Utc).AddTicks(5077), "AQAAAAIAAYagAAAAENIZpcL61kOep5GM+eh/kcy17M/hmhqfA1C3fwnhrisFNAboxPMVtN4cXmuMCsJz5Q==", "fcd52946-25f5-49ed-8bd8-67523c6c5826" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "CourseVersions");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "CourseVersions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MergedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MergedTime",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26d1b902-723a-4261-9361-e9496d408134", new DateTime(2024, 6, 28, 16, 57, 34, 968, DateTimeKind.Utc).AddTicks(9830), "AQAAAAIAAYagAAAAEE1pQpWsnr0gEFqxwlVegm3q5ccBskv9U7uQ2/oqLcnquVfcKFsStSECcuPfS9x92A==", "3604258e-3c8d-4a14-96b0-2ae5b8887ca5" });
        }
    }
}
