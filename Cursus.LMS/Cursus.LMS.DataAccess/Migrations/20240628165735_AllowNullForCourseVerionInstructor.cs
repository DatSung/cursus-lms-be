using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullForCourseVerionInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "CourseVersions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26d1b902-723a-4261-9361-e9496d408134", new DateTime(2024, 6, 28, 16, 57, 34, 968, DateTimeKind.Utc).AddTicks(9830), "AQAAAAIAAYagAAAAEE1pQpWsnr0gEFqxwlVegm3q5ccBskv9U7uQ2/oqLcnquVfcKFsStSECcuPfS9x92A==", "3604258e-3c8d-4a14-96b0-2ae5b8887ca5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "CourseVersions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52180564-1438-434d-b709-e7e0a1c9b0e1", new DateTime(2024, 6, 28, 16, 48, 24, 634, DateTimeKind.Utc).AddTicks(6871), "AQAAAAIAAYagAAAAEPuasXXk55MwxsV3ZcfjfIvggyz5IsPDAbhc419Gi/Wk3I6Rm8fnAgLmZX+eNjT/Dg==", "49c29927-7706-48ed-8de3-0414ae1fceba" });
        }
    }
}
