using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class processedfileCOuntAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessedItemCount",
                table: "ProcessedFileDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UploadedFileCount",
                table: "ProcessedFileDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessedItemCount",
                table: "ProcessedFileDetails");

            migrationBuilder.DropColumn(
                name: "UploadedFileCount",
                table: "ProcessedFileDetails");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8398), new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8400), new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8401), "$HASH|V1$10000$Q26KirvmRPpIt5exwoyrS9Xcm1PppGfCkTxL4a7ktrAnfW2N" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 7, 21, 48, 21, 431, DateTimeKind.Utc).AddTicks(8160));
        }
    }
}
