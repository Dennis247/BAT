using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class dbmigrationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayOfTheWeek",
                table: "UserActivations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DayOfTheYear",
                table: "UserActivations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8986), new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8989), new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8990), "$HASH|V1$10000$U4pSKxVegGKcGG1t4p0wF7C3QwfDCt3Z6Lt4JuG2fEyf5+H4" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8775));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "UserActivations");

            migrationBuilder.DropColumn(
                name: "DayOfTheYear",
                table: "UserActivations");

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
    }
}
