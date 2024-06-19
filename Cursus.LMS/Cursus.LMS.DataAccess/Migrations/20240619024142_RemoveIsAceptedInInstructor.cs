using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsAceptedInInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Instructors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedandYasuo",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UpdateTime" },
                values: new object[] { "70965be5-e9cc-4f0c-9245-55cd4462327a", "AQAAAAIAAYagAAAAEBC2+jm8Pedi+8ej6u/ZJTAUg5NGIS9WVKKHNulA7aEbIW6UbTORRWhjUB5QVA1u9Q==", "3b98493c-5ff7-4394-8d3d-25726b9d1cc2", new DateTime(2024, 6, 19, 2, 41, 40, 412, DateTimeKind.Utc).AddTicks(2464) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Instructors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedandYasuo",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UpdateTime" },
                values: new object[] { "cda04887-7f77-4e80-9b53-1f70742f84f6", "AQAAAAIAAYagAAAAEFq6A8McNgCVeQG+uaQNPUSbbw0M1Ya7DC665Y3FEOExrU1qURE5vF9ZS1HwbK8qRg==", "e569ef88-21a8-4960-85a4-2177598bf1c0", new DateTime(2024, 6, 17, 11, 14, 10, 263, DateTimeKind.Utc).AddTicks(3712) });
        }
    }
}
