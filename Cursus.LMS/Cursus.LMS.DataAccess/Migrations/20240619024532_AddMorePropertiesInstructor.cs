using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMorePropertiesInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Instructors",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectedBy",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectedTime",
                table: "Instructors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedandYasuo",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UpdateTime" },
                values: new object[] { "5d615361-3681-458a-a61a-0ab82760942f", "AQAAAAIAAYagAAAAEGFToPJFpj0EU8gQU+6ym20YEYoPjhHkuuYPxCI1zek/rHZfyjShF+lC/P+Cscfnew==", "260d1548-9211-45b5-9b85-93f36bc43ef3", new DateTime(2024, 6, 19, 2, 45, 32, 156, DateTimeKind.Utc).AddTicks(4605) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "RejectedBy",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "RejectedTime",
                table: "Instructors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedandYasuo",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UpdateTime" },
                values: new object[] { "70965be5-e9cc-4f0c-9245-55cd4462327a", "AQAAAAIAAYagAAAAEBC2+jm8Pedi+8ej6u/ZJTAUg5NGIS9WVKKHNulA7aEbIW6UbTORRWhjUB5QVA1u9Q==", "3b98493c-5ff7-4394-8d3d-25726b9d1cc2", new DateTime(2024, 6, 19, 2, 41, 40, 412, DateTimeKind.Utc).AddTicks(2464) });
        }
    }
}
