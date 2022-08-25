using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Profiles.Resolvers
{
    public class BoardGameDetailsImageResolver : IValueResolver<BoardGame, BoardGameDetailsVm, string?>
    {
        public string? Resolve(BoardGame source, BoardGameDetailsVm destination, string? destMember, ResolutionContext context)
        {
            var imgSrc = "";
            if (source.ImageBytes != null)
            {
                var base64 = Convert.ToBase64String(source.ImageBytes);
                imgSrc = String.Format("data:image/png;base64,{0}", base64);
            }
            return imgSrc;
        }
    }
}
