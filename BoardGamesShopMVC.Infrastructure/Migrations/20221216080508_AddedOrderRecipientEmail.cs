using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class AddedOrderRecipientEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrderRecipients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrderRecipients");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "cf9d4c9f-44c5-4771-8a3c-d96dd0160655");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "ced49558-c8b7-4d7d-9c66-ce043e650b66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "abffd935-bdca-4ba6-ba63-a09b05fa9fd9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2c79527-1fc4-460c-8187-ab5a0ac31c24", "AQAAAAEAACcQAAAAEDUdLMmG6u5BBgrakV5mFR1FQG6SaC3cJeii8irDyRIdZ9p+EGU+kxeaM/8eq7Hy1A==", "97703d40-3b21-4e6b-89b2-9074f45e125c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655a6e17-70d7-40ba-9a1b-861eafbb842b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4db98f12-96ac-4c2f-a3e6-689a39f13e4b", "AQAAAAEAACcQAAAAEK+W+N9nUwM7wU3t4UO4MXJskdTF5pmjGT7v4e40KMR1GuCgtjKixFVDaQBaA0rILQ==", "df9cd81f-17dd-46ae-a0e8-7c6ea3333ceb" });
        }
    }
}
