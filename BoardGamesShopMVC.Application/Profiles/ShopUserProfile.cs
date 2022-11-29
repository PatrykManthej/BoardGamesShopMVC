using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.ShopUser;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Profiles
{
    public class ShopUserProfile : Profile
    {
        public ShopUserProfile()
        {
            CreateMap<NewShopUserVm, ShopUser>();
            CreateMap<ShopUser, ShopUserVm>();
        }
    }
}
