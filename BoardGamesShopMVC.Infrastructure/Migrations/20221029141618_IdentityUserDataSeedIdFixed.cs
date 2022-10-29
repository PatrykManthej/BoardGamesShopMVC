using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class IdentityUserDataSeedIdFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "79cadc2f-d0df-4fc0-843d-1f6c27bd1844");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "cbf545c7-c2b9-4d14-af88-e7f66bd02664");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "6e7f153e-c67d-4b75-bd9f-1dc105ccd22c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca", 0, "f54f1802-55d7-43c3-a827-71988039b1e2", "admin@test.com", true, false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEAR8OQcEu4YHJ9e2K09R0fwsHGYvaLXS0QJE9XJwq+ErPOT+lqZxt3/utqSmIV5Dtg==", null, false, "2eee9eb9-02b7-4742-a974-bf718ac747fd", false, "admin@test.com" },
                    { "655a6e17-70d7-40ba-9a1b-861eafbb842b", 0, "d830c05e-53f1-430f-81e2-a3cf5a9c65dd", "customer1@test.com", true, false, null, "CUSTOMER1@TEST.COM", "CUSTOMER1@TEST.COM", "AQAAAAEAACcQAAAAEGVofJYfQ7Bp5pP6BU3RWD7DnBZaa4ciuYVfsRBeMoZK7IMlaBl9ouCF/NGa1gK09g==", null, false, "915ed6d6-19b4-42ef-a567-c21edd33c498", false, "customer1@test.com" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "655a6e17-70d7-40ba-9a1b-861eafbb842b");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Admin", "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "User", "655a6e17-70d7-40ba-9a1b-861eafbb842b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "User", "655a6e17-70d7-40ba-9a1b-861eafbb842b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655a6e17-70d7-40ba-9a1b-861eafbb842b");

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
                column: "UserId",
                value: "2649e167-5a2f-438a-878a-453a9b8a28fb");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "User", "2649e167-5a2f-438a-878a-453a9b8a28fb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Admin", "7bbcb6f5-a428-4e0f-adc7-bbc9d5ec7819" });
        }
    }
}
