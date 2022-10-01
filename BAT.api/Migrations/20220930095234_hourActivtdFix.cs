﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class hourActivtdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HourActivated",
                table: "UserActivations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourActivated",
                table: "UserActivations");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6831), new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6833), new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6833), "$HASH|V1$10000$/OtzsMmlag51as2Nj6n+MBTuW3hb/jODDc3q5F+4eZdwhu6q" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6695));
        }
    }
}