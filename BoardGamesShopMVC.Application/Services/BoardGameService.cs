using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Category;
using BoardGamesShopMVC.Application.ViewModels.Language;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;
using Microsoft.AspNetCore.Hosting;

namespace BoardGamesShopMVC.Application.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BoardGameService(IBoardGameRepository boardGameRepository, IPublisherRepository publisherRepository, ICategoryRepository categoryRepository, ILanguageRepository languageRepository, IStockRepository stockRepository, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _boardGameRepository = boardGameRepository;
            _publisherRepository = publisherRepository;
            _categoryRepository = categoryRepository;
            _languageRepository = languageRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public ListBoardGameForListVm GetAllGamesForList(int pageSize, int pageNo, string searchString)
        {
            var boardGames = _boardGameRepository.GetAllBoardGames()
                .Where(b => b.Name.StartsWith(searchString))
                .ProjectTo<BoardGameForListVm>(_mapper.ConfigurationProvider).ToList();

            var boardGamesToShow = boardGames.Skip(pageSize * (pageNo - 1))
                .Take(pageSize).ToList();

            var boardGamesList = new ListBoardGameForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                BoardGames = boardGamesToShow,
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
            SetCategoriesToBoardGame(newBoardGame);

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
            boardGameVm.CategoriesId = new List<int>();
            foreach (var category in boardGame.Categories)
            {
                boardGameVm.CategoriesId.Add(category.Id);
            }
            return boardGameVm;
        }

        public void UpdateBoardGame(NewBoardGameVm model)
        {
            SetCategoriesToBoardGame(model);
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
        public NewBoardGameVm SaveImageToFileInApplicationFolder(NewBoardGameVm model)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (model.ImageFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                var uploadsFolder = Path.Combine(wwwRootPath, @"images\boardgames\");
                if (model.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, model.ImageUrl.TrimStart('\\'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(uploadsFolder, fileName), FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
                model.ImageUrl = @"\images\boardgames\" + fileName;
            }
            return model;
        }
        public NewBoardGameVm SetCategoriesToBoardGame(NewBoardGameVm boardGame)
        {
            var allCategories = GetCategoriesToSelect().ToList();
            var categoriesForBoardGame = new List<CategoryForListVm>();

            foreach (var categoryId in boardGame.CategoriesId)
            {
                var category = allCategories.FirstOrDefault(c => c.Id == categoryId);
                categoriesForBoardGame.Add(category);
            }
            boardGame.Categories = categoriesForBoardGame;
            return boardGame;
        }
    }
}
