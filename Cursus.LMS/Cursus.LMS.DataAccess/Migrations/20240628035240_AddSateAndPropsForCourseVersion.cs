using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSateAndPropsForCourseVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStatus",
                table: "SectionDetailsVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStatus",
                table: "CourseVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStatus",
                table: "CourseSectionVersions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseSectionVersionStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseSectionVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSectionVersionStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSectionVersionStatus_CourseSectionVersions_CourseSectionVersionId",
                        column: x => x.CourseSectionVersionId,
                        principalTable: "CourseSectionVersions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SectionDetailsVersionStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionDetailsVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDetailsVersionStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionDetailsVersionStatus_SectionDetailsVersions_SectionDetailsVersionId",
                        column: x => x.SectionDetailsVersionId,
                        principalTable: "SectionDetailsVersions",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb528559-3501-4edc-a3de-abebb91c654c", new DateTime(2024, 6, 28, 3, 52, 39, 281, DateTimeKind.Utc).AddTicks(3245), "AQAAAAIAAYagAAAAEKvIysVnvwsVPLqlOCm4etIzD4OI89wqJJlnIEc7vXlB0qcNdnhC+1GojUUDQwFQ+Q==", "f73b5a89-7620-42ff-9c8f-8357d9a92ce5" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionVersionStatus_CourseSectionVersionId",
                table: "CourseSectionVersionStatus",
                column: "CourseSectionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetailsVersionStatus_SectionDetailsVersionId",
                table: "SectionDetailsVersionStatus",
                column: "SectionDetailsVersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSectionVersionStatus");

            migrationBuilder.DropTable(
                name: "SectionDetailsVersionStatus");

            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "SectionDetailsVersions");

            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "CourseVersions");

            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "CourseSectionVersions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57ab7cc5-afdd-428b-b3e1-1a82fc766647", new DateTime(2024, 6, 28, 3, 20, 27, 972, DateTimeKind.Utc).AddTicks(9855), "AQAAAAIAAYagAAAAEHrInDVa2Q9LhcSgKB1aBtkqIMZnjkZp0IR4e46KbXbWVmvxVOpqkUzJuoMVpYQaiA==", "bf0d6662-b94b-426b-bc5b-8b5a625ba642" });
        }
    }
}
