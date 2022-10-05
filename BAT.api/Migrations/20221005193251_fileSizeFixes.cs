using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class fileSizeFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileFields",
                table: "FileUploads",
                newName: "Fields");

            migrationBuilder.AlterColumn<double>(
                name: "FileSize",
                table: "FileUploads",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fields",
                table: "FileUploads",
                newName: "FileFields");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "FileUploads",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4927), new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4929), new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4929), "$HASH|V1$10000$DLklZLI0TZuCB9KDuuMInFoNgPH7vexvr6EVz5HWREM2NtKI" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 24, 9, 71, DateTimeKind.Utc).AddTicks(4815));
        }
    }
}
