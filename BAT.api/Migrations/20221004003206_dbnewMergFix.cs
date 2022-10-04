using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class dbnewMergFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MergedIds",
                table: "FileUploads",
                newName: "MergedDetails");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(3048), new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(3050), new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(3051), "$HASH|V1$10000$xYPWwI6H9W4s7Bhf8etv2c4HxaKk+LEGr2ml79xrIbBo3dgw" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 4, 0, 32, 5, 748, DateTimeKind.Utc).AddTicks(2894));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MergedDetails",
                table: "FileUploads",
                newName: "MergedIds");

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
    }
}
