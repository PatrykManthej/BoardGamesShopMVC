using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Category;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        ListCategoryForListVm GetAllCategories(int pageSize, int pageNo, string searchString);
        ListBoardGameForListVm GetBoardGamesByCategoryId(int id);
        int AddCategory(NewCategoryVm newCategory);
        void DeleteCategory(int id);
        NewCategoryVm GetCategoryForEdit(int id);
        void UpdateCategory(NewCategoryVm model);
    }
}
