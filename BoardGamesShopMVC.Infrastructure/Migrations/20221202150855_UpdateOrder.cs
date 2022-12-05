using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class UpdateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Orders",
                newName: "ShippingDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "9ed520e8-a761-4ff3-9750-b31cb3247362");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "ecfc4908-14d1-4e4a-9a89-38a273245e2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "7acd8a8f-1355-48ba-9cf8-bfae2f485dd4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efe82b7d-2a28-4c06-9063-3e04ab9d3d6c", "AQAAAAEAACcQAAAAEENDbaKb5Zv0adLZWuZjbLIrFMsaosV1TmMobfxkfb+skX/gtY2ESJq6G7YY1KN2Qw==", "d881b914-7f2d-4baf-80a5-c7772c2cf5fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655a6e17-70d7-40ba-9a1b-861eafbb842b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f003f710-9295-42e0-a55e-a54a62182ba4", "AQAAAAEAACcQAAAAEOsxeOsCC2K5sH9sJBj4bFrw+oRVvXC3BDycAQ0hkYF5a4R7BKFR1mADQzakdcwwlw==", "cd18782e-3543-4613-a003-ea4f78495bf8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingDate",
                table: "Orders",
                newName: "Date");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "a7a233ad-42ed-4af6-bcc7-78d5767ff064");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "ce02d274-3576-4db8-9c19-5896eaa2b1a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "eb44d9ba-d4b8-4720-aa80-250217796d57");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86f53fa3-30df-4f41-9f0e-b79f612191fc", "AQAAAAEAACcQAAAAEAlYtVlIe1TgUGeT+e3udMascC9R5KuZetWF2XizX5y0wc+yq6ehto1StoMnEB705Q==", "9f9105be-1315-4696-a72d-028de77690fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655a6e17-70d7-40ba-9a1b-861eafbb842b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "596e65b0-8567-4138-9e27-d36e2efd06cd", "AQAAAAEAACcQAAAAEAeoU3akVNDh2Xfb6PmalLQXC6rFrlD7iT9JIU+MMHJ7YIS75FObwxeBHl7uJTL3Tw==", "c1ec0904-b861-4611-b3c8-77ec169acb17" });
        }
    }
}
