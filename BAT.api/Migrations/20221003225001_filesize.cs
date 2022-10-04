using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class filesize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "FileUploads",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7497), new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7500), new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7501), "$HASH|V1$10000$WIWwjye34cGHqFP03b5YlB8oLMy6pG39/Rtke0KfN2AyEnEP" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 3, 22, 50, 0, 855, DateTimeKind.Utc).AddTicks(7337));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "FileUploads");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8747), new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8748), new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8748), "$HASH|V1$10000$leFG2YrkntDhhwnW7X8f86VQP1+cAfUJkjYCYghFlmTLscBT" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 2, 22, 15, 18, 248, DateTimeKind.Utc).AddTicks(8645));
        }
    }
}
