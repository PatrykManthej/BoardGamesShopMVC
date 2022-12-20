using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class AddedShippingDetailsToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentIntentId",
                table: "Orders",
                newName: "TrackingNumber");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippingDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Carrier",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "40a46ce3-6c64-48ca-9ef7-321a012e9456");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "de8b098f-6c5d-43eb-9c04-6356805c67b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "2b142038-e7dd-418a-923a-d9c3927781f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59207e4f-f70c-4fae-ad2f-9a9b5d10c908", "AQAAAAEAACcQAAAAENQft2Cv5X7oZk09FZffJoCMZAGis+Qz8EQG6H/kT/su2GKgxTOjcU+nKlK945zfag==", "eaa4e2b5-6d4e-42bf-83da-ca7c7df1cf34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655a6e17-70d7-40ba-9a1b-861eafbb842b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4501e540-f096-46a7-8fef-2e563e208f3e", "AQAAAAEAACcQAAAAEDQFAtRjcZzLFYPQW0oY3oTSpGEwE+/YiDwdXnGGX/bnV5BPTtGX2Ajls4p6iyc+LA==", "102dee51-9fc4-4b6f-9398-9bd4b0169a28" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrier",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TrackingNumber",
                table: "Orders",
                newName: "PaymentIntentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippingDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "f9d5e770-4eb0-4a45-8461-bd541273f794");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "ae0b5a11-fba5-4d6b-b167-b0f85c63270f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "b101d710-acaf-4463-b779-788f429a7af0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd605179-9a84-4486-ba72-11785f934cbd", "AQAAAAEAACcQAAAAEHZ/cWZfDZskhg1doQX/5FHFs8QSpVtQDRCLui9HF6wRB1sBdh/ahrsO4smZFRKvUQ==", "18c9b8cf-96ae-4e60-8b04-99242e71f4fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655a6e17-70d7-40ba-9a1b-861eafbb842b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d9fa79d-49f1-43e9-8cff-d7f056745e5e", "AQAAAAEAACcQAAAAECdWRuNUc7jKnQFT7C1YcUChq0/M1yeJ+lBnL2xXH8gatfDHFU4j1x8dWGDSvCB+KA==", "0708a6f1-a0d3-4eff-b71b-2d6d19a927c8" });
        }
    }
}
