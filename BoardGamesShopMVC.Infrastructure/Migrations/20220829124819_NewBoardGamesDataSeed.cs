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
                values: new object[,]
                {
                    { 3, "Albi" },
                    { 4, "Lucky Duck Games" },
                    { 5, "Lacerta" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Quantity" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 6 },
                    { 7, 2 },
                    { 8, 3 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 5 },
                    { 12, 6 }
                });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "AverageTimeOfPlay", "Description", "ImageUrl", "LanguageId", "MaxNumberOfPlayers", "MinNumberOfPlayers", "Name", "Price", "PublishedYear", "PublisherId", "RecommendedMinimumAge", "StockId" },
                values: new object[,]
                {
                    { 4, "30 min", "W stolicy Radżastanu trwają poszukiwania nowego ministra handlu. Jako jeden z najlepszych w swoim fachu, postanawiasz podjąć wyzwanie i zgromadzić więcej bogactw od przeciwnika.", "\\images\\boardgames\\28dcf532-2dd8-4337-b031-7f89f90a1533_Jaipur.png", 1, 2, 2, "Jaipur", 85m, 2009, 2, 10, 4 },
                    { 5, "60 - 120 min", "Oto kooperacyjna gra taktyczna, stworzona przez miłośnika ekonomicznych gier Euro, w której wspólnymi siłami przedzieramy się przez nieustannie ewoluujący świat fantasy, rozgrywając kampanię fabularną na przestrzeni wielu sesji.Każdy gracz wciela się w postać twardego najemnika posiadającego unikalne zdolności i własną motywację. ", "\\images\\boardgames\\3654de27-3880-416e-918d-669d34843189_Gloomhaven.jpg", 1, 4, 1, "Gloomhaven", 500m, 2017, 3, 14, 5 },
                    { 6, "40 - 80 min", "W uroczej dolinie Everdell, pod gałęziami wysokich drzew, wśród omszałych głazów, rozwija się cywilizacja leśnych zwierząt. Wiele lat minęło od jej początków i wreszcie nadszedł czas, by odkryć nowe tereny i zakładać zupełnie nowe miasta. ", "\\images\\boardgames\\a51727e6-52ff-4aaa-ae76-3655d0deed84_Everdell.png", 1, 4, 1, "Everdell ", 200m, 2018, 2, 13, 6 },
                    { 7, "30 - 45 min", "Przenieś się do malowniczej krainy w Północnej Ameryce i stwórz pełne życia środowisko Kaskadii. W swojej turze wybierz parę płytki oraz żetonu i dołóż je do swojego rozrastającego się ekosystemu. Ułóż jak największe obszary gór, rzek czy prerii oraz rozmieść zwierzęta w punktowanych układach.", "\\images\\boardgames\\ebb22f92-1c40-4dd1-8266-7d3b55a588be_Kaskadia.png", 1, 4, 1, "Kaskadia ", 150m, 2021, 4, 10, 7 },
                    { 8, "30 min", "Patchwork to metoda szycia, w której łączy się małe kawałki materiału w większą całość, tworząc nowy wzór. W przeszłości wykorzystywano ją, żeby zagospodarować niechciane ścinki i skrawki.", "\\images\\boardgames\\190d7868-947b-4256-9d51-e5f48dfde516_Patchwork.jpg", 1, 2, 2, "Patchwork", 90m, 2014, 5, 8, 8 },
                    { 9, "10 min", "Dwie drużyny, którym przewodzi dwóch Szefów Wywiadu, próbują jak najszybciej nawiązać kontakt ze wszystkimi swoimi agentami.", "\\images\\boardgames\\4aa3ec2a-03a3-41ff-b471-e0386f40a5e3_Tajniacy.jpg", 1, 8, 2, "Tajniacy", 60m, 2015, 2, 14, 9 },
                    { 10, "30 - 45 min", "Azulejos - oryginalnie były to biało-niebieskie płytki ceramiczne, sprowadzone do Europy przez Maurów. Sławę i popularność w Portugalii zdobyły po wizycie króla Manuela I w południowej Hiszpanii.", "\\images\\boardgames\\87c21d47-dc5a-41c8-aa5f-d0ff1a932691_Azul.jpg", 1, 4, 2, "Azul", 230m, 2017, 5, 8, 10 },
                    { 11, "90 min", "Przenieśmy się w czasie do roku 1670. Zaraza szalejąca w Europie Środkowej od 1348 roku w końcu została przezwyciężona. Na nowo odżywa cywilizacja. Ludzie coraz częściej odnawiają i rozbudowują swoje domostwa.", "\\images\\boardgames\\a4bb9edb-b355-4b5b-ab51-3aaa4af38e82_Agricola.jpg", 1, 4, 1, "Agricola ", 270m, 2007, 5, 12, 11 },
                    { 12, "60 min", "Cztery choroby wydostały się na świat i przed drużyną specjalistów z różnych dziedzin stanęło zadanie odnalezienia szczepionek na te epidemie, zanim ludzkość zostanie unicestwiona.", "\\images\\boardgames\\7803a237-b779-4669-a386-94ef32e1ac7a_Pandemic.jpg", 1, 4, 2, "Pandemic ", 170m, 2008, 2, 10, 12 }
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
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BoardGames",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 12);

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
