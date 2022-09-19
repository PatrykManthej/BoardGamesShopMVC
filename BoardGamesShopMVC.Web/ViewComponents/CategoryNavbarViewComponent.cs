using BoardGamesShopMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.ViewComponents
{
    public class CategoryNavbarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryNavbarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _categoryService.GetAllCategories(20, 1, "");
            return View(model);
        }
    }
}
