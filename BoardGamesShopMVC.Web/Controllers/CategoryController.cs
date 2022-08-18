using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Category;
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
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View(new NewCategoryVm());
        }
        [HttpPost]
        public IActionResult AddCategory(NewCategoryVm model)
        {
            var id = _categoryService.AddCategory(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.GetCategoryForEdit(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(NewCategoryVm model)
        {
            _categoryService.UpdateCategory(model);
            return RedirectToAction("Index");
        }
    }
}
