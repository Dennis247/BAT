using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class weekActivatedFIx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeekActivated",
                table: "UserActivations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6831), new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6833), new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6833), "$HASH|V1$10000$/OtzsMmlag51as2Nj6n+MBTuW3hb/jODDc3q5F+4eZdwhu6q" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 30, 7, 38, 35, 843, DateTimeKind.Utc).AddTicks(6695));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekActivated",
                table: "UserActivations");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9602), new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9603), new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9604), "$HASH|V1$10000$xnKMiCToXLOtLNZ0ynexKUoIVN/oyO/hbxfK5ATUyjuVgk8n" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 29, 21, 25, 23, 402, DateTimeKind.Utc).AddTicks(9495));
        }
    }
}
