using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public int AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.Id;
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(b => b.Id == categoryId);
            return category;
        }

        public IQueryable<Category> GetAllCategories()
        {
            var categories = _context.Categories;
            return categories;
        }
    }
}
