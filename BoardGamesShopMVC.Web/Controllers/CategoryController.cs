using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Category;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<NewCategoryVm> _validator;
        public CategoryController(ICategoryService categoryService, IValidator<NewCategoryVm> validator)
        {
            _categoryService = categoryService;
            _validator = validator;
        }

        public IActionResult Index(string? searchString, int pageSize = 10, int pageNo = 1)
        {
            searchString ??= string.Empty;
            var model = _categoryService.GetAllCategories(pageSize, pageNo, searchString);
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
