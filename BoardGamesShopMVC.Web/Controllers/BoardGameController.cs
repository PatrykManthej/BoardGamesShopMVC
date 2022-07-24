using BoardGamesShopMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class BoardGameController : Controller
    {
        public List<BoardGame> boardGames = new List<BoardGame>()
        {
            new BoardGame(){ Id = 1, Name = "Terraformacja Marsa", LanguageVersion = "Polski", Publisher ="Rebel", MinNumeberOfPlayers = 1, MaxNumeberOfPlayers= 5, AverageTimeOfPlay = "90 - 120 min", RecommendedMinimumAge = 10, Availability = 5, Description = "W Terraformacji Marsa gracz obejmie kontrolę nad jedną z korporacji i jako jej zarząd będzie kupować i zagrywać karty opisujące różne projekty inwestycyjne. ", PublishedYear = 2016 },
            new BoardGame() { Id = 2, Name = "Gloomhaven", LanguageVersion = "Polski", Publisher = "Albi", MinNumeberOfPlayers = 1, MaxNumeberOfPlayers = 4, AverageTimeOfPlay = "90 - 150 min", RecommendedMinimumAge = 12, Availability = 3, Description = "Każdy gracz wciela się w postać twardego najemnika posiadającego unikalne zdolności i własną motywację. Razem tworzą drużynę, która będzie walczyć ramię w ramię na przestrzeni serii scenariuszy, których fabuła zmieniać się będzie wraz z podejmowanymi przez graczy decyzjami.", PublishedYear = 2017 },
            new BoardGame() { Id = 3, Name = "Brass: Birmingham", LanguageVersion = "Polski", Publisher = "Phalanx Games Polska", MinNumeberOfPlayers = 2, MaxNumeberOfPlayers = 4, AverageTimeOfPlay = "60 - 120 min", RecommendedMinimumAge = 14, Availability = 7, Description = "Brass: Birmingham, sequel wydanego w 2007 roku Brassa, to powtórna wycieczka do epoki, w której zmysł strategicznego myślenia napędzany intuicją ekonomiczną potrafił kreślić życiorysy na miarę Friedricha Kruppa i Stanisława Wokulskiego.", PublishedYear = 2018 },
            new BoardGame() { Id = 4, Name = "Pandemic Legacy: Sezon 1", LanguageVersion = "Polski", Publisher = "Rebel", MinNumeberOfPlayers = 2, MaxNumeberOfPlayers = 4, AverageTimeOfPlay = "60 - 90 min", RecommendedMinimumAge = 13, Availability = 0, Description = "Pandemic Legacy: Sezon 1 to unikalna epicka gra kooperacyjna dla 2 do 4 graczy. W przeciwieństwie do większości gier, skutki niektórych decyzji i podjętych działań w jednej rozgrywce Pandemic Legacy, będą miały wpływ na przebieg kolejnych gier. Co więcej - gra działa przeciwko nam.", PublishedYear = 2015 },
            new BoardGame() { Id = 5, Name = "Star Wars: Rebelia", LanguageVersion = "Polski", Publisher = "Galakta", MinNumeberOfPlayers = 2, MaxNumeberOfPlayers = 4, AverageTimeOfPlay = "180 - 240min", RecommendedMinimumAge = 14, Availability = 3, Description = "Gra planszowa Star Wars: Rebelia pozwala graczom odtworzyć emocjonujące starcie pomiędzy Sojuszem Rebeliantów a Imperium Galaktycznym. Obejmij kontrolę nad siłami Imperium i uwolnij ich potęgę militarną, aby odnaleźć bazę rebeliantów albo wywołaj Rebelię na szeroką skalę, opierając się na walce partyzanckiej i sabotażu.", PublishedYear = 2016 },
            new BoardGame() { Id = 6, Name = "Spirit Island", LanguageVersion = "Polski", Publisher = "Lacerta", MinNumeberOfPlayers = 1, MaxNumeberOfPlayers = 4, AverageTimeOfPlay = "90 - 120 min", RecommendedMinimumAge = 13, Availability = 2, Description = "Spirit Island jest kooperacyjnym tytułem dla zaawansowanych graczy. Grający wspólnie ratują wyspę przed najeźdźcami wykorzystując zdolności i moce specjalne duchów, w które się wcielają. Podstawowa gra zawiera osiem duchów do wyboru. Każdy cechuje się innym poziomem złożoności, dysponuje różnymi mocami i wymaga od graczy różnego stylu gry.", PublishedYear = 2017 }
        };

        [Route("BoardGame/All")]
        public IActionResult ListOfBoardGames()
        {
            //boardGames.Add(new BoardGame() { Id = , Name = "", LanguageVersion = "", Publisher = "", MinNumeberOfPlayers = , MaxNumeberOfPlayers = , AverageTimeOfPlay = "", RecommendedMinimumAge = , Availability = , Description = "", PublishedYear =  });
            return View(boardGames);
        }
        [Route("BoardGame/{id}")]
        public IActionResult BoardGame(int id)
        {
            var boardGame = boardGames.FirstOrDefault(b => b.Id == id);
            return View(boardGame);
        }
    }
}
