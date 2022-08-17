using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Services
{
    public class BoardGameService
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
    }
}
