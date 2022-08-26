using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class StockAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_BoardGames_BoardGameId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BoardGameId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "BoardGameId",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Quantity" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Quantity" },
                values: new object[] { 2, 7 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Quantity" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "StockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 2,
                column: "StockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 3,
                column: "StockId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_StockId",
                table: "BoardGames",
                column: "StockId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_Stocks_StockId",
                table: "BoardGames",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_Stocks_StockId",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_StockId",
                table: "BoardGames");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "BoardGames");

            migrationBuilder.AddColumn<int>(
                name: "BoardGameId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BoardGameId",
                table: "Stocks",
                column: "BoardGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_BoardGames_BoardGameId",
                table: "Stocks",
                column: "BoardGameId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
