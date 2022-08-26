using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.Category;
using BoardGamesShopMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryForListVm>().ReverseMap();
            CreateMap<NewCategoryVm, Category>().ReverseMap();
        }
    }
}
