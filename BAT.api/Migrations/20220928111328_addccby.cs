using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class addccby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "UserDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(5047), new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(5049), new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(5050), "$HASH|V1$10000$s/gVEdqOcUlL0x5r5sBfsgCPghpKg7NTuA3BJWZ8pLzRaiSt" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 28, 11, 13, 0, 631, DateTimeKind.Utc).AddTicks(4869));
        }
    }
}
