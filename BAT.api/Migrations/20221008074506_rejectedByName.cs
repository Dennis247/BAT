using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class rejectedByName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectedByName",
                table: "ExportRequests",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectedByName",
                table: "ExportRequests");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3197), new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3198), new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3198), "$HASH|V1$10000$y5HJEpdDS1K0O1VItquXPEM0ptzHxDmr8yVTwznbl6k8jHsH" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3104));
        }
    }
}
