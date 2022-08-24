using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Strategiczne" },
                    { 2, "Przygodowe" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Polski" },
                    { 2, "Angielski" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bard" },
                    { 2, "Rebel" }
                });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "AverageTimeOfPlay", "Description", "ImageBytes", "LanguageId", "MaxNumberOfPlayers", "MinNumberOfPlayers", "Name", "Price", "PublishedYear", "PublisherId", "RecommendedMinimumAge" },
                values: new object[,]
                {
                    { 1, "30 - 45 min", "Usiądź z przyjaciółmi przy stole i wspólnie zacznijcie budować z niewielkich żetonów łąki, twierdze, całe miasta i drogi, rywalizując między sobą o przejęcie kontroli nad co bardziej atrakcyjnymi lokacjami.", null, 1, 5, 2, "Carcassonne", 120m, 2000, 1, 7 },
                    { 2, "30 min", "Splendor jest dynamiczną i niemal uzależniającą grą w zbieranie żetonów i kart, które tworzą zasoby gracza, umożliwiające mu dalszy rozwój. ", null, 1, 4, 2, "Splendor", 130m, 2014, 2, 10 },
                    { 3, "90 - 180 min", "Nagle wybudzasz się z hibernacji. Gdy powoli odzyskujesz świadomość i kontrolę nad własnym ciałem, przypominasz sobie, że jesteś na statku kosmicznym \"Nemesis\".", null, 1, 5, 1, "Nemesis", 500m, 2018, 2, 12 }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CustomerId", "TotalAmount" },
                values: new object[] { 1, 1, 0m });

            migrationBuilder.InsertData(
                table: "BoardGameCategory",
                columns: new[] { "BoardGamesId", "CategoriesId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BoardGameCategory",
                columns: new[] { "BoardGamesId", "CategoriesId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "BoardGameCategory",
                columns: new[] { "BoardGamesId", "CategoriesId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
