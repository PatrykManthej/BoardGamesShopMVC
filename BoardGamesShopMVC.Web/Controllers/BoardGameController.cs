using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
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
            var model = _boardGameService.GetAllGamesForList(5,1,"");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = string.Empty;
            }
            var model = _boardGameService.GetAllGamesForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult ViewBoardGame(int boardGameId)
        {
            var model = _boardGameService.GetBoardGameDetails(boardGameId);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddBoardGame()
        {
            return View(new NewBoardGameVm());
        }
        [HttpPost]
        public IActionResult AddBoardGame(NewBoardGameVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _boardGameService.AddBoardGame(model);
                return RedirectToAction("Index");
            }
            return View(new NewBoardGameVm());
        }

        public IActionResult Delete(int id)
        {
            _boardGameService.DeleteBoardGame(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditBoardGame(int id)
        {
            var boardGame = _boardGameService.GetBoardGameForEdit(id);
            return View(boardGame);
        }
        [HttpPost]
        public IActionResult EditBoardGame(NewBoardGameVm model)
        {
            if (ModelState.IsValid)
            {
                _boardGameService.UpdateBoardGame(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
