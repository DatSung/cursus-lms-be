using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMorePropertiesInTableInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isAccepted",
                table: "Instructors",
                newName: "IsAccepted");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptedTime",
                table: "Instructors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Instructors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectedTime",
                table: "Instructors",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedTime",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "RejectedTime",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "Instructors",
                newName: "isAccepted");
        }
    }
}
