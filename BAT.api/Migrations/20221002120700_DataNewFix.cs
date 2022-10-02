using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class DataNewFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateSaved",
                table: "FileUploads",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInPreviewMode",
                table: "FileUploads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5669), new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5670), new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5671), "$HASH|V1$10000$milatP9yH48VVtk1ugvYtyU36mdtH+g8tnTZHDNfYOWuo3T6" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5559));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 2, 12, 7, 0, 489, DateTimeKind.Utc).AddTicks(5565));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSaved",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "IsInPreviewMode",
                table: "FileUploads");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7543), new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7544), new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7544), "$HASH|V1$10000$ZUrZRUWbxxAC+p690fIBwzyiy11QUulKu/o0YCOY9bJNNita" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7444));
        }
    }
}
