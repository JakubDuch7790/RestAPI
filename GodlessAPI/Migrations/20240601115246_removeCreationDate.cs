using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GodlessAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeCreationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creation",
                table: "Gods");

            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "Gods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "Gods",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expiration",
                table: "Gods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Expiration" },
                values: new object[] { new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3223), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Expiration" },
                values: new object[] { new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3276), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Expiration" },
                values: new object[] { new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3287), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Expiration" },
                values: new object[] { new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3289), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Expiration" },
                values: new object[] { new DateTime(2024, 5, 29, 13, 41, 58, 433, DateTimeKind.Local).AddTicks(3290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
