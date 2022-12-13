using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class AddedOrderPaymentInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Orders");

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
        }
    }
}
