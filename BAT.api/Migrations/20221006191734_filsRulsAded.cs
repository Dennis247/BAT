using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class filsRulsAded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DownloadUrl",
                table: "ProcessedFileDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(9065), new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(9067), new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(9067), "$HASH|V1$10000$6GS6mU0nbHaQpG3BNMtm4roRUMzC/urfLbJsFwJmaeJLEHKl" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8982));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownloadUrl",
                table: "ProcessedFileDetails");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(358), new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(359), new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(360), "$HASH|V1$10000$X7rNRjKgjX68IsD6ZPYsE9ax2yknx70Xv4LHybVUWM/SlmPN" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(255));
        }
    }
}
