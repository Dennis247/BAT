using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class processGer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessedIds",
                table: "FileUploads");

            migrationBuilder.AlterColumn<string>(
                name: "FileSize",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "TotalRecordCount",
                table: "FileUploads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnalyzeDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExportStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    ExportedBy = table.Column<int>(type: "int", nullable: false),
                    AnalyzedRecord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyzeDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessedFileDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateProcessed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedBy = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    ProcessedDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessedFileDetails", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyzeDatas");

            migrationBuilder.DropTable(
                name: "ProcessedFileDetails");

            migrationBuilder.DropColumn(
                name: "TotalRecordCount",
                table: "FileUploads");

            migrationBuilder.AlterColumn<double>(
                name: "FileSize",
                table: "FileUploads",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ProcessedIds",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5744), new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5745), new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5746), "$HASH|V1$10000$KZagLOauO3TZPMJmszZTwAT/SRaJd6Ld9L7BIZTdt6m0Nta0" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 5, 19, 39, 53, 563, DateTimeKind.Utc).AddTicks(5648));
        }
    }
}
