using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class columnfiledFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HourUploaded",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fields",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5744), new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5745), new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5746), "$HASH|V1$10000$KZagLOauO3TZPMJmszZTwAT/SRaJd6Ld9L7BIZTdt6m0Nta0" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5648));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HourUploaded",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fields",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(4020), new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(4022), new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(4023), "$HASH|V1$10000$Eqbn2qIsBYSKRnRaX0hwUKM4O6mcM0DYZmR0HXonMn6bWxPN" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 32, 51, 1, DateTimeKind.Utc).AddTicks(3752));
        }
    }
}
