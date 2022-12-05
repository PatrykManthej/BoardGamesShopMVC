using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGamesShopMVC.Application.ViewModels.ApplicationUser;

namespace BoardGamesShopMVC.Application.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDetailsVm>();
            CreateMap<CartItem, CartItemVm>()
                .ForMember(
                dst => dst.Name, 
                opt => opt.MapFrom(src=>src.BoardGame.Name)
                )
                .ForMember(
                dst => dst.Price,
                opt => opt.MapFrom(src => src.BoardGame.Price)
                )
                .ForMember(
                dst => dst.ImageUrl,
                opt => opt.MapFrom(src => src.BoardGame.ImageUrl)
                )
                .ForMember(dst=>dst.Total, opt => opt.MapFrom(src=>src.Quantity));
            CreateMap<Cart, CartSummaryVm>();
        }
    }
}
