using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GodlessAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCreationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "Gods",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5277));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5334));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 5,
                column: "Creation",
                value: new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5335));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creation",
                table: "Gods");
        }
    }
}
