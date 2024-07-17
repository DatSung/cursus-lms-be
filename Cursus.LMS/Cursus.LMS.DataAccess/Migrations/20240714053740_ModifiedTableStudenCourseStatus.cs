using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedTableStudenCourseStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "StudentCoursesStatus",
                newName: "CreatedTime");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentCoursesStatus",
                type: "nvarchar(max)",
                nullable: true);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentCoursesStatus");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "StudentCoursesStatus",
                newName: "CreateTime");
            
        }
    }
}
