using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class mobilefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MobileNumer",
                table: "UserDatas",
                newName: "MobileNumber");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "UserDatas",
                newName: "MobileNumer");

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
    }
}
