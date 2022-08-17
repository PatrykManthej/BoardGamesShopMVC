using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        public BoardGameController(IBoardGameService boardGameService)
        {
            _boardGameService = boardGameService;
        }
        //Dodanie widoku dodawania gry planszowej do sklepu i obsługa
        //Dodanie widoku listy wszystkich gier i obsługa
        //Dodanie widoku detali gry i obsługa

        [HttpGet]
        public IActionResult Index()
        {
            var model = _boardGameService.GetAllGamesForList();
            return View(model);
        }
        [HttpGet]
        public IActionResult ViewBoardGame(int boardGameId)
        {
            var model = _boardGameService.GetBoardGameDetails(boardGameId);
            return View(model);
        }
    }
}
