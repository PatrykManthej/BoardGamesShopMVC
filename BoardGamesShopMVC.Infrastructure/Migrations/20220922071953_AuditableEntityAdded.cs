using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class AuditableEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Stocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inactivated",
                table: "Stocks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Stocks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Publishers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inactivated",
                table: "Publishers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Publishers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Publishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Languages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inactivated",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inactivated",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "BoardGames",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inactivated",
                table: "BoardGames",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "BoardGames",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 6,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 7,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 8,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 9,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 10,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 11,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 12,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 6,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 7,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 8,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 9,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 10,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 11,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 12,
                column: "StatusId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Inactivated",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Inactivated",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Inactivated",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Inactivated",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Inactivated",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "BoardGames");
        }
    }
}
