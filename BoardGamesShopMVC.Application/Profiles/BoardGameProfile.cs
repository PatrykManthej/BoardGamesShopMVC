using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Profiles
{
    public class BoardGameProfile : Profile
    {
        public BoardGameProfile()
        {
            CreateMap<BoardGame, BoardGameForListVm>()
                .ForMember(
                dst => dst.LanguageVersion,
                opt => opt.MapFrom(src=>src.LanguageVersion.Name)
                );

            CreateMap<BoardGame, BoardGameDetailsVm>()
                .ForMember(
                dst => dst.LanguageVersion,
                opt => opt.MapFrom(src => src.LanguageVersion.Name)
                )
                .ForMember(
                dst => dst.Publisher,
                opt => opt.MapFrom(src => src.Publisher.Name)
                );

            CreateMap<BoardGame, NewBoardGameVm>()
            .ForMember(
            dst => dst.StockQuantity,
            opt => opt
                .MapFrom(src => src.Stock.Quantity)
            )
            .ReverseMap()
            .ForPath(
                dst => dst.Stock.Id,
                opt => opt.MapFrom(src => src.StockId)
                );
        }
    }
}

