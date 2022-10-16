using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class pneTypeFi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobilephoneType",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6672), new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6673), new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6674), "$HASH|V1$10000$sG2ItUBYnmedBfXa4/Eclp+OKL/gH5o2WEFmfUywJaoY6oq5" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 16, 14, 387, DateTimeKind.Utc).AddTicks(6504));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilephoneType",
                table: "UserDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3714), new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3716), new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3716), "$HASH|V1$10000$fbkmWGldyaVJnpis2rhOQ8tCVK7qkyXOEoY7mPsmHY/JmU8I" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 11, 28, 604, DateTimeKind.Utc).AddTicks(3589));
        }
    }
}
