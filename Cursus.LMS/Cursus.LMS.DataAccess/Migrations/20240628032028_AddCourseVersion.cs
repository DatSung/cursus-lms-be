using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearningTime = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OldPrice = table.Column<double>(type: "float", nullable: true),
                    CourseImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseVersions_Courses_CourseVersionId",
                        column: x => x.CourseVersionId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseSectionVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSectionVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSectionVersions_CourseSections_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseSectionVersions_CourseVersions_CourseVersionId",
                        column: x => x.CourseVersionId,
                        principalTable: "CourseVersions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseVersionStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVersionStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseVersionStatus_CourseVersions_CourseVersionId",
                        column: x => x.CourseVersionId,
                        principalTable: "CourseVersions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SectionDetailsVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseSectionVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SectionDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlideUrk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDetailsVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionDetailsVersions_CourseSectionVersions_CourseSectionVersionId",
                        column: x => x.CourseSectionVersionId,
                        principalTable: "CourseSectionVersions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SectionDetailsVersions_SectionDetails_SectionDetailsId",
                        column: x => x.SectionDetailsId,
                        principalTable: "SectionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57ab7cc5-afdd-428b-b3e1-1a82fc766647", new DateTime(2024, 6, 28, 3, 20, 27, 972, DateTimeKind.Utc).AddTicks(9855), "AQAAAAIAAYagAAAAEHrInDVa2Q9LhcSgKB1aBtkqIMZnjkZp0IR4e46KbXbWVmvxVOpqkUzJuoMVpYQaiA==", "bf0d6662-b94b-426b-bc5b-8b5a625ba642" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionVersions_CourseSectionId",
                table: "CourseSectionVersions",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionVersions_CourseVersionId",
                table: "CourseSectionVersions",
                column: "CourseVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVersions_CourseVersionId",
                table: "CourseVersions",
                column: "CourseVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVersionStatus_CourseVersionId",
                table: "CourseVersionStatus",
                column: "CourseVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetailsVersions_CourseSectionVersionId",
                table: "SectionDetailsVersions",
                column: "CourseSectionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetailsVersions_SectionDetailsId",
                table: "SectionDetailsVersions",
                column: "SectionDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseVersionStatus");

            migrationBuilder.DropTable(
                name: "SectionDetailsVersions");

            migrationBuilder.DropTable(
                name: "CourseSectionVersions");

            migrationBuilder.DropTable(
                name: "CourseVersions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfb8a8e0-97c6-40d4-a105-c662900978cf", new DateTime(2024, 6, 28, 3, 12, 59, 8, DateTimeKind.Utc).AddTicks(7749), "AQAAAAIAAYagAAAAEBESQKQ2qpVQ9GzZR5CKp/CyWQG9KVPoxsrl3Y9Ftj2fb+nECllXJXZusdbl85ibrw==", "b81793a6-500c-4b79-92cc-7674c0685ab6" });
        }
    }
}
