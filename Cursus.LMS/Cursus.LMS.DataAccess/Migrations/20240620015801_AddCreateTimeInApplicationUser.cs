using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursus.LMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateTimeInApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedandYasuo",
                columns: new[] { "ConcurrencyStamp", "CreateTime", "PasswordHash", "SecurityStamp", "UpdateTime" },
                values: new object[] { "234028a0-ae5c-4ea0-bbc1-bd8307b07aaa", new DateTime(2024, 6, 20, 1, 57, 58, 868, DateTimeKind.Utc).AddTicks(5955), "AQAAAAIAAYagAAAAEPXDUwGa0Qs94vBYPSOMGe4rJ2Q34MocFXLY/Ho6l6MRE80RgD3josZst0BgXXmaTQ==", "5ced7d9f-9f95-494c-99b7-13aa8df643b6", new DateTime(2024, 6, 20, 1, 57, 58, 969, DateTimeKind.Utc).AddTicks(128) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BestZedandYasuo",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UpdateTime" },
                values: new object[] { "5d615361-3681-458a-a61a-0ab82760942f", "AQAAAAIAAYagAAAAEGFToPJFpj0EU8gQU+6ym20YEYoPjhHkuuYPxCI1zek/rHZfyjShF+lC/P+Cscfnew==", "260d1548-9211-45b5-9b85-93f36bc43ef3", new DateTime(2024, 6, 19, 2, 45, 32, 156, DateTimeKind.Utc).AddTicks(4605) });
        }
    }
}
