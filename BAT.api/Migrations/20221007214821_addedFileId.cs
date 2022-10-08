using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class addedFileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FIleId",
                table: "AnalyzeDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8398), new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8400), new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8401), "$HASH|V1$10000$Q26KirvmRPpIt5exwoyrS9Xcm1PppGfCkTxL4a7ktrAnfW2N" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8160));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FIleId",
                table: "AnalyzeDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(290), new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(293), new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(293), "$HASH|V1$10000$aDJHFEFXGntTN5drNR1LYJe5zXO4WeDYehbYhKaakFLjOQIh" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(96));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(105));
        }
    }
}
