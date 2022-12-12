using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class RelationBoardGameCartOrderItemFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItems_BoardGameId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_BoardGameId",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "28a05819-dc5b-476c-87a3-e1196619f4ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "ef08e60f-1230-4b23-9ad2-ca1d3ebff33a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "cb61558e-e82c-4666-8e02-08a3c77bbb3e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27961cec-75e1-4527-8b2f-270f43e97146", "AQAAAAEAACcQAAAAEONUkrFxwlC1VVpkONf8rQylbuvNCGmCDRquNW7qbTceXIgI83PCyQx9Obrb2pvi+g==", "7c7b554f-5dab-4019-95b9-a4913c75fd58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655a6e17-70d7-40ba-9a1b-861eafbb842b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "599e9f44-74d1-4e58-b368-614c2bff7b62", "AQAAAAEAACcQAAAAEJFG+EjWjEWouCOdtKmfXhhNmX8bREl6bhgqDjuEFxA6TE7Hoz6rv2yo5v24GIb6MQ==", "6d152ea4-760a-4761-9fe5-191834af9506" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BoardGameId",
                table: "OrderItems",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BoardGameId",
                table: "CartItems",
                column: "BoardGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItems_BoardGameId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_BoardGameId",
                table: "CartItems");

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
                name: "IX_OrderItems_BoardGameId",
                table: "OrderItems",
                column: "BoardGameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BoardGameId",
                table: "CartItems",
                column: "BoardGameId",
                unique: true);
        }
    }
}
