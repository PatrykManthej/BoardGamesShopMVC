using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
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
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public BoardGameService(IBoardGameRepository boardGameRepository, IPublisherRepository publisherRepository, IMapper mapper)
        {
            _boardGameRepository = boardGameRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public ListBoardGameForListVm GetAllGamesForList(int pageSize, int pageNo, string searchString)
        {
            var boardGames = _boardGameRepository.GetAllBoardGames()
                .Where(b=>b.Name.StartsWith(searchString))
                .ProjectTo<BoardGameForListVm>(_mapper.ConfigurationProvider).ToList();

            var boardGamesToShow = boardGames.Skip(pageSize * (pageNo - 1))
                .Take(pageSize).ToList();

            var boardGamesList = new ListBoardGameForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
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

        public NewBoardGameVm GetBoardGameForEdit(int id)
        {
            var boardGame = _boardGameRepository.GetBoardGameById(id);
            var boardGameVm = _mapper.Map<NewBoardGameVm>(boardGame);
            return boardGameVm;
        }

        public void UpdateBoardGame(NewBoardGameVm model)
        {
            var boardGame = _mapper.Map<BoardGame>(model);
            _boardGameRepository.UpdateBoardGame(boardGame);
        }
        public IQueryable<PublisherForListVm> GetPublishersToSelect()
        {
            var publishersToSelect = _publisherRepository.GetAllPublishers()
                .ProjectTo<PublisherForListVm>(_mapper.ConfigurationProvider);
            return publishersToSelect;
        }
        public NewBoardGameVm SetParametersToVm(NewBoardGameVm model)
        {
            model.Publishers = GetPublishersToSelect().ToList();
            return model;
        }
    }
}
