using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        ListCategoryForListVm GetAllCategories();
        ListBoardGameForListVm GetBoardGamesByCategoryId(int id);
    }
}
