﻿using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IBoardGameRepository
    {
        int AddBoardGame(BoardGame boardGame);
        void DeleteBoardGame(int boardGameId);
        IQueryable<BoardGame> GetAllBoardGames();
        BoardGame GetBoardGameById(int boardGameId);
        IQueryable<BoardGame> GetBoardGamesByCategoryId(int categoryId);
        IQueryable<BoardGame> GetBoardGamesByLanguageId(int languageId);
        IQueryable<BoardGame> GetBoardGamesByPublisherId(int publisherId);
        IQueryable<BoardGame> GetBoardGamesByTagId(int tagId);
    }
}