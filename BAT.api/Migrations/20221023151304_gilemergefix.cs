using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class gilemergefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3405), new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3407), new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3407), "$HASH|V1$10000$4mzhi2moi1jR7cmGKfcGJlpeCMkqBq9SCVN6V+GY7r/H/Jvp" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3279));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 23, 15, 13, 3, 722, DateTimeKind.Utc).AddTicks(3282));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9875), new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9877), new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9877), "$HASH|V1$10000$JxVtjI5Fn2Fe6vePTm6O0wSFgSflXa+6lCRJr+YT1RpPWqBv" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 25, 42, 27, DateTimeKind.Utc).AddTicks(9716));
        }
    }
}
