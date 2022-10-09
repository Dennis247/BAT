using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class secretanswerFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecretAnswer",
                table: "ProvisionedAdmins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1960), new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1962), new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1962), "$HASH|V1$10000$IZP5ECnHMvXYoTWZSbayf3KsWavV8XKwU0dCoCed0N2BZ0fk" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1866));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecretAnswer",
                table: "ProvisionedAdmins");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9828), new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9831), new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9831), "$HASH|V1$10000$+WeNcsQVesxSeKfKdBBwD0vuPKJTWQIXcAAJYnyFClUwh6We" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9732));
        }
    }
}
