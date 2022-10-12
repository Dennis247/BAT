using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class kefixadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HourProcessed",
                table: "ProcessedFileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5981), new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5984), new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5985), "$HASH|V1$10000$OHBB7X9r0UdKqLUxSV8I2cd+3t2RvRRzei9tfzQPH1tBRsPt" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 12, 22, 54, 54, 373, DateTimeKind.Utc).AddTicks(5646));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourProcessed",
                table: "ProcessedFileDetails");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5775), new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5777), new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5778), "$HASH|V1$10000$hG06ad1+tuUPIqXMfJoebitqGnwYVlDe5TE25pBznrTyrhhV" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 11, 5, 59, 14, 43, DateTimeKind.Utc).AddTicks(5627));
        }
    }
}
