using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class igFi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CandiateImage",
                table: "Candidates",
                newName: "CandidateImage");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CandidateImage",
                table: "Candidates",
                newName: "CandiateImage");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5869), new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5870), new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5871), "$HASH|V1$10000$/0Z01ITWKMuh5XAPQiyoshdNDY0VFpr57YtIY3BnB6TQMaEp" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5743));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5743));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 25, 18, 3, 46, 799, DateTimeKind.Utc).AddTicks(5747));
        }
    }
}
