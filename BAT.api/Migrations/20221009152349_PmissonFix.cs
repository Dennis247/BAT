using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAT.api.Migrations
{
    public partial class PmissonFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9828), new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9831), new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9831), "$HASH|V1$10000$+WeNcsQVesxSeKfKdBBwD0vuPKJTWQIXcAAJYnyFClUwh6We" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9724), 1 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9726), 2 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9727), 3 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9727), 4 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9728), 5 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9729), 6 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9729), 7 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9730), 8 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9731), 9 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9731), 10 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "PermissionId" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 23, 48, 693, DateTimeKind.Utc).AddTicks(9732), 11 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastTimeLoggedIn", "LoggedOutTime", "PasswordHash" },
                values: new object[] { new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4391), new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4392), new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4393), "$HASH|V1$10000$Mog/03PuxS97ME+GN7QcRqrgn0I7hhOnjgsStocHOaC9fgZU" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 10, 9, 15, 15, 9, 166, DateTimeKind.Utc).AddTicks(4264));
        }
    }
}
