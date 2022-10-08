using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class epotData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessDownloadUrl",
                table: "AnalyzeDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7492), new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7494), new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7494), "$HASH|V1$10000$sXYkK4aP9YhBMIvcs54rpCrQSDEr6PXGTEI5W11XUoieZKrO" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7339));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 8, 11, 43, 6, 223, DateTimeKind.Utc).AddTicks(7343));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessDownloadUrl",
                table: "AnalyzeDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5939), new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5941), new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5941), "$HASH|V1$10000$y96FNyHt+Ywi5AqUZVJdditRbe31JsHHZQ5gz1ym52UZJYxi" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 8, 7, 45, 5, 559, DateTimeKind.Utc).AddTicks(5765));
        }
    }
}
