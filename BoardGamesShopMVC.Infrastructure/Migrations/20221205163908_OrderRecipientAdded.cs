using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class OrderRecipientAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderRecipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRecipients_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "01426701-9d9a-43c3-b68a-97cb80b589bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "07cf141b-1d1a-4783-8909-56c735a429be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "332fb3a5-0f56-402d-b3f0-6bad60238be5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e50d59a3-cd38-465a-9506-66483f37601a", "AQAAAAEAACcQAAAAEOLGBJYCSqJgsPFzKbIG6JR+YUyrehmXoVsrklfAvOR9BFriy57qqOULdIi9TQEbNg==", "3aa15e5a-566c-4cc2-bd9b-0e6137407c20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655a6e17-70d7-40ba-9a1b-861eafbb842b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b329271-c404-463f-a738-7997ea2dfb2b", "AQAAAAEAACcQAAAAEHU+aXhPfs49GwJNMTyFO1xxHCJ+s2zKLEihA9bOkZ8LkCpX0qwTIVfqII/P+SfWRQ==", "62a4992e-73a0-467c-a7a1-8764b9bcc9b8" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderRecipients_OrderId",
                table: "OrderRecipients",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderRecipients");

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
    }
}
