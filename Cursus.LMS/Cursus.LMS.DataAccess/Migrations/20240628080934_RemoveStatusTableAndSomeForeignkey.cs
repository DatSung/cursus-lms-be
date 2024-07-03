using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatusTableAndSomeForeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionVersions_CourseSections_CourseSectionId",
                table: "CourseSectionVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionDetailsVersions_SectionDetails_SectionDetailsId",
                table: "SectionDetailsVersions");

            migrationBuilder.DropTable(
                name: "CourseSectionVersionStatus");

            migrationBuilder.DropTable(
                name: "SectionDetailsVersionStatus");

            migrationBuilder.DropIndex(
                name: "IX_SectionDetailsVersions_SectionDetailsId",
                table: "SectionDetailsVersions");

            migrationBuilder.DropIndex(
                name: "IX_CourseSectionVersions_CourseSectionId",
                table: "CourseSectionVersions");

            migrationBuilder.DropColumn(
                name: "SectionDetailsId",
                table: "SectionDetailsVersions");

            migrationBuilder.DropColumn(
                name: "CourseSectionId",
                table: "CourseSectionVersions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SectionDetailsId",
                table: "SectionDetailsVersions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CourseSectionId",
                table: "CourseSectionVersions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseSectionVersionStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseSectionVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetailsVersions_SectionDetailsId",
                table: "SectionDetailsVersions",
                column: "SectionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionVersions_CourseSectionId",
                table: "CourseSectionVersions",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionVersionStatus_CourseSectionVersionId",
                table: "CourseSectionVersionStatus",
                column: "CourseSectionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetailsVersionStatus_SectionDetailsVersionId",
                table: "SectionDetailsVersionStatus",
                column: "SectionDetailsVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionVersions_CourseSections_CourseSectionId",
                table: "CourseSectionVersions",
                column: "CourseSectionId",
                principalTable: "CourseSections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionDetailsVersions_SectionDetails_SectionDetailsId",
                table: "SectionDetailsVersions",
                column: "SectionDetailsId",
                principalTable: "SectionDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
