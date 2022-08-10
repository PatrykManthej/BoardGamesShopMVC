using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Domain.Interfaces

{
    public interface ICategoryRepository
    {
        int AddCategory(Category category);
        void DeleteCategory(int categoryId);
        IQueryable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
    }
}