using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class filefieldNewFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Others",
                table: "UserDatas",
                newName: "FileFields");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileFields",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "FileFields",
                table: "FileUploads");

            migrationBuilder.RenameColumn(
                name: "FileFields",
                table: "UserDatas",
                newName: "Others");

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
    }
}
