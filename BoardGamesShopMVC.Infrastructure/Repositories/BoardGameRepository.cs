﻿using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Models;
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
            var boardGame = _context.BoardGames.Find(boardGameId);
            if (boardGame != null)
            {
                _context.BoardGames.Remove(boardGame);
                _context.SaveChanges();
            }
        }
        public void UpdateBoardGame(BoardGame boardGame)
        {
            _context.Attach(boardGame);
            _context.Entry(boardGame).Property("Name").IsModified = true;
            _context.Entry(boardGame).Property("Description").IsModified = true;
            _context.Entry(boardGame).Property("AverageTimeOfPlay").IsModified = true;
            _context.Entry(boardGame).Property("RecommendedMinimumAge").IsModified = true;
            _context.Entry(boardGame).Property("MinNumberOfPlayers").IsModified = true;
            _context.Entry(boardGame).Property("MaxNumberOfPlayers").IsModified = true;
            _context.Entry(boardGame).Property("PublishedYear").IsModified = true;
            _context.Entry(boardGame).Property("Price").IsModified = true;
            _context.Entry(boardGame).Property("PublisherId").IsModified = true;
            _context.Entry(boardGame).Property("ImageBytes").IsModified = true;
            _context.SaveChanges();
        }

        public BoardGame GetBoardGameById(int boardGameId)
        {
            var boardGame = _context.BoardGames
                .Include(b=>b.LanguageVersion)
                .Include(b=>b.Publisher)
                //.Include(b=>b.Stock)
                .FirstOrDefault(b => b.Id == boardGameId);
            return boardGame;
        }

        public IQueryable<BoardGame> GetAllBoardGames()
        {
            var boardGames = _context.BoardGames;
            return boardGames;
        }

        public IQueryable<BoardGame> GetBoardGamesByLanguageId(int languageId)
        {
            var boardGames = _context.BoardGames.Where(b => b.LanguageId == languageId);
            return boardGames;
        }

        public IQueryable<BoardGame> GetBoardGamesByPublisherId(int publisherId)
        {
            var boardGames = _context.BoardGames.Where(b => b.PublisherId == publisherId);
            return boardGames;
        }

        public IQueryable<BoardGame> GetBoardGamesByCategoryId(int categoryId)
        {
            var boardGames = _context.BoardGames.Where(b => b.Categories.Any(c => c.Id == categoryId));
            return boardGames;
        }

        public IQueryable<BoardGame> GetBoardGamesByTagId(int tagId)
        {
            var boardGames = _context.BoardGames.Where(b => b.Tags.Any(t => t.Id == tagId));
            return boardGames;
        }



    }
}
