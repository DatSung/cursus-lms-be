using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameSomePropInCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentSlot",
                table: "Courses",
                newName: "StudentSlots");

            migrationBuilder.RenameColumn(
                name: "CourseVersion",
                table: "Courses",
                newName: "CourseVersionId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "163baa2e-58a0-4774-9218-08e92f9ba7f0", new DateTime(2024, 7, 1, 5, 53, 37, 747, DateTimeKind.Utc).AddTicks(1446), "AQAAAAIAAYagAAAAENGB5r0Q4vF88yfjry6WQnYEry9vK+3a7pD7MAcQyBI49YVcX5/Sv2BuL4htrAp6nA==", "c9958e9b-f046-4fdf-b0c7-4146339073e1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentSlots",
                table: "Courses",
                newName: "StudentSlot");

            migrationBuilder.RenameColumn(
                name: "CourseVersionId",
                table: "Courses",
                newName: "CourseVersion");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedAndYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10f9a043-680e-4e92-80b4-39f9c2fbf9c7", new DateTime(2024, 7, 1, 5, 49, 16, 618, DateTimeKind.Utc).AddTicks(8479), "AQAAAAIAAYagAAAAEDkzM8uifwX+y0chb+N+GBQc18V9a6xZbnCMQC2N2SBcr5UklTWLdWfQYPcuVH5fBg==", "eceb6ecb-c329-42d0-b545-ea87ebe966b4" });
        }
    }
}
