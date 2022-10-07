using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class TitleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProcessedFileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4411), new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4413), new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4416), "$HASH|V1$10000$bAa2dv7cDXK/alt+HiH5JDZWOnAoz2iKvgSDfJIP8mixvdKL" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4262));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProcessedFileDetails");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6777), new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6779), new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6780), "$HASH|V1$10000$tyMhv6E3xHzoLWypRw7YVtiOaV0mb6uBRDwtyWSK+NXSVCPK" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6652));
        }
    }
}
