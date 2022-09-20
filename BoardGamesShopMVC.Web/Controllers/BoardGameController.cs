using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Web.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IValidator<NewBoardGameVm> _validator;
        private readonly ILogger<BoardGameController> _logger;
        public BoardGameController(IBoardGameService boardGameService, IValidator<NewBoardGameVm> validator, ILogger<BoardGameController> logger)
        {
            _boardGameService = boardGameService;
            _validator = validator;
            _logger = logger;
        }

        public IActionResult Index(int pageSize, int? pageNo, string searchString, string filter, int filterObjectId)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = string.Empty;
            }
            if (pageSize == null || pageSize == 0)
            {
                pageSize = 8;
            }
            var model = _boardGameService.GetAllGamesForList(pageSize, pageNo.Value, searchString, filter, filterObjectId);
            return View(model);
        }


        public IActionResult BoardGames(int? pageSize, int? pageNo, string searchString, string filter, int filterObjectId)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = string.Empty;
            }
            if (pageSize == null || pageSize == 0)
            {
                pageSize = 10;
            }
            var model = _boardGameService.GetAllGamesForList(pageSize.Value, pageNo.Value, searchString, filter, filterObjectId);
            return View(model);
        }

        [HttpGet]
        public IActionResult ViewBoardGame(int id)
        {
            var model = _boardGameService.GetBoardGameDetails(id);
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
                var newModel = _boardGameService.SetParametersToVm(new NewBoardGameVm());
                return View(newModel);
            }
            var id = _boardGameService.AddBoardGame(model);
            return RedirectToAction("BoardGames");
        }

        public IActionResult DeleteBoardGame(int id)
        {
            _boardGameService.DeleteBoardGame(id);
            return RedirectToAction("BoardGames");
        }

        [HttpGet]
        public IActionResult EditBoardGame(int id)
        {
            var boardGame = _boardGameService.GetBoardGameForEdit(id);
            _boardGameService.SetParametersToVm(boardGame);
            return View(boardGame);
        }
        [HttpPost]
        public IActionResult EditBoardGame(NewBoardGameVm model)
        {
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                _boardGameService.SetParametersToVm(model);
                return View(model);
            }
            _boardGameService.UpdateBoardGame(model);
            return RedirectToAction("BoardGames");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
