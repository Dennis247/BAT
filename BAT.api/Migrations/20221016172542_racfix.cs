using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class racfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RAC",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9875), new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9877), new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9877), "$HASH|V1$10000$JxVtjI5Fn2Fe6vePTm6O0wSFgSflXa+6lCRJr+YT1RpPWqBv" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9716));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RAC",
                table: "UserDatas");

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
    }
}
