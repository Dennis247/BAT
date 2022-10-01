using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class IsPrivateAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdminPrivate",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6369), new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6370), new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6370), "$HASH|V1$10000$xN446MsJe4SZ0L4oxBfAcwWuhgop59Ue7tC37oxjum5R6d8v" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6256));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdminPrivate",
                table: "Accounts");

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
    }
}
