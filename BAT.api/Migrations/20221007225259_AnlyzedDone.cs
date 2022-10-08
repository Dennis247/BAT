using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class AnlyzedDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApprovedByName",
                table: "AnalyzeDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AnalyzedRecord",
                table: "AnalyzeDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3197), new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3198), new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3198), "$HASH|V1$10000$y5HJEpdDS1K0O1VItquXPEM0ptzHxDmr8yVTwznbl6k8jHsH" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 52, 59, 575, DateTimeKind.Utc).AddTicks(3104));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApprovedByName",
                table: "AnalyzeDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnalyzedRecord",
                table: "AnalyzeDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3699), new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3700), new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3701), "$HASH|V1$10000$T2cNy3L9YX/4AygZKt1cQe7qJtzTZ6q6ULaEPMC/SvuNd7//" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3555));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3557));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 22, 20, 56, 60, DateTimeKind.Utc).AddTicks(3559));
        }
    }
}
