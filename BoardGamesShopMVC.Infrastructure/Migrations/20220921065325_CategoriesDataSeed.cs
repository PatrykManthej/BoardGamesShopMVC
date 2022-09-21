using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class CategoriesDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BoardGameCategory",
                columns: new[] { "BoardGamesId", "CategoriesId" },
                values: new object[,]
                {
                    { 5, 2 },
                    { 6, 1 },
                    { 11, 1 },
                    { 12, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Rodzinne" },
                    { 4, "Imprezowe" }
                });

            migrationBuilder.InsertData(
                table: "BoardGameCategory",
                columns: new[] { "BoardGamesId", "CategoriesId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 4 },
                    { 10, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "BoardGameCategory",
                keyColumns: new[] { "BoardGamesId", "CategoriesId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
