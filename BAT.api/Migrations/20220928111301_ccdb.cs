using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class ccdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(5047), new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(5049), new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(5050), "$HASH|V1$10000$s/gVEdqOcUlL0x5r5sBfsgCPghpKg7NTuA3BJWZ8pLzRaiSt" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4869));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedBy",
                table: "UserDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6157), new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6158), new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6158), "$HASH|V1$10000$eKoVY3MlMPCCsQ0qiqXt/LCMxP01EC5xm+IhTzogCCcLY9US" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6049));
        }
    }
}
