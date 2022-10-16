using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class adddStateOfOrginFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StateofOrigin",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2865), new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2866), new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2867), "$HASH|V1$10000$Jp7hjP/3aG2ryLZPX7J/GmkhFaJP25hgEupcoWmJT2Xd0M7l" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2704));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2707));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2715));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 16, 17, 6, 55, 222, DateTimeKind.Utc).AddTicks(2717));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateofOrigin",
                table: "UserDatas");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8986), new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8989), new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8990), "$HASH|V1$10000$U4pSKxVegGKcGG1t4p0wF7C3QwfDCt3Z6Lt4JuG2fEyf5+H4" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 13, 15, 36, 2, 929, DateTimeKind.Utc).AddTicks(8775));
        }
    }
}
