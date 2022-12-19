﻿using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Application.ViewModels.Order;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CartSummaryVm, Order>()
                .ForMember(
                    dst => dst.Amount, opt => opt.MapFrom(src => src.TotalAmount)
                )
                .ForMember(dst => dst.Items, opt => opt.MapFrom(src => src.CartItems))
                .ForMember(dst=>dst.OrderRecipient, opt=>opt.MapFrom(src=>src.ApplicationUserVm))
                .ForMember(dst=>dst.Id, opt=>opt.Ignore());

            CreateMap<CartItemVm, OrderItem>()
                .ForMember(dst=>dst.UnitPrice, opt => opt.MapFrom(src=>src.Price))
                .ForMember(dst=>dst.TotalPrice, opt => opt.MapFrom(src=>(src.Price*src.Quantity)))
                .ForMember(dst=>dst.Id, opt=>opt.Ignore());

            CreateMap<Order, OrderDetailsVm>()
                .ForMember(dst => dst.UserEmail, opt => opt.MapFrom(src=>src.ApplicationUser.Email))
                .ForMember(dst=>dst.OrderRecipientVm, opt=>opt.MapFrom(src=>src.OrderRecipient))
				.ForMember(dst => dst.OrderItems, opt => opt.MapFrom(src => src.Items));

            CreateMap<OrderRecipient, OrderRecipientVm>();

            CreateMap<OrderItem, OrderItemVm>()
	            .ForMember(dst=>dst.Name, opt => opt.MapFrom(src=>src.BoardGame.Name));

			CreateMap<Order, OrderForListVm>()
                .ForMember(dst => dst.UserEmail,
                    opt => opt.MapFrom(src => src.ApplicationUser.Email));
        }
    }
}
