using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GodlessAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTestingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Gods",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Gods",
                columns: new[] { "Id", "Creation", "Expiration", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3223), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product A" },
                    { 2, new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3276), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thor" },
                    { 3, new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3287), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Odin A" },
                    { 4, new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3289), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thanos A" },
                    { 5, new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julius A" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Gods",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
