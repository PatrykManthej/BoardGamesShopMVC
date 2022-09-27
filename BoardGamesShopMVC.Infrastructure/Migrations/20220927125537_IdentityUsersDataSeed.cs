using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class IdentityUsersDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "e3da8ed8-7ad3-4720-aacf-356384d68489");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "9fe6375a-a377-4010-9b74-3934043856d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "0478fdbd-389a-4d16-b4c5-6d029a15dd03");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2649e167-5a2f-438a-878a-453a9b8a28fb", 0, "885f3d4f-b9e1-47bf-a741-1d2bfe35696f", "customer1@test.com", true, false, null, "CUSTOMER1@TEST.COM", "CUSTOMER1@TEST.COM", "AQAAAAEAACcQAAAAEJozW67DNKI+Z6UDebYbYYjo/zcga9zMfZec0h2fKuQlndnwYmzZYtfF7lY/XL0J8A==", null, false, "9184a6f0-7f53-467e-9412-7b61ee38b8a0", false, "customer1@test.com" },
                    { "7bbcb6f5-a428-4e0f-adc7-bbc9d5ec7819", 0, "3e5138ab-339a-4509-849c-dbaae2fcb1a3", "admin@test.com", true, false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEHu6GygsObw8O+iY8lpluEd5YBm7CKRzo5CSEfxyWVF6rMOb7i+toG/6RD5ctDVQ/A==", null, false, "bdbc00ba-7c04-40f0-8225-f484ba9c3df8", false, "admin@test.com" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "UserId" },
                values: new object[] { null, null, "2649e167-5a2f-438a-878a-453a9b8a28fb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "User", "2649e167-5a2f-438a-878a-453a9b8a28fb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Admin", "7bbcb6f5-a428-4e0f-adc7-bbc9d5ec7819" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "User", "2649e167-5a2f-438a-878a-453a9b8a28fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "7bbcb6f5-a428-4e0f-adc7-bbc9d5ec7819" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2649e167-5a2f-438a-878a-453a9b8a28fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bbcb6f5-a428-4e0f-adc7-bbc9d5ec7819");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "1e303328-1448-419e-b7cf-6157c7bcacd4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "4a58ff35-f7b8-49e5-8666-8434e96cc1f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "379f274f-a7b1-4f1b-8f22-095e4ac9d9cf");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Test", "Test" });
        }
    }
}
