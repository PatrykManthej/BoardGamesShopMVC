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
            CreateMap<Address, AddressVm>().ReverseMap();
            CreateMap<ShopUser, ShopUserWithAddressVm>().ForMember(dst => dst.Address,
                    opt => opt.MapFrom(src => src.Addresses.FirstOrDefault()))
                .ReverseMap();
        }
    }
}
