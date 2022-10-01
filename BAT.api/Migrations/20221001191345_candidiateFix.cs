using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class candidiateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeModified",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MoidifiedBy",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5435), new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5438), new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5441), "$HASH|V1$10000$q4m4L70sR6UiPGzME/a64KpYYze30Uo6+SYRJuWxVnFVFJ0s" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 1, 19, 13, 44, 664, DateTimeKind.Utc).AddTicks(5228));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastTimeModified",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "MoidifiedBy",
                table: "Candidates");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6369), new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6370), new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6370), "$HASH|V1$10000$xN446MsJe4SZ0L4oxBfAcwWuhgop59Ue7tC37oxjum5R6d8v" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 30, 13, 59, 58, 585, DateTimeKind.Utc).AddTicks(6256));
        }
    }
}
