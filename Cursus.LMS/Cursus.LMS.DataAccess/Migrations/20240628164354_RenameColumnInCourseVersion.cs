using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnInCourseVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseVersions_Courses_CourseVersionId",
                table: "CourseVersions");

            migrationBuilder.RenameColumn(
                name: "CourseVersionId",
                table: "CourseVersions",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseVersions_CourseVersionId",
                table: "CourseVersions",
                newName: "IX_CourseVersions_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVersions_Courses_CourseId",
                table: "CourseVersions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseVersions_Courses_CourseId",
                table: "CourseVersions");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseVersions",
                newName: "CourseVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseVersions_CourseId",
                table: "CourseVersions",
                newName: "IX_CourseVersions_CourseVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVersions_Courses_CourseVersionId",
                table: "CourseVersions",
                column: "CourseVersionId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
