using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GodlessAPI.Migrations
{
    /// <inheritdoc />
    public partial class potentialChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Gods",
                keyColumn: "Id",
                keyValue: 5,
                column: "Creation",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 333,
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 458,
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 566,
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 13, 32, 55, 467, DateTimeKind.Local).AddTicks(3608));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 333,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 458,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "GodsNumbers",
                keyColumn: "GodNo",
                keyValue: 566,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 15, 23, 50, 844, DateTimeKind.Local).AddTicks(4949));
        }
    }
}
