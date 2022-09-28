using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class colfixnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "UserDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedBy",
                table: "UserDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateMerged",
                table: "FileUploads",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                table: "FileUploads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MergedBy",
                table: "FileUploads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MergedIds",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6157), new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6158), new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6158), "$HASH|V1$10000$eKoVY3MlMPCCsQ0qiqXt/LCMxP01EC5xm+IhTzogCCcLY9US" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 28, 0, 34, 56, 455, DateTimeKind.Utc).AddTicks(6049));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "DateMerged",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "IsMerged",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "MergedBy",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "MergedIds",
                table: "FileUploads");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(4046), new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(4048), new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(4048), "$HASH|V1$10000$ffoZHkfDPMvc0KEhbHEexJIZkVTI1MYvAE6RQc38PHHXVGHV" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 27, 20, 52, 52, 754, DateTimeKind.Utc).AddTicks(3885));
        }
    }
}
