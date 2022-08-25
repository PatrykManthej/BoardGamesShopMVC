using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Category;
using BoardGamesShopMVC.Application.ViewModels.Language;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public BoardGameService(IBoardGameRepository boardGameRepository, IPublisherRepository publisherRepository, ICategoryRepository categoryRepository,ILanguageRepository languageRepository, IMapper mapper)
        {
            _boardGameRepository = boardGameRepository;
            _publisherRepository = publisherRepository;
            _categoryRepository = categoryRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public ListBoardGameForListVm GetAllGamesForList(int pageSize, int pageNo, string searchString)
        {
            var boardGames = _boardGameRepository.GetAllBoardGames()
                .Where(b => b.Name.StartsWith(searchString)).ToList();

            var boardGamesDto = new List<BoardGameForListVm>();
            foreach (var item in boardGames)
            {
                var itemDto = _mapper.Map<BoardGameForListVm>(item);
                boardGamesDto.Add(itemDto);
            }
                

            var boardGamesToShow = boardGamesDto.Skip(pageSize * (pageNo - 1))
                .Take(pageSize).ToList();

            var boardGamesList = new ListBoardGameForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                BoardGames = boardGamesDto,
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
            var allCategories = GetCategoriesToSelect().ToList();
            var categoriesForBoardGame = new List<CategoryForListVm>();

            foreach (var categoryId in newBoardGame.CategoriesId)
            {
                var category = allCategories.FirstOrDefault(c => c.Id == categoryId);
                categoriesForBoardGame.Add(category);
            }

            newBoardGame.Categories = categoriesForBoardGame;
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
        public IQueryable<CategoryForListVm> GetCategoriesToSelect()
        {
            var categoriesToSelect = _categoryRepository.GetAllCategories()
                .ProjectTo<CategoryForListVm>(_mapper.ConfigurationProvider);
            return categoriesToSelect;
        }
        public IQueryable<LanguageForListVm> GetLanguagesToSelect()
        {
            var languagesToSelect = _languageRepository.GetAllLanguages()
                .ProjectTo<LanguageForListVm>(_mapper.ConfigurationProvider);
            return languagesToSelect;
        }
        public NewBoardGameVm SetParametersToVm(NewBoardGameVm model)
        {
            model.Publishers = GetPublishersToSelect().ToList();
            model.Categories = GetCategoriesToSelect().ToList();
            model.Languages = GetLanguagesToSelect().ToList();
            return model;
        }
    }
}
