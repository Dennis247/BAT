﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class generfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5516), new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5518), new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5518), "$HASH|V1$10000$9HIaoRvV7q52B8fAUUU8uaIQXVr3775faIu8fnbp6IqJD+jI" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 10, 23, 9, 41, 182, DateTimeKind.Utc).AddTicks(5412));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2142), new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2143), new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2145), "$HASH|V1$10000$+KwkzFg2AE1f1j8aGxyqFNRC/U8MNL19P7euRbXwNdsDlpdZ" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2002));
        }
    }
}