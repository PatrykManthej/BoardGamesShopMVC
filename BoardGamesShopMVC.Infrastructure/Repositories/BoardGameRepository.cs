using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;
using BoardGamesShopMVC.Domain.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly Context _context;
        public BoardGameRepository(Context context)
        {
            _context = context;
        }

        public int AddBoardGame(BoardGame boardGame)
        {
            _context.AttachRange(boardGame.Categories);
            _context.BoardGames.Add(boardGame);
            _context.SaveChanges();
            return boardGame.Id;
        }

        public void DeleteBoardGame(int boardGameId)
        {
            var boardGame = _context.BoardGames
                .Include(b=>b.Stock)
                .FirstOrDefault(b => b.Id == boardGameId);

            if (boardGame != null)
            {
                _context.Stocks.Remove(boardGame.Stock);
                _context.BoardGames.Remove(boardGame);
                _context.SaveChanges();
            }
        }
        public void UpdateBoardGame(BoardGame boardGame)
        {

            var existingBoardGame = _context.BoardGames
                .Where(b => b.StatusId == 1)
                .Include(b => b.Categories)
                .Include(b=>b.Stock)
                .FirstOrDefault(b => b.Id == boardGame.Id);

            boardGame.Created = _context.Entry(existingBoardGame).Property(b => b.Created).CurrentValue;
            boardGame.Modified = _context.Entry(existingBoardGame).Property(b => b.Modified).CurrentValue;
            boardGame.StatusId = _context.Entry(existingBoardGame).Property(b => b.StatusId).CurrentValue;
            boardGame.Inactivated = _context.Entry(existingBoardGame).Property(b => b.Inactivated).CurrentValue;

            _context.Entry(existingBoardGame).CurrentValues.SetValues(boardGame);
            _context.Entry(existingBoardGame.Stock).CurrentValues.SetValues(boardGame.Stock);

            foreach (var category in boardGame.Categories)
            {
                var existingCategory = existingBoardGame.Categories.FirstOrDefault(c => c.Id == category.Id);
                if (existingCategory == null)
                {
                    existingBoardGame.Categories.Add(category);
                }
            }
            foreach (var oldCategory in existingBoardGame.Categories)
            {
                var category = boardGame.Categories.FirstOrDefault(c => c.Id == oldCategory.Id);
                if (category == null)
                {
                    existingBoardGame.Categories.Remove(oldCategory);
                }
            }
            _context.SaveChanges();
        }
        public BoardGame GetBoardGameById(int boardGameId)
        {
            var boardGame = _context.BoardGames
                .Where(b=>b.StatusId == 1)
                .FirstOrDefault(b => b.Id == boardGameId);
            return boardGame;
        }
        public BoardGame GetBoardGameWithDependenciesById(int boardGameId)
        {
            var boardGame = _context.BoardGames
                .Where(b => b.StatusId == 1)
                .Include(b=>b.LanguageVersion)
                .Include(b=>b.Publisher)
                .Include(b=>b.Categories)
                .Include(b=>b.Stock)
                .FirstOrDefault(b => b.Id == boardGameId);
            return boardGame;
        }

        public IQueryable<BoardGame> GetAllBoardGames()
        {
            var boardGames = _context.BoardGames
                .Where(b => b.StatusId == 1);
            return boardGames;
        }

        public IQueryable<BoardGame> GetBoardGamesByLanguageId(int languageId)
        {
            var boardGames = _context.BoardGames
                .Where(b => b.StatusId == 1)
                .Where(b => b.LanguageId == languageId);
            return boardGames;
        }

        public IQueryable<BoardGame> GetBoardGamesByPublisherId(int publisherId)
        {
            var boardGames = _context.BoardGames
                .Where(b => b.StatusId == 1)
                .Where(b => b.PublisherId == publisherId);
            return boardGames;
        }

        public IQueryable<BoardGame> GetBoardGamesByCategoryId(int categoryId)
        {
            var boardGames = _context.BoardGames
                .Where(b => b.StatusId == 1)
                .Where(b => b.Categories.Any(c => c.Id == categoryId));
            return boardGames;
        }

    }
}
