using AutoMapper;
using BoardGamesShopMVC.Application.Profiles.Resolvers;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Profiles
{
    public class BoardGameProfile : Profile
    {
        public BoardGameProfile()
        {
            CreateMap<BoardGame, BoardGameForListVm>()
                .ForMember(
                dst => dst.ImageSrc,
                opt => opt.MapFrom<BoardGameForListImageResolver>()
                );

            CreateMap<BoardGame, BoardGameDetailsVm>()
                .ForMember(
                dst => dst.LanguageVersion,
                opt => opt.MapFrom(src => src.LanguageVersion.Name)
                )
                .ForMember(
                dst => dst.Publisher,
                opt => opt.MapFrom(src => src.Publisher.Name)
                )
                .ForMember(
                dst=>dst.ImageSrc,
                opt => opt.MapFrom<BoardGameDetailsImageResolver>()
                );

            //CreateMap<NewBoardGameVm, BoardGame>()
            //    .ForMember(dst => dst.Stock.Quantity,
            //    opt =>opt.MapFrom(src => src.StockQuantity))
            //    .ReverseMap();

            CreateMap<BoardGame, NewBoardGameVm>()
                //.ForMember(
                //dst => dst.StockQuantity,
                //opt => opt
                //    .MapFrom(src => src.Stock.Quantity)
                //)
            .ReverseMap()
                    .ForMember(
                    dst=>dst.ImageBytes,
                    opt=>opt.MapFrom<AddBoardGameImageResolver>()
                    );

        }
    }
}

