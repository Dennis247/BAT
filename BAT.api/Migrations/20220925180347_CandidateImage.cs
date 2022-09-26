using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class CandidateImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandiateImage",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandiateImage",
                table: "Candidates");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7371), new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7372), new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7373), "$HASH|V1$10000$eRRuxwfi1eOLn+jS4vfw37Xt0oD2FXHuO7WwVskzIuF0LGKc" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7266));
        }
    }
}
