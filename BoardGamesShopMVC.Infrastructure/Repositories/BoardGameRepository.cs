using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class BoardGameRepository
    {
        private readonly Context _context;
        public BoardGameRepository(Context context)
        {
            _context = context;
        }
        public int AddBoardGame(BoardGame boardGame)
        {
            _context.BoardGames.Add(boardGame);
            _context.SaveChanges();
            return boardGame.Id;
        }
        public void DeleteBoardGame(int boardGameId)
        {
            var boardGame = _context.BoardGames.Find(boardGameId);
            if (boardGame != null)
            {
                _context.BoardGames.Remove(boardGame);
                _context.SaveChanges();
            }
        }
        public IQueryable<BoardGame> GetBoardGamesByPublisherId(int publisherId)
        {
            var boardGames = _context.BoardGames.Where(b => b.PublisherId == publisherId);
            return boardGames;
        }
        public BoardGame GetBoardGameById(int boardGameId)
        {
            var boardGame = _context.BoardGames.FirstOrDefault(b => b.Id == boardGameId);
            return boardGame;
        }

    }
}
