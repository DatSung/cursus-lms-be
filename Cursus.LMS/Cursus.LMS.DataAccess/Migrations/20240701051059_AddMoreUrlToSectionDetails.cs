using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreUrlToSectionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SlideUrk",
                table: "SectionDetailsVersions",
                newName: "SlideUrl");

            migrationBuilder.AddColumn<string>(
                name: "DocsUrl",
                table: "SectionDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlideUrl",
                table: "SectionDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "SectionDetails",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocsUrl",
                table: "SectionDetails");

            migrationBuilder.DropColumn(
                name: "SlideUrl",
                table: "SectionDetails");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SectionDetails");

            migrationBuilder.RenameColumn(
                name: "SlideUrl",
                table: "SectionDetailsVersions",
                newName: "SlideUrk");
            
        }
    }
}
