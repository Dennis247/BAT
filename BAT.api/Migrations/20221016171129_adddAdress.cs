using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class adddAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2865), new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2866), new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2867), "$HASH|V1$10000$Jp7hjP/3aG2ryLZPX7J/GmkhFaJP25hgEupcoWmJT2Xd0M7l" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2704));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2707));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2715));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2717));
        }
    }
}
