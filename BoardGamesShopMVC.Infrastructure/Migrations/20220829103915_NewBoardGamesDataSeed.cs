using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesShopMVC.Infrastructure.Migrations
{
    public partial class NewBoardGamesDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameTag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Albi" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Quantity" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 6 },
                    { 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "AverageTimeOfPlay", "Description", "ImageUrl", "LanguageId", "MaxNumberOfPlayers", "MinNumberOfPlayers", "Name", "Price", "PublishedYear", "PublisherId", "RecommendedMinimumAge", "StockId" },
                values: new object[,]
                {
                    { 4, "120 min", "Zwiększenie odsetka imigracji z Ziemi wymaga terraformacji Marsa, czyli dostosowania jego środowiska, aby ludzie mogli w nim przeżyć bez sprzętu ochronnego i aby zminimalizować śmiertelność w wyniku drobnych wypadków. W związku z tym Rząd Ziemi zdecydował się wesprzeć każdą organizację, która przyczyni się do tego wiekopomnego dzieła.", "\\images\\boardgames\\b4aca5a4-39f5-4557-9f22-d892ae5833ae_TerraformacjaMarsa.jpg", 1, 5, 1, "Terraformacja Marsa", 130m, 2016, 2, 12, 4 },
                    { 5, "60 - 120 min", "Oto kooperacyjna gra taktyczna, stworzona przez miłośnika ekonomicznych gier Euro, w której wspólnymi siłami przedzieramy się przez nieustannie ewoluujący świat fantasy, rozgrywając kampanię fabularną na przestrzeni wielu sesji.Każdy gracz wciela się w postać twardego najemnika posiadającego unikalne zdolności i własną motywację. ", "\\images\\boardgames\\3654de27-3880-416e-918d-669d34843189_Gloomhaven.jpg", 1, 4, 1, "Gloomhaven", 500m, 2017, 3, 14, 5 },
                    { 6, "40 - 80 min", "W uroczej dolinie Everdell, pod gałęziami wysokich drzew, wśród omszałych głazów, rozwija się cywilizacja leśnych zwierząt. Wiele lat minęło od jej początków i wreszcie nadszedł czas, by odkryć nowe tereny i zakładać zupełnie nowe miasta. ", "\\images\\boardgames\\a51727e6-52ff-4aaa-ae76-3655d0deed84_Everdell.png", 1, 4, 1, "Everdell ", 200m, 2018, 2, 13, 6 },
                    { 7, "30 min", "7 Cudów Świata: Pojedynek to gra dla 2 graczy, która wykorzystuje niektóre z głównych założeń bestselleru 7 Cudów Świata, ale oferuje również nowe wyzwania, specjalnie dopasowane do gry dwuosobowej.", "\\images\\boardgames\\62a196ba-cb1e-46dd-953a-ecadd3fd7f48_7CudowPojedynek.jpg", 1, 2, 2, "7 Cudów Świata: Pojedynek", 120m, 2015, 2, 10, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameTag",
                columns: table => new
                {
                    BoardGamesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameTag", x => new { x.BoardGamesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BoardGameTag_BoardGames_BoardGamesId",
                        column: x => x.BoardGamesId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameTag_TagsId",
                table: "BoardGameTag",
                column: "TagsId");
        }
    }
}
