using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class anaFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessDownloadUrl",
                table: "AnalyzeDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5358), new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5360), new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5360), "$HASH|V1$10000$jmAsvC+B4Z9cNLXfzpseNe+o80tt8aObSZXLobwutDiHe2X0" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 8, 12, 14, 20, 892, DateTimeKind.Utc).AddTicks(5163));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
