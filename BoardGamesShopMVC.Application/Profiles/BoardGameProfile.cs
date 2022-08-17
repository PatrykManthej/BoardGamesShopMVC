using AutoMapper;
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
            CreateMap<BoardGame, BoardGameForListVm>();
            CreateMap<BoardGame, BoardGameDetailsVm>()
                .ForMember(
                dst => dst.LanguageVersion,
                opt => opt.MapFrom(src => src.LanguageVersion.Name)
                )
                .ForMember(
                dst => dst.Publisher,
                opt => opt.MapFrom(src => src.Publisher.Name)
                );
        }
    }
}
