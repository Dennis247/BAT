using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class filmiationfixxed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessedDetails",
                table: "ProcessedFileDetails",
                newName: "ProcessRule");

            migrationBuilder.RenameColumn(
                name: "ProcessedBy",
                table: "ProcessedFileDetails",
                newName: "Administrator");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ProcessedFileDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ProcessedFileDetails");

            migrationBuilder.RenameColumn(
                name: "ProcessRule",
                table: "ProcessedFileDetails",
                newName: "ProcessedDetails");

            migrationBuilder.RenameColumn(
                name: "Administrator",
                table: "ProcessedFileDetails",
                newName: "ProcessedBy");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(3036), new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(3038), new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(3038), "$HASH|V1$10000$W2cL4IolBeWeQvQsQUbzIfOAN3FM3Uvn8HW5l0HY8Bjpadej" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2917));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2918));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2919));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2919));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 6, 18, 1, 1, 304, DateTimeKind.Utc).AddTicks(2920));
        }
    }
}
