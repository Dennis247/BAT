using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class nfi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeCohorts",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirtimeUsage",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "UserDatas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncomeClass",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LGA",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumer",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PVC",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PollingUnit",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateOfResidence",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelcoProvider",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VotingLGA",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VotingRAC",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkStatus",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2142), new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2143), new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2145), "$HASH|V1$10000$+KwkzFg2AE1f1j8aGxyqFNRC/U8MNL19P7euRbXwNdsDlpdZ" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 10, 22, 48, 34, 17, DateTimeKind.Utc).AddTicks(2002));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeCohorts",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "AirtimeUsage",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "IncomeClass",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "LGA",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "MobileNumer",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "PVC",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "PollingUnit",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "StateOfResidence",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "TelcoProvider",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "VotingLGA",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "VotingRAC",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "WorkStatus",
                table: "UserDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1960), new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1962), new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1962), "$HASH|V1$10000$IZP5ECnHMvXYoTWZSbayf3KsWavV8XKwU0dCoCed0N2BZ0fk" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 9, 16, 24, 26, 204, DateTimeKind.Utc).AddTicks(1866));
        }
    }
}
