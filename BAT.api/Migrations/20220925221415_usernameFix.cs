using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class usernameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash", "Username" },
                values: new object[] { new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5946), new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5948), new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5949), "$HASH|V1$10000$Uax+AfruJDFFxu7fbuzWL3ju3wayMm1RStYw2UwoQb358eQe", "mustang247" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5851));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7975), new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7978), new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7978), "$HASH|V1$10000$vQzkP6uxfdPMlaZ774JK02SWIG7QmiOx+BaeMhEKmntaWnoJ" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 25, 20, 17, 38, 961, DateTimeKind.Utc).AddTicks(7762));
        }
    }
}
