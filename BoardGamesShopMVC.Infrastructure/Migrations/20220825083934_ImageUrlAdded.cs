using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class ImageUrlAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_BoardGameId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ImageBytes",
                table: "BoardGames");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BoardGameId",
                table: "Stocks",
                column: "BoardGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_BoardGameId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BoardGames");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBytes",
                table: "BoardGames",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BoardGameId",
                table: "Stocks",
                column: "BoardGameId",
                unique: true);
        }
    }
}
