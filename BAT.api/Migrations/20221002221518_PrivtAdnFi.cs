using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class PrivtAdnFi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivateAdmin",
                table: "ProvisionedAdmins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8747), new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8748), new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8748), "$HASH|V1$10000$leFG2YrkntDhhwnW7X8f86VQP1+cAfUJkjYCYghFlmTLscBT" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8645));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivateAdmin",
                table: "ProvisionedAdmins");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2368), new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2370), new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2371), "$HASH|V1$10000$AIWdlaS7mU4yDD9seEFyKsrRjy8j9jgyGc7CAysJoCLi4t1L" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 2, 14, 2, 44, 496, DateTimeKind.Utc).AddTicks(2124));
        }
    }
}
