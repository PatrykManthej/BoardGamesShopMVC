using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Category;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<NewCategoryVm> _validator;
        public CategoryController(ICategoryService categoryService, IValidator<NewCategoryVm> validator)
        {
            _categoryService = categoryService;
            _validator = validator;
        }

        public IActionResult Index(int pageSize, int? pageNo, string searchString)
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
            var model = _categoryService.GetAllCategories(pageSize, pageNo.Value, searchString);
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
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(new NewCategoryVm());
            }
            var id = _categoryService.AddCategory(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id, int boardGamesCount)
        {
            if(boardGamesCount == 0)
            {
            _categoryService.DeleteCategory(id);
            }
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
