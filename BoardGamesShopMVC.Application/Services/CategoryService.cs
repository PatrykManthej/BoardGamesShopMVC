using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Category;
using BoardGamesShopMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ListCategoryForListVm GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories().ProjectTo<CategoryForListVm>(_mapper.ConfigurationProvider).ToList();
            var listCategories = new ListCategoryForListVm()
            {
                Categories = categories,
                Count = categories.Count
            };
            return listCategories;
        }
    }
}
