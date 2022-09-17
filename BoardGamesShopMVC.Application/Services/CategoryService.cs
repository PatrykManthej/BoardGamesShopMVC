using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Category;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository=categoryRepository;
            _mapper = mapper;
        }
        public ListCategoryForListVm GetAllCategories(int pageSize, int pageNo, string searchString)
        {
            var categories = _categoryRepository.GetAllCategories()
                .Where(c=>c.Name.StartsWith(searchString))
                .ProjectTo<CategoryForListVm>(_mapper.ConfigurationProvider).ToList();

            var categoriesToShow = categories.Skip(pageSize * (pageNo - 1))
                .Take(pageSize).ToList();
            var listCategories = new ListCategoryForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Categories = categoriesToShow,
                Count = categories.Count
            };
            return listCategories;
        }

        public int AddCategory(NewCategoryVm newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);
            var id = _categoryRepository.AddCategory(category);
            return id;
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }


        public NewCategoryVm GetCategoryForEdit(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            var categoryVm = _mapper.Map<NewCategoryVm>(category);
            return categoryVm;
        }

        public void UpdateCategory(NewCategoryVm model)
        {
            var category = _mapper.Map<Category>(model);
            _categoryRepository.UpdateCategory(category);
        }
    }
}
