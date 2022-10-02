using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class fileIdNewFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "UserDatas",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Others",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "HourMerged",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "HourProcessed",
                table: "FileUploads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7543), new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7544), new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7544), "$HASH|V1$10000$ZUrZRUWbxxAC+p690fIBwzyiy11QUulKu/o0YCOY9bJNNita" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 2, 10, 46, 11, 7, DateTimeKind.Utc).AddTicks(7444));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "HourProcessed",
                table: "FileUploads");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "UserDatas",
                newName: "Location");

            migrationBuilder.AlterColumn<string>(
                name: "HourMerged",
                table: "FileUploads",
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
    }
}
