using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class exportFI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExportedBy",
                table: "AnalyzeDatas");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "AnalyzeDatas",
                newName: "ApprovedBy");

            migrationBuilder.RenameColumn(
                name: "ExportStatus",
                table: "AnalyzeDatas",
                newName: "ApprovedByName");

            migrationBuilder.AddColumn<string>(
                name: "AdminName",
                table: "AnalyzeDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsApprovedByAdmin",
                table: "AnalyzeDatas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ExportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedBy = table.Column<int>(type: "int", nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalyzeRequestId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateApproved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRejected = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectedBy = table.Column<int>(type: "int", nullable: true),
                    ExportStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportRequests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(290), new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(293), new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(293), "$HASH|V1$10000$aDJHFEFXGntTN5drNR1LYJe5zXO4WeDYehbYhKaakFLjOQIh" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(96));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 18, 33, 22, 79, DateTimeKind.Utc).AddTicks(105));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportRequests");

            migrationBuilder.DropColumn(
                name: "AdminName",
                table: "AnalyzeDatas");

            migrationBuilder.DropColumn(
                name: "IsApprovedByAdmin",
                table: "AnalyzeDatas");

            migrationBuilder.RenameColumn(
                name: "ApprovedByName",
                table: "AnalyzeDatas",
                newName: "ExportStatus");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy",
                table: "AnalyzeDatas",
                newName: "FileId");

            migrationBuilder.AddColumn<int>(
                name: "ExportedBy",
                table: "AnalyzeDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4411), new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4413), new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4416), "$HASH|V1$10000$bAa2dv7cDXK/alt+HiH5JDZWOnAoz2iKvgSDfJIP8mixvdKL" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 1, 53, 29, 274, DateTimeKind.Utc).AddTicks(4262));
        }
    }
}
