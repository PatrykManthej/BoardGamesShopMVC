using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Web.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IValidator<NewBoardGameVm> _validator;
        private readonly ILogger<HomeController> _logger;
        public BoardGameController(IBoardGameService boardGameService, IValidator<NewBoardGameVm> validator, ILogger<HomeController> logger)
        {
            _boardGameService = boardGameService;
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Jestem w BoardGame/Index");
            var model = _boardGameService.GetAllGamesForList(5, 1, "");
            return View(model);
        }
        [HttpGet]
        public IActionResult Index2()
        {
            _logger.LogInformation("Jestem w BoardGame/Index");
            var model = _boardGameService.GetAllGamesForList(5, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            _logger.LogInformation("Jestem w BoardGame/Index ale post");
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
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
            var model = _boardGameService.SetParametersToVm(new NewBoardGameVm());
            return View(model);
        }
        [HttpPost]
        public IActionResult AddBoardGame(NewBoardGameVm model)
        {
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(new NewBoardGameVm());
            }
            _boardGameService.SaveImageToFileInApplicationFolder(model);
            var id = _boardGameService.AddBoardGame(model);
            return RedirectToAction("Index");

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


            _boardGameService.UpdateBoardGame(model);
            return RedirectToAction("Index");

            return View(model);
        }
    }
}
