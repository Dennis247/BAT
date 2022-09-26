using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class fileUploadDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileUploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    FileUploadType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUploads", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4665), new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4666), new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4667), "$HASH|V1$10000$g7rteALa8aDJMq1DImBxP3gR+NqAHtFevcm/QlyMddpllbiE" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 26, 12, 38, 47, 300, DateTimeKind.Utc).AddTicks(4569));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileUploads");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5946), new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5948), new DateTime(2022, 9, 25, 22, 14, 15, 53, DateTimeKind.Utc).AddTicks(5949), "$HASH|V1$10000$Uax+AfruJDFFxu7fbuzWL3ju3wayMm1RStYw2UwoQb358eQe" });

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
    }
}
