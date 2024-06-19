using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InstructorRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InstructorComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "InstructorRatings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InstructorComments");
        }
    }
}
