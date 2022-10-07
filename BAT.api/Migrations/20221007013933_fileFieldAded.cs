using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class fileFieldAded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fields",
                table: "ProcessedFileDetails",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fields",
                table: "ProcessedFileDetails");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(9065), new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(9067), new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(9067), "$HASH|V1$10000$6GS6mU0nbHaQpG3BNMtm4roRUMzC/urfLbJsFwJmaeJLEHKl" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 6, 19, 17, 33, 810, DateTimeKind.Utc).AddTicks(8982));
        }
    }
}
