using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IBoardGameRepository
    {
        int AddBoardGame(BoardGame boardGame);
        void DeleteBoardGame(int boardGameId);
        void UpdateBoardGame(BoardGame boardGame);
        IQueryable<BoardGame> GetAllBoardGames();
        BoardGame GetBoardGameById(int boardGameId);
        BoardGame GetBoardGameWithDependenciesById(int boardGameId);
        IQueryable<BoardGame> GetBoardGamesByCategoryId(int categoryId);
        IQueryable<BoardGame> GetBoardGamesByLanguageId(int languageId);
        IQueryable<BoardGame> GetBoardGamesByPublisherId(int publisherId);
    }
}