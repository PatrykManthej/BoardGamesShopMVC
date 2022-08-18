using BoardGamesShopMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _categoryService.GetAllCategories();
            return View(model);
        }
        [HttpGet]
        public IActionResult ViewBoardGamesByCategory(int id)
        {
            var model = _categoryService.GetBoardGamesByCategoryId(id);
            return View(model);
        }
    }
}
