using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces

{
    public interface ICategoryRepository
    {
        int AddCategory(Category category);
        void DeleteCategory(int categoryId);
        IQueryable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        IQueryable<BoardGame> GetAllBoardGamesByCategoryId(int id);
        void UpdateCategory(Category category);
    }
}