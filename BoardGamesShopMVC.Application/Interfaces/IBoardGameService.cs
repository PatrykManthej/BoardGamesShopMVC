using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IBoardGameService
    {
        ListBoardGameForListVm GetAllGamesForList();
        BoardGameDetailsVm GetBoardGameDetails(int id);
    }
}
