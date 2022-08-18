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
        ListBoardGameForListVm GetAllGamesForList(int pageSize, int pageNo, string searchString);
        BoardGameDetailsVm GetBoardGameDetails(int id);
        int AddBoardGame(NewBoardGameVm newBoardGame);
        void DeleteBoardGame(int id);
        NewBoardGameVm GetBoardGameForEdit(int id);
        void UpdateBoardGame(NewBoardGameVm model);

    }
}
