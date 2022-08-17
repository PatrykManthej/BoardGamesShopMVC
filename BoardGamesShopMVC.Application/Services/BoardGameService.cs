using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IMapper _mapper;
        public BoardGameService(IBoardGameRepository boardGameRepository, IMapper mapper)
        {
            _boardGameRepository = boardGameRepository;
            _mapper = mapper;
        }

        public ListBoardGameForListVm GetAllGamesForList()
        {
            var boardGames = _boardGameRepository.GetAllBoardGames().ProjectTo<BoardGameForListVm>(_mapper.ConfigurationProvider).ToList();
            var boardGamesList = new ListBoardGameForListVm()
            {
                BoardGames = boardGames,
                Count = boardGames.Count
            };
            return boardGamesList;
        }
        public BoardGameDetailsVm GetBoardGameDetails(int id)
        {
            var boardGame = _boardGameRepository.GetBoardGameById(id);
            var boardGameVm = _mapper.Map<BoardGameDetailsVm>(boardGame);

            return boardGameVm;
        }

        public int AddBoardGame(NewBoardGameVm newBoardGame)
        {
            var boardGame = _mapper.Map<BoardGame>(newBoardGame);
            var id = _boardGameRepository.AddBoardGame(boardGame);
            return id;
        }

        public void DeleteBoardGame(int id)
        {
            _boardGameRepository.DeleteBoardGame(id);
        }
    }
}
