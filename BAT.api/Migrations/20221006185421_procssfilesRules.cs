using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class procssfilesRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdministratorName",
                table: "ProcessedFileDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(358), new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(359), new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(360), "$HASH|V1$10000$X7rNRjKgjX68IsD6ZPYsE9ax2yknx70Xv4LHybVUWM/SlmPN" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 54, 21, 445, DateTimeKind.Utc).AddTicks(255));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministratorName",
                table: "ProcessedFileDetails");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4568), new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4569), new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4569), "$HASH|V1$10000$AvkylwPeTrOZwuGevW/Pl0XiP69y3PFsTuO3dvWOyBx99jF1" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4462));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 34, 54, 487, DateTimeKind.Utc).AddTicks(4463));
        }
    }
}
