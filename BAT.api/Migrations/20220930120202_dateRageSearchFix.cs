using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class dateRageSearchFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateProcessed",
                table: "FileUploads",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HourMerged",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HourUploaded",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "FileUploads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProcessedBy",
                table: "FileUploads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessedIds",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6467), new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6471), new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6472), "$HASH|V1$10000$bxWiMGfpsUGPaTc0DW2Ya10Kmm0EW6JeGfn3dS4R5tEAjwTo" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 30, 12, 2, 1, 853, DateTimeKind.Utc).AddTicks(6214));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateProcessed",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "HourMerged",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "HourUploaded",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "ProcessedBy",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "ProcessedIds",
                table: "FileUploads");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4417), new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4421), new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4422), "$HASH|V1$10000$fQgU/pNSwJm4Z9rv3Gg7dp0D6wYn0ireQpVwxDeCAPn8UB1p" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 30, 9, 52, 33, 800, DateTimeKind.Utc).AddTicks(4026));
        }
    }
}
