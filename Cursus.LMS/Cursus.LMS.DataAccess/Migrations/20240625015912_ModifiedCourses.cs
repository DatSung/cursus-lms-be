using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LearningTime",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LearningTime",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
