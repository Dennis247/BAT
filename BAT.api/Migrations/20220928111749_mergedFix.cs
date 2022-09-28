using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class mergedFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MergedIds",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MergedBy",
                table: "FileUploads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2505), new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2509), new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2510), "$HASH|V1$10000$bvNROzRadqRxQd7m31EhnhsNfk0XOlIn/TyhQS2+7yykGU2e" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 17, 48, 938, DateTimeKind.Utc).AddTicks(2284));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MergedIds",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MergedBy",
                table: "FileUploads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2961), new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2963), new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2964), "$HASH|V1$10000$Xj6tkd2vdC4uFfbt5EoMNqajoKZ5+CXrDLniYYfrqTRk/y7g" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 27, 982, DateTimeKind.Utc).AddTicks(2788));
        }
    }
}
