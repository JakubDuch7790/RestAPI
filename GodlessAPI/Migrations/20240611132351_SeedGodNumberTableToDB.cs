using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GodlessAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedGodNumberTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GodsNumbers",
                columns: table => new
                {
                    GodNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GodsNumbers", x => x.GodNo);
                });

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 5,
                column: "Creation",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.InsertData(
                table: "GodsNumbers",
                columns: new[] { "GodNo", "CreationDate", "SpecialDetails", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4940), "SuperVision", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4943), "BigDick", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 333, new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4945), "SuperYoung", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 458, new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4948), "Tripple Nipple", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 566, new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4949), "TechKing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GodsNumbers");

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
    }
}
