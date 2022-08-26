using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Category;
using BoardGamesShopMVC.Application.ViewModels.Language;
using BoardGamesShopMVC.Application.ViewModels.Publisher;

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
        IQueryable<PublisherForListVm> GetPublishersToSelect();
        IQueryable<CategoryForListVm> GetCategoriesToSelect();
        IQueryable<LanguageForListVm> GetLanguagesToSelect();
        NewBoardGameVm SetParametersToVm(NewBoardGameVm model);

    }
}
