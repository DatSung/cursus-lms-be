using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCourseAndCourseVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Levels_LevelId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "SectionDetails");

            migrationBuilder.DropTable(
                name: "CourseSections");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LevelId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseImgUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LearningTime",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "Courses",
                newName: "CourseVersion");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10f9a043-680e-4e92-80b4-39f9c2fbf9c7", new DateTime(2024, 7, 1, 5, 49, 16, 618, DateTimeKind.Utc).AddTicks(8479), "AQAAAAIAAYagAAAAEDkzM8uifwX+y0chb+N+GBQc18V9a6xZbnCMQC2N2SBcr5UklTWLdWfQYPcuVH5fBg==", "eceb6ecb-c329-42d0-b545-ea87ebe966b4" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseVersions_CategoryId",
                table: "CourseVersions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVersions_LevelId",
                table: "CourseVersions",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVersions_Categories_CategoryId",
                table: "CourseVersions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVersions_Levels_LevelId",
                table: "CourseVersions",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseVersions_Categories_CategoryId",
                table: "CourseVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseVersions_Levels_LevelId",
                table: "CourseVersions");

            migrationBuilder.DropIndex(
                name: "IX_CourseVersions_CategoryId",
                table: "CourseVersions");

            migrationBuilder.DropIndex(
                name: "IX_CourseVersions_LevelId",
                table: "CourseVersions");

            migrationBuilder.RenameColumn(
                name: "CourseVersion",
                table: "Courses",
                newName: "LevelId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseImgUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LearningTime",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OldPrice",
                table: "Courses",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Courses",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlideUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionDetails_CourseSections_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fe4d527-fb8b-458a-9294-62db97349e7b", new DateTime(2024, 7, 1, 5, 10, 55, 807, DateTimeKind.Utc).AddTicks(8957), "AQAAAAIAAYagAAAAEA2LGRhRei4IVuYkcmkxyfmmKLh7m73QGEL/N0vIdiAvvhyZVq63HUqZcCmmxuoLjQ==", "3a877c39-2997-478f-a992-cd659307d91a" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LevelId",
                table: "Courses",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_CourseId",
                table: "CourseSections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetails_CourseSectionId",
                table: "SectionDetails",
                column: "CourseSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Levels_LevelId",
                table: "Courses",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");
        }
    }
}
